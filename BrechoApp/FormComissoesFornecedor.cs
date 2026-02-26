using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BrechoApp.Data;
using BrechoApp.Models;
using ClosedXML.Excel;

namespace BrechoApp
{
    public partial class FormComissoesFornecedor : Form
    {
        private readonly VendaRepository _vendaRepository;
        private readonly ParceiroNegocioRepository _parceiroRepository;

        private List<Venda> _vendasCarregadas;
        private Dictionary<string, string> _cacheParceiros;

        private string _fornecedorSelecionado = string.Empty;

        public FormComissoesFornecedor()
        {
            InitializeComponent();

            _vendaRepository = new VendaRepository();
            _parceiroRepository = new ParceiroNegocioRepository();

            _vendasCarregadas = new List<Venda>();
            _cacheParceiros = new Dictionary<string, string>();

            ConfigurarFormulario();
        }

        // ============================================================
        // CONFIGURAÇÃO INICIAL
        // ============================================================
        private void ConfigurarFormulario()
        {
            cmbMes.Items.Clear();
            cmbMes.Items.Add("Janeiro (1)");
            cmbMes.Items.Add("Fevereiro (2)");
            cmbMes.Items.Add("Março (3)");
            cmbMes.Items.Add("Abril (4)");
            cmbMes.Items.Add("Maio (5)");
            cmbMes.Items.Add("Junho (6)");
            cmbMes.Items.Add("Julho (7)");
            cmbMes.Items.Add("Agosto (8)");
            cmbMes.Items.Add("Setembro (9)");
            cmbMes.Items.Add("Outubro (10)");
            cmbMes.Items.Add("Novembro (11)");
            cmbMes.Items.Add("Dezembro (12)");

            cmbMes.SelectedIndex = DateTime.Now.Month - 1;

            numAno.Minimum = 2020;
            numAno.Maximum = 2050;
            numAno.Value = DateTime.Now.Year;

            btnExportar.Enabled = false;

            CarregarCacheParceiros();
        }

