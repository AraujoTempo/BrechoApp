using BrechoApp.Data;
using BrechoApp.Models;
using BrechoApp.Enums;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace BrechoApp
{
    /// <summary>
    /// Formulário para cadastro e gerenciamento de comissões de vendedores.
    /// Permite cadastrar, editar e excluir comissões para Parceiros de Negócio do tipo Vendedor.
    /// </summary>
    public partial class FormCadastroComissaoVendedor : Form
    {
        private readonly ComissaoVendedorRepository _comissaoRepo = new ComissaoVendedorRepository();
        private readonly ParceiroNegocioRepository _parceiroRepo = new ParceiroNegocioRepository();
        private ComissaoVendedor? _comissaoSelecionada = null;

        public FormCadastroComissaoVendedor()
        {
            InitializeComponent();
            CarregarVendedores();
            CarregarComissoes();
        }

        // ============================================================
        // CARREGAR VENDEDORES NO COMBOBOX
        // ============================================================
        private void CarregarVendedores()
        {
            var vendedores = _parceiroRepo.ListarVendedores();

            cmbVendedor.DataSource = null;
            cmbVendedor.DisplayMember = "Nome";
            cmbVendedor.ValueMember = "CodigoParceiro";
            cmbVendedor.DataSource = vendedores;

            if (vendedores.Count > 0)
            {
                cmbVendedor.SelectedIndex = 0;
            }
            else
            {
                cmbVendedor.SelectedIndex = -1;
                MessageBox.Show(
                    "Nenhum vendedor cadastrado.\n\n" +
                    "Para cadastrar comissões, é necessário primeiro cadastrar Parceiros de Negócio com TipoParceiro = 'Vendedor'.\n\n" +
                    "Acesse: Menu Principal → Cadastros → Parceiros de Negócio",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        // ============================================================
        // CARREGAR COMISSÕES NO DATAGRIDVIEW
        // ============================================================
        private void CarregarComissoes()
        {
            try
            {
                var comissoes = _comissaoRepo.ListarTodas();
                
                // Garantir que nunca seja nulo
                if (comissoes == null)
                    comissoes = new List<ComissaoVendedor>();

                dgvComissoes.DataSource = comissoes;

                // Configurar colunas (mesmo se lista vazia)
                if (dgvComissoes.Columns.Count > 0)
                {
                    // Ocultar IdComissao e CodigoPN
                    if (dgvComissoes.Columns.Contains("IdComissao"))
                        dgvComissoes.Columns["IdComissao"].Visible = false;

                    if (dgvComissoes.Columns.Contains("CodigoPN"))
                        dgvComissoes.Columns["CodigoPN"].Visible = false;

                    // Configurar cabeçalhos e larguras
                    if (dgvComissoes.Columns.Contains("NomeVendedor"))
                    {
                        dgvComissoes.Columns["NomeVendedor"].HeaderText = "Vendedor";
                        dgvComissoes.Columns["NomeVendedor"].Width = 250;
                    }

                    if (dgvComissoes.Columns.Contains("PercentualComissao"))
                    {
                        dgvComissoes.Columns["PercentualComissao"].HeaderText = "Comissão (%)";
                        dgvComissoes.Columns["PercentualComissao"].Width = 100;
                        dgvComissoes.Columns["PercentualComissao"].DefaultCellStyle.Format = "N2";
                    }

                    if (dgvComissoes.Columns.Contains("DataCadastro"))
                    {
                        dgvComissoes.Columns["DataCadastro"].HeaderText = "Data de Cadastro";
                        dgvComissoes.Columns["DataCadastro"].Width = 150;
                        dgvComissoes.Columns["DataCadastro"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    }

                    if (dgvComissoes.Columns.Contains("DataUltimaAlteracao"))
                    {
                        dgvComissoes.Columns["DataUltimaAlteracao"].HeaderText = "Última Alteração";
                        dgvComissoes.Columns["DataUltimaAlteracao"].Width = 150;
                        dgvComissoes.Columns["DataUltimaAlteracao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao carregar comissões: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // BOTÃO SALVAR - ADICIONAR OU ATUALIZAR COMISSÃO
        // ============================================================
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar se um vendedor foi selecionado
                if (cmbVendedor.SelectedValue == null)
                {
                    MessageBox.Show("Selecione um vendedor.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbVendedor.Focus();
                    return;
                }

                // Validar percentual
                if (string.IsNullOrWhiteSpace(txtPercentual.Text))
                {
                    MessageBox.Show("Informe o percentual de comissão.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPercentual.Focus();
                    return;
                }

                // Tentar converter o percentual
                string percentualText = txtPercentual.Text.Trim().Replace(",", ".");
                if (!decimal.TryParse(percentualText, 
                    NumberStyles.Number, CultureInfo.InvariantCulture, out decimal percentual))
                {
                    MessageBox.Show("Percentual inválido. Use apenas números.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPercentual.Focus();
                    return;
                }

                // Validar range do percentual
                if (percentual <= 0 || percentual > 100)
                {
                    MessageBox.Show("O percentual de comissão deve ser maior que 0 e menor ou igual a 100.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPercentual.Focus();
                    return;
                }

                string codigoPN = cmbVendedor.SelectedValue.ToString()!;

                // Verificar se o PN selecionado é um vendedor
                var parceiro = _parceiroRepo.BuscarPorCodigo(codigoPN);
                if (parceiro == null)
                {
                    MessageBox.Show("Parceiro de Negócio não encontrado.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (parceiro.TipoParceiro != TipoParceiro.Vendedor)
                {
                    MessageBox.Show("Apenas Parceiros de Negócio do tipo Vendedor podem receber comissão.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificar se já existe comissão para este vendedor
                var comissaoExistente = _comissaoRepo.BuscarPorCodigoPN(codigoPN);

                if (comissaoExistente != null && (_comissaoSelecionada == null || comissaoExistente.IdComissao != _comissaoSelecionada.IdComissao))
                {
                    var resultado = MessageBox.Show(
                        $"Já existe uma comissão cadastrada para {parceiro.Nome} ({comissaoExistente.PercentualComissao:N2}%).\n\n" +
                        "Deseja editar a comissão existente?",
                        "Comissão Existente",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        // Carregar a comissão existente para edição
                        _comissaoSelecionada = comissaoExistente;
                        txtPercentual.Text = comissaoExistente.PercentualComissao.ToString(CultureInfo.InvariantCulture);
                        return;
                    }
                    else
                    {
                        return;
                    }
                }

                // Criar ou atualizar comissão
                var comissao = new ComissaoVendedor
                {
                    IdComissao = _comissaoSelecionada?.IdComissao ?? 0,
                    CodigoPN = codigoPN,
                    PercentualComissao = percentual,
                    DataCadastro = _comissaoSelecionada?.DataCadastro ?? DateTime.Now
                };

                _comissaoRepo.Salvar(comissao);

                string mensagem = _comissaoSelecionada == null 
                    ? "Comissão cadastrada com sucesso!" 
                    : "Comissão atualizada com sucesso!";

                MessageBox.Show(mensagem, "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
                CarregarComissoes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar comissão: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // BOTÃO NOVO - LIMPAR CAMPOS
        // ============================================================
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        // ============================================================
        // BOTÃO EXCLUIR - REMOVER COMISSÃO
        // ============================================================
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_comissaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma comissão para excluir.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                $"Deseja realmente excluir a comissão de {_comissaoSelecionada.NomeVendedor}?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    _comissaoRepo.Excluir(_comissaoSelecionada.IdComissao);
                    MessageBox.Show("Comissão excluída com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();
                    CarregarComissoes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir comissão: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ============================================================
        // EVENTO DE SELEÇÃO NO DATAGRIDVIEW
        // ============================================================
        private void dgvComissoes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvComissoes.CurrentRow != null && dgvComissoes.CurrentRow.DataBoundItem != null)
            {
                _comissaoSelecionada = (ComissaoVendedor)dgvComissoes.CurrentRow.DataBoundItem;

                // Carregar dados nos campos
                var vendedor = cmbVendedor.Items.Cast<ParceiroNegocio>()
                    .FirstOrDefault(v => v.CodigoParceiro == _comissaoSelecionada.CodigoPN);

                if (vendedor != null)
                {
                    cmbVendedor.SelectedItem = vendedor;
                }

                txtPercentual.Text = _comissaoSelecionada.PercentualComissao.ToString(CultureInfo.InvariantCulture);
            }
        }

        // ============================================================
        // BOTÃO VOLTAR
        // ============================================================
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ============================================================
        // HELPER: LIMPAR CAMPOS
        // ============================================================
        private void LimparCampos()
        {
            _comissaoSelecionada = null;
            txtPercentual.Clear();
            
            if (cmbVendedor.Items.Count > 0)
                cmbVendedor.SelectedIndex = 0;
            
            txtPercentual.Focus();
        }
    }
}
