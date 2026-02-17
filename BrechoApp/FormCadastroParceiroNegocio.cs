using System;
using System.Linq;
using System.Windows.Forms;
using BrechoApp.Data;
using BrechoApp.Models;
using BrechoApp.Utils;
using BrechoApp.Enums;
using ClosedXML.Excel;

namespace BrechoApp
{
    public partial class FormCadastroParceiroNegocio : Form
    {
        private const string CPFCNPJ_DUMMY = "123.456.789-09";

        // Propriedades para modo de seleção
        public bool ModoSelecao { get; set; } = false;
        public string ParceiroSelecionado { get; private set; }

        public FormCadastroParceiroNegocio(bool modoSelecao = false, TipoParceiro? filtroTipo = null)
        {
            InitializeComponent();
            ModoSelecao = modoSelecao;

            if (modoSelecao)
            {
                // Ocultar botões de edição no modo de seleção
                btnSalvar.Visible = false;
                btnIncluir.Visible = false;
                btnLotes.Visible = false;
                btnExportarExcel.Visible = false;

                // Mudar título
                this.Text = "Selecionar Parceiro de Negócio";
            }

            CarregarTiposParceiro();

            if (filtroTipo.HasValue)
            {
                // Aplicar filtro por tipo
                var repo = new ParceiroNegocioRepository();
                var lista = repo.ListarParceiros()
                    .Where(p => p.TipoParceiro == filtroTipo.Value)
                    .ToList();
                dataGridParceiros.DataSource = lista;
            }
            else
            {
                CarregarParceiros();
            }
        }

        // ============================================================
        //  CARREGAR TIPOS DE PARCEIRO NO COMBOBOX
        // ============================================================
        private void CarregarTiposParceiro()
        {
            cboTipoParceiro.DataSource = Enum.GetValues(typeof(TipoParceiro));
            cboTipoParceiro.SelectedItem = TipoParceiro.Outro;
        }

        // ============================================================
        //  CARREGAR PARCEIROS (com filtro opcional)
        // ============================================================
        private void CarregarParceiros(string filtro = "")
        {
            var repo = new ParceiroNegocioRepository();

            if (string.IsNullOrWhiteSpace(filtro))
                dataGridParceiros.DataSource = repo.ListarParceiros();
            else
                dataGridParceiros.DataSource = repo.Buscar(filtro);
        }

        // ============================================================
        //  BUSCA DINÂMICA
        // ============================================================
        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            CarregarParceiros(txtBusca.Text.Trim());
        }

        // ============================================================
        //  CLIQUE NO GRID → CARREGA CAMPOS DO PN SELECIONADO
        // ============================================================
        private void dataGridParceiros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dataGridParceiros.Rows[e.RowIndex];

            txtCodigoParceiro.Text = row.Cells["CodigoParceiro"].Value?.ToString();
            txtNome.Text = row.Cells["Nome"].Value?.ToString();
            
            // Carrega TipoParceiro
            if (row.Cells["TipoParceiro"].Value != null && 
                Enum.TryParse<TipoParceiro>(row.Cells["TipoParceiro"].Value.ToString(), out var tipo))
            {
                cboTipoParceiro.SelectedItem = tipo;
            }
            
            txtCPF.Text = row.Cells["CpfCnpj"].Value?.ToString();
            txtApelido.Text = row.Cells["Apelido"].Value?.ToString();
            txtTelefone.Text = row.Cells["Telefone"].Value?.ToString();
            txtEndereco.Text = row.Cells["Endereco"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            txtBanco.Text = row.Cells["Banco"].Value?.ToString();
            txtAgencia.Text = row.Cells["Agencia"].Value?.ToString();
            txtConta.Text = row.Cells["Conta"].Value?.ToString();
            txtPix.Text = row.Cells["Pix"].Value?.ToString();
            txtObservacao.Text = row.Cells["Observacao"].Value?.ToString();
            txtPercentualComissao.Text = row.Cells["PercentualComissao"].Value?.ToString();
            txtSaldoCredito.Text = row.Cells["SaldoCredito"].Value?.ToString();

            chkAutorizaDoacao.Checked = row.Cells["AutorizaDoacao"].Value?.ToString() == "1";

            if (DateTime.TryParse(row.Cells["Aniversario"].Value?.ToString(), out DateTime aniversario))
                dtpAniversario.Value = aniversario;
        }

        // ============================================================
        //  BOTÃO INCLUIR (NOVO)
        // ============================================================
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            LimparCampos();
            txtNome.Focus();

            MessageBox.Show("Novo Parceiro de Negócio iniciado. Preencha os dados e clique em SALVAR.");
        }
        // ============================================================
        //  BOTÃO SALVAR (INCLUIR OU EDITAR)
        // ============================================================
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // ------------------------------
                // Validações básicas
                // ------------------------------
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                    throw new Exception("O nome do parceiro é obrigatório.");

                // CPF/CNPJ dummy é permitido e ignora validação
                if (!string.IsNullOrWhiteSpace(txtCPF.Text) &&
                    txtCPF.Text != CPFCNPJ_DUMMY &&
                    !ValidadorBrasil.DocumentoValido(txtCPF.Text))
                {
                    throw new Exception("CPF ou CNPJ inválido.");
                }

                if (!string.IsNullOrWhiteSpace(txtEmail.Text) &&
                    !ValidadorBrasil.EmailValido(txtEmail.Text))
                    throw new Exception("E-mail inválido.");

                if (!string.IsNullOrWhiteSpace(txtTelefone.Text) &&
                    !ValidadorBrasil.TelefoneValido(txtTelefone.Text))
                    throw new Exception("Telefone inválido.");

                if (!string.IsNullOrWhiteSpace(txtAgencia.Text) &&
                    !ValidadorBrasil.AgenciaValida(txtAgencia.Text))
                    throw new Exception("Agência inválida.");

                if (!string.IsNullOrWhiteSpace(txtConta.Text) &&
                    !ValidadorBrasil.ContaValida(txtConta.Text))
                    throw new Exception("Conta bancária inválida.");

                if (!string.IsNullOrWhiteSpace(txtPix.Text) &&
                    !ValidadorBrasil.PixValido(txtPix.Text))
                    throw new Exception("Chave PIX inválida.");

                // ------------------------------
                // Verificação de duplicidade de documento
                // (exceto se for o CPF/CNPJ dummy)
                // ------------------------------
                if (txtCPF.Text != CPFCNPJ_DUMMY)
                {
                    var repoCheck = new ParceiroNegocioRepository();
                    if (repoCheck.DocumentoExiste(txtCPF.Text, txtCodigoParceiro.Text))
                        throw new Exception("Já existe um parceiro cadastrado com este documento (CPF/CNPJ).");
                }

                // ------------------------------
                // Monta o objeto PN
                // ------------------------------
                var parceiro = new ParceiroNegocio
                {
                    CodigoParceiro = txtCodigoParceiro.Text, // vazio = novo PN
                    Nome = txtNome.Text,
                    TipoParceiro = (TipoParceiro)cboTipoParceiro.SelectedItem,
                    CpfCnpj = txtCPF.Text,
                    Apelido = txtApelido.Text,
                    Telefone = txtTelefone.Text,
                    Endereco = txtEndereco.Text,
                    Email = txtEmail.Text,
                    Banco = txtBanco.Text,
                    Agencia = txtAgencia.Text,
                    Conta = txtConta.Text,
                    Pix = txtPix.Text,
                    Observacao = txtObservacao.Text,
                    PercentualComissao = double.TryParse(txtPercentualComissao.Text, out double comissao) ? comissao : 0,
                    SaldoCredito = double.TryParse(txtSaldoCredito.Text, out double saldo) ? saldo : 0,
                    AutorizaDoacao = chkAutorizaDoacao.Checked,
                    Aniversario = dtpAniversario.Value.ToString("yyyy-MM-dd")
                };

                // ------------------------------
                // Salva no repositório
                // ------------------------------
                var repo = new ParceiroNegocioRepository();
                repo.SalvarParceiro(parceiro);

                CarregarParceiros();
                LimparCampos();

                MessageBox.Show("Parceiro salvo com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao salvar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // ============================================================
        //  BOTÃO EDITAR
        // ============================================================
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoParceiro.Text))
            {
                MessageBox.Show("Selecione um parceiro para editar.");
                return;
            }

            MessageBox.Show("Edite os dados e clique em SALVAR para gravar as alterações.");
        }

        // ============================================================
        //  EXPORTAR EXCEL
        // ============================================================
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            var repo = new ParceiroNegocioRepository();
            var lista = repo.ListarParceiros();

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Parceiros");

                ws.Cell(1, 1).Value = "Código";
                ws.Cell(1, 2).Value = "Nome";
                ws.Cell(1, 3).Value = "Tipo Parceiro";
                ws.Cell(1, 4).Value = "CPF/CNPJ";
                ws.Cell(1, 5).Value = "Apelido";
                ws.Cell(1, 6).Value = "Telefone";
                ws.Cell(1, 7).Value = "Endereço";
                ws.Cell(1, 8).Value = "Email";
                ws.Cell(1, 9).Value = "Banco";
                ws.Cell(1, 10).Value = "Agência";
                ws.Cell(1, 11).Value = "Conta";
                ws.Cell(1, 12).Value = "Pix";
                ws.Cell(1, 13).Value = "Percentual Comissão";
                ws.Cell(1, 14).Value = "Autoriza Doação";
                ws.Cell(1, 15).Value = "Observação";
                ws.Cell(1, 16).Value = "Aniversário";
                ws.Cell(1, 17).Value = "Saldo Crédito";

                ws.Range(1, 1, 1, 17).Style.Font.Bold = true;

                int row = 2;

                foreach (var p in lista)
                {
                    ws.Cell(row, 1).Value = p.CodigoParceiro;
                    ws.Cell(row, 2).Value = p.Nome;
                    ws.Cell(row, 3).Value = p.TipoParceiro.ToString();
                    ws.Cell(row, 4).Value = p.CpfCnpj;
                    ws.Cell(row, 5).Value = p.Apelido;
                    ws.Cell(row, 6).Value = p.Telefone;
                    ws.Cell(row, 7).Value = p.Endereco;
                    ws.Cell(row, 8).Value = p.Email;
                    ws.Cell(row, 9).Value = p.Banco;
                    ws.Cell(row, 10).Value = p.Agencia;
                    ws.Cell(row, 11).Value = p.Conta;
                    ws.Cell(row, 12).Value = p.Pix;
                    ws.Cell(row, 13).Value = p.PercentualComissao;
                    ws.Cell(row, 14).Value = p.AutorizaDoacao ? "Sim" : "Não";
                    ws.Cell(row, 15).Value = p.Observacao;
                    ws.Cell(row, 16).Value = p.Aniversario;
                    ws.Cell(row, 17).Value = p.SaldoCredito;

                    row++;
                }

                ws.Columns().AdjustToContents();

                var dialog = new SaveFileDialog
                {
                    Filter = "Excel (*.xlsx)|*.xlsx",
                    FileName = "Parceiros.xlsx"
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(dialog.FileName);
                    MessageBox.Show("Arquivo Excel gerado com sucesso!");
                }
            }
        }

        // ============================================================
        //  BOTÃO LOTES
        // ============================================================
        private void btnLotes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoParceiro.Text))
            {
                MessageBox.Show(
                    "Selecione um parceiro antes de acessar os lotes.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var parceiro = new ParceiroNegocio
            {
                CodigoParceiro = txtCodigoParceiro.Text,
                Nome = txtNome.Text,
                Apelido = txtApelido.Text
            };

            using var tela = new FormLoteRecebimento(parceiro);
            tela.ShowDialog();
        }

        // ============================================================
        //  LIMPAR CAMPOS
        // ============================================================
        private void LimparCampos()
        {
            txtCodigoParceiro.Clear();
            txtNome.Clear();
            cboTipoParceiro.SelectedItem = TipoParceiro.Outro;
            txtCPF.Clear();
            txtApelido.Clear();
            txtTelefone.Clear();
            txtEndereco.Clear();
            txtEmail.Clear();
            txtBanco.Clear();
            txtAgencia.Clear();
            txtConta.Clear();
            txtPix.Clear();
            txtObservacao.Clear();
            txtPercentualComissao.Clear();
            txtSaldoCredito.Clear();
            chkAutorizaDoacao.Checked = false;
            dtpAniversario.Value = DateTime.Now;
        }

        // ============================================================
        //  DUPLO CLIQUE NO GRID (para modo de seleção)
        // ============================================================
        private void dataGridParceiros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!ModoSelecao) return;
            if (e.RowIndex < 0) return;

            ParceiroSelecionado = dataGridParceiros.Rows[e.RowIndex]
                .Cells["CodigoParceiro"].Value?.ToString();

            if (!string.IsNullOrWhiteSpace(ParceiroSelecionado))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