        // ============================================================
        // CACHE DE PARCEIROS
        // ============================================================
        private void CarregarCacheParceiros()
        {
            try
            {
                var parceiros = _parceiroRepository.ListarParceiros();
                _cacheParceiros.Clear();

                foreach (var p in parceiros)
                    _cacheParceiros[p.CodigoParceiro] = p.Nome;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar parceiros:\n\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObterNomeParceiro(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return "N/A";

            return _cacheParceiros.ContainsKey(codigo)
                ? _cacheParceiros[codigo]
                : codigo;
        }

        // ============================================================
        // BOTÃO: SELECIONAR FORNECEDOR
        // ============================================================
        private void btnSelecionarFornecedor_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCadastroParceiroNegocio(modoSelecao: true);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    var fornecedor = _parceiroRepository.BuscarPorCodigo(form.ParceiroSelecionado);

                    if (fornecedor != null)
                    {
                        _fornecedorSelecionado = fornecedor.CodigoParceiro;
                        txtFornecedor.Text = $"{fornecedor.CodigoParceiro} - {fornecedor.Nome}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar fornecedor:\n\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // BOTÃO: LIMPAR FORNECEDOR
        // ============================================================
        private void btnLimparFornecedor_Click(object sender, EventArgs e)
        {
            _fornecedorSelecionado = string.Empty;
            txtFornecedor.Text = string.Empty;
        }

        // ============================================================
        // BOTÃO: GERAR EXTRATO
        // ============================================================
        private void btnGerarExtrato_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMes.SelectedIndex < 0)
                {
                    MessageBox.Show("Selecione um mês.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(_fornecedorSelecionado))
                {
                    MessageBox.Show("Selecione um fornecedor (PN).", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int mes = cmbMes.SelectedIndex + 1;
                int ano = (int)numAno.Value;

                DateTime inicio = new DateTime(ano, mes, 1);
                DateTime fim = inicio.AddMonths(1).AddDays(-1);

                _vendasCarregadas = _vendaRepository.ListarVendasPorPeriodo(inicio, fim);

                var itensFiltrados = new List<VendaItem>();

                foreach (var venda in _vendasCarregadas)
                {
                    var itens = _vendaRepository.ListarItensPorVenda(venda.IdVenda);

                    itensFiltrados.AddRange(
                        itens.Where(i => i.IdFornecedor == _fornecedorSelecionado)
                    );
                }

                if (itensFiltrados.Count == 0)
                {
                    MessageBox.Show("Nenhum item encontrado para este fornecedor no período selecionado.",
                        "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvRelatorio.Rows.Clear();
                    AtualizarTotalizadores(0, 0);
                    btnExportar.Enabled = false;
                    return;
                }

                PreencherGrid(itensFiltrados);

                double totalComissao = itensFiltrados.Sum(i =>
                {
                    var pn = _parceiroRepository.BuscarPorCodigo(i.IdFornecedor);
                    double perc = pn?.PercentualComissao ?? 0;
                    return i.PrecoFinalNegociado * (perc / 100);
                });

                AtualizarTotalizadores(itensFiltrados.Count, totalComissao);

                btnExportar.Enabled = true;

                MessageBox.Show("Extrato gerado com sucesso!",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar extrato:\n\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // PREENCHER GRID (CORRIGIDO)
        // ============================================================
        private void PreencherGrid(List<VendaItem> itens)
        {
            dgvRelatorio.Rows.Clear();

            foreach (var item in itens)
            {
                // Buscar a venda correspondente para pegar a data
                var venda = _vendasCarregadas.FirstOrDefault(v => v.IdVenda == item.IdVenda);
                string dataVenda = venda != null
                    ? venda.DataVenda.ToString("dd/MM/yyyy")
                    : "";

                var pn = _parceiroRepository.BuscarPorCodigo(item.IdFornecedor);
                double perc = pn?.PercentualComissao ?? 0;
                double comissao = item.PrecoFinalNegociado * (perc / 100);

                dgvRelatorio.Rows.Add(
                    dataVenda,
                    item.IdVenda,
                    item.NomeProduto,
                    item.MarcaProduto,
                    item.CategoriaProduto,
                    item.PrecoFinalNegociado.ToString("C2", CultureInfo.GetCultureInfo("pt-BR")),
                    perc.ToString("F2") + "%",
                    comissao.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"))
                );
            }
        }

        // ============================================================
        // TOTALIZADORES
        // ============================================================
        private void AtualizarTotalizadores(int totalItens, double totalComissao)
        {
            lblTotalItens.Text = $"Total de Itens: {totalItens}";
            lblTotalComissao.Text = $"Total de Comissão: {totalComissao.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"))}";
        }

        // ============================================================
        // EXPORTAR PARA EXCEL (CORRIGIDO)
        // ============================================================
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRelatorio.Rows.Count == 0)
                {
                    MessageBox.Show("Não há dados para exportar.",
                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int mes = cmbMes.SelectedIndex + 1;
                int ano = (int)numAno.Value;

                using (var wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Extrato de Comissões");

                    ws.Cell(1, 1).Value = $"EXTRATO DE COMISSÕES - {cmbMes.Text.ToUpper()} / {ano}";
                    ws.Cell(1, 1).Style.Font.Bold = true;
                    ws.Cell(1, 1).Style.Font.FontSize = 14;

                    ws.Cell(2, 1).Value = $"Fornecedor: {txtFornecedor.Text}";
                    ws.Cell(3, 1).Value = $"Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm}";

                    int row = 5;

                    ws.Cell(row, 1).Value = "Data";
                    ws.Cell(row, 2).Value = "Código Venda";
                    ws.Cell(row, 3).Value = "Produto";
                    ws.Cell(row, 4).Value = "Marca";
                    ws.Cell(row, 5).Value = "Categoria";
                    ws.Cell(row, 6).Value = "Preço Final";
                    ws.Cell(row, 7).Value = "% PN";
                    ws.Cell(row, 8).Value = "Comissão";

                    ws.Range(row, 1, row, 8).Style.Font.Bold = true;
                    ws.Range(row, 1, row, 8).Style.Fill.BackgroundColor = XLColor.LightBlue;

                    row++;

                    foreach (DataGridViewRow linha in dgvRelatorio.Rows)
                    {
                        ws.Cell(row, 1).Value = linha.Cells[0].Value?.ToString();
                        ws.Cell(row, 2).Value = linha.Cells[1].Value?.ToString();
                        ws.Cell(row, 3).Value = linha.Cells[2].Value?.ToString();
                        ws.Cell(row, 4).Value = linha.Cells[3].Value?.ToString();
                        ws.Cell(row, 5).Value = linha.Cells[4].Value?.ToString();
                        ws.Cell(row, 6).Value = linha.Cells[5].Value?.ToString();
                        ws.Cell(row, 7).Value = linha.Cells[6].Value?.ToString();
                        ws.Cell(row, 8).Value = linha.Cells[7].Value?.ToString();

                        row++;
                    }

                    row++;
                    ws.Cell(row, 1).Value = "Total de Itens:";
                    ws.Cell(row, 2).Value = dgvRelatorio.Rows.Count;

                    row++;
                    ws.Cell(row, 1).Value = "Total de Comissão:";
                    ws.Cell(row, 2).Value = lblTotalComissao.Text.Replace("Total de Comissão: ", "");

                    ws.Columns().AdjustToContents();

                    var dialog = new SaveFileDialog
                    {
                        Filter = "Excel (*.xlsx)|*.xlsx",
                        FileName = $"Extrato_Comissoes_{mes:00}_{ano}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                        Title = "Salvar Extrato"
                    };

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        wb.SaveAs(dialog.FileName);

                        MessageBox.Show("Extrato exportado com sucesso!",
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar extrato:\n\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // FECHAR
        // ============================================================
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}