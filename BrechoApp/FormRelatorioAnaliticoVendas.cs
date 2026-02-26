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
    /// <summary>
    /// Relatório Analítico de Vendas.
    /// Agora simplificado: apenas filtros de Mês e Ano.
    /// Exibe itens vendidos no período e permite exportação para Excel.
    /// </summary>
    public partial class FormRelatorioAnaliticoVendas : Form
    {
        private readonly VendaRepository _vendaRepository;
        private readonly ParceiroNegocioRepository _parceiroRepository;

        private List<ItemVendaAnalitico> _itensCarregados;
        private Dictionary<string, string> _cacheParceiros;

        public FormRelatorioAnaliticoVendas()
        {
            InitializeComponent();

            _vendaRepository = new VendaRepository();
            _parceiroRepository = new ParceiroNegocioRepository();

            _itensCarregados = new List<ItemVendaAnalitico>();
            _cacheParceiros = new Dictionary<string, string>();

            ConfigurarFormulario();
        }

        // ============================================================
        // CONFIGURAÇÃO INICIAL
        // ============================================================
        private void ConfigurarFormulario()
        {
            // Mês
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

            // Ano
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
        // BOTÃO: GERAR RELATÓRIO
        // ============================================================
        private void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMes.SelectedIndex < 0)
                {
                    MessageBox.Show("Selecione um mês.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int mes = cmbMes.SelectedIndex + 1;
                int ano = (int)numAno.Value;

                DateTime inicio = new DateTime(ano, mes, 1);
                DateTime fim = inicio.AddMonths(1).AddDays(-1);

                // Buscar vendas do período
                var vendas = _vendaRepository.ListarVendasPorPeriodo(inicio, fim);

                _itensCarregados = new List<ItemVendaAnalitico>();

                foreach (var venda in vendas)
                {
                    var itens = _vendaRepository.ListarItensPorVenda(venda.IdVenda);

                    foreach (var item in itens)
                    {
                        _itensCarregados.Add(new ItemVendaAnalitico
                        {
                            Data = venda.DataVenda,
                            Vendedor = ObterNomeParceiro(venda.IdVendedor),
                            Cliente = ObterNomeParceiro(venda.IdCliente),
                            CodigoProduto = item.IdProduto,
                            Descricao = item.NomeProduto,
                            Marca = item.MarcaProduto,
                            Categoria = item.CategoriaProduto,
                            Fornecedor = ObterNomeParceiro(item.IdFornecedor),
                            DescontoValor = venda.DescontoValor,
                            DescontoCampanha = venda.DescontoCampanha,
                            NomeCampanha = venda.Campanha,
                            PrecoOriginal = item.PrecoOriginal,
                            PrecoFinal = item.PrecoFinalNegociado
                        });
                    }
                }

                PreencherGrid();
                AtualizarTotalizadores();

                btnExportar.Enabled = _itensCarregados.Count > 0;

                MessageBox.Show("Relatório gerado com sucesso.",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório:\n\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // PREENCHER GRID
        // ============================================================
        private void PreencherGrid()
        {
            dgvRelatorio.Rows.Clear();

            foreach (var item in _itensCarregados)
            {
                dgvRelatorio.Rows.Add(
                    item.Data.ToString("dd/MM/yyyy"),
                    item.Vendedor,
                    item.Cliente,
                    item.CodigoProduto,
                    item.Descricao,
                    item.Marca,
                    item.Categoria,
                    item.Fornecedor,
                    item.DescontoValor.ToString("C2", CultureInfo.GetCultureInfo("pt-BR")),
                    item.DescontoCampanha.ToString("C2", CultureInfo.GetCultureInfo("pt-BR")),
                    item.NomeCampanha,
                    item.PrecoOriginal.ToString("C2", CultureInfo.GetCultureInfo("pt-BR")),
                    item.PrecoFinal.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"))
                );
            }
        }

        // ============================================================
        // TOTALIZADORES
        // ============================================================
        private void AtualizarTotalizadores()
        {
            int totalItens = _itensCarregados.Count;
            double totalArrecadado = _itensCarregados.Sum(i => i.PrecoFinal);

            lblTotalItens.Text = $"Total de Itens: {totalItens}";
            lblTotalArrecadado.Text = $"Total Arrecadado: {totalArrecadado.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"))}";
        }

        // ============================================================
        // EXPORTAR PARA EXCEL
        // ============================================================
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (_itensCarregados.Count == 0)
            {
                MessageBox.Show("Não há dados para exportar.",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Relatório Analítico");

                    ws.Cell(1, 1).Value = "RELATÓRIO ANALÍTICO DE VENDAS";
                    ws.Cell(1, 1).Style.Font.Bold = true;
                    ws.Cell(1, 1).Style.Font.FontSize = 14;

                    ws.Cell(2, 1).Value = $"Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm}";
                    ws.Cell(2, 1).Style.Font.Italic = true;

                    int row = 4;

                    // Cabeçalho
                    string[] headers = new[]
                    {
                        "Data", "Vendedor", "Cliente", "Código Produto", "Descrição",
                        "Marca", "Categoria", "Fornecedor", "Desc R$", "Desc Camp R$",
                        "Campanha", "Preço Original", "Preço Final"
                    };

                    for (int i = 0; i < headers.Length; i++)
                        ws.Cell(row, i + 1).Value = headers[i];

                    ws.Range(row, 1, row, headers.Length).Style.Font.Bold = true;
                    ws.Range(row, 1, row, headers.Length).Style.Fill.BackgroundColor = XLColor.LightBlue;

                    row++;

                    // Dados
                    foreach (var item in _itensCarregados)
                    {
                        ws.Cell(row, 1).Value = item.Data.ToString("dd/MM/yyyy");
                        ws.Cell(row, 2).Value = item.Vendedor;
                        ws.Cell(row, 3).Value = item.Cliente;
                        ws.Cell(row, 4).Value = item.CodigoProduto;
                        ws.Cell(row, 5).Value = item.Descricao;
                        ws.Cell(row, 6).Value = item.Marca;
                        ws.Cell(row, 7).Value = item.Categoria;
                        ws.Cell(row, 8).Value = item.Fornecedor;
                        ws.Cell(row, 9).Value = item.DescontoValor;
                        ws.Cell(row, 10).Value = item.DescontoCampanha;
                        ws.Cell(row, 11).Value = item.NomeCampanha;
                        ws.Cell(row, 12).Value = item.PrecoOriginal;
                        ws.Cell(row, 13).Value = item.PrecoFinal;

                        ws.Cell(row, 9).Style.NumberFormat.Format = "R$ #,##0.00";
                        ws.Cell(row, 10).Style.NumberFormat.Format = "R$ #,##0.00";
                        ws.Cell(row, 12).Style.NumberFormat.Format = "R$ #,##0.00";
                        ws.Cell(row, 13).Style.NumberFormat.Format = "R$ #,##0.00";

                        row++;
                    }

                    ws.Columns().AdjustToContents();
                    ws.RangeUsed().SetAutoFilter();

                    var dialog = new SaveFileDialog
                    {
                        Filter = "Excel (*.xlsx)|*.xlsx",
                        FileName = $"Relatorio_Analitico_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                    };

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        wb.SaveAs(dialog.FileName);
                        MessageBox.Show("Relatório exportado com sucesso.",
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar relatório:\n\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // ============================================================
    // MODELO ANALÍTICO
    // ============================================================
    public class ItemVendaAnalitico
    {
        public DateTime Data { get; set; }
        public string Vendedor { get; set; }
        public string Cliente { get; set; }
        public string CodigoProduto { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public string Fornecedor { get; set; }
        public double DescontoValor { get; set; }
        public double DescontoCampanha { get; set; }
        public string NomeCampanha { get; set; }
        public double PrecoOriginal { get; set; }
        public double PrecoFinal { get; set; }
    }
}

