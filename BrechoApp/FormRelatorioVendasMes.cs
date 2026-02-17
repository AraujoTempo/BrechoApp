using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrechoApp.Data;
using BrechoApp.Models;
using ClosedXML.Excel;

namespace BrechoApp
{
    /// <summary>
    /// Formulário de Relatório de Vendas Mensal.
    /// Permite filtrar vendas por mês/ano, visualizar detalhes e exportar para Excel.
    /// </summary>
    public partial class FormRelatorioVendasMes : Form
    {
        private readonly VendaRepository _vendaRepository;
        private readonly ParceiroNegocioRepository _parceiroRepository;
        private List<Venda> _vendasCarregadas;
        private Dictionary<string, string> _cacheParceiros; // Código -> Nome

        public FormRelatorioVendasMes()
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
            // Configurar ComboBox de mês
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

            // Selecionar mês atual
            cmbMes.SelectedIndex = DateTime.Now.Month - 1;

            // Configurar NumericUpDown de ano
            numAno.Minimum = 2020;
            numAno.Maximum = 2050;
            numAno.Value = DateTime.Now.Year;

            // Desabilitar botão de exportar inicialmente
            btnExportar.Enabled = false;

            // Carregar cache de parceiros
            CarregarCacheParceiros();
        }

        // ============================================================
        // CARREGA CACHE DE PARCEIROS (performance)
        // ============================================================
        private void CarregarCacheParceiros()
        {
            try
            {
                var parceiros = _parceiroRepository.ListarParceiros();
                _cacheParceiros.Clear();

                foreach (var p in parceiros)
                {
                    _cacheParceiros[p.CodigoParceiro] = p.Nome;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar parceiros:\n\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // OBTER NOME DO PARCEIRO (usa cache)
        // ============================================================
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
                // Validar seleção
                if (cmbMes.SelectedIndex < 0)
                {
                    MessageBox.Show("Selecione um mês.", "Atenção", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int mes = cmbMes.SelectedIndex + 1;
                int ano = (int)numAno.Value;

                // Calcular período
                DateTime inicio = new DateTime(ano, mes, 1);
                DateTime fim = inicio.AddMonths(1).AddDays(-1);

                // Buscar vendas
                _vendasCarregadas = _vendaRepository.ListarVendasPorPeriodo(inicio, fim);

                if (_vendasCarregadas.Count == 0)
                {
                    MessageBox.Show($"Nenhuma venda encontrada para {cmbMes.Text} de {ano}.",
                        "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    LimparGrid();
                    AtualizarTotalizadores(0, 0);
                    btnExportar.Enabled = false;
                    return;
                }

                // Exibir no grid
                PreencherGridVendas();

                // Atualizar totalizadores
                double totalArrecadado = _vendasCarregadas.Sum(v => v.ValorTotalFinal);
                AtualizarTotalizadores(_vendasCarregadas.Count, totalArrecadado);

                // Habilitar exportação
                btnExportar.Enabled = true;

                MessageBox.Show($"Relatório gerado com sucesso!\n\n" +
                    $"Total de vendas: {_vendasCarregadas.Count}\n" +
                    $"Total arrecadado: {totalArrecadado.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"))}",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório:\n\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // PREENCHER GRID DE VENDAS
        // ============================================================
        private void PreencherGridVendas()
        {
            dgvRelatorio.Rows.Clear();

            foreach (var venda in _vendasCarregadas)
            {
                string nomeVendedor = ObterNomeParceiro(venda.IdVendedor);
                string nomeCliente = ObterNomeParceiro(venda.IdCliente);

                dgvRelatorio.Rows.Add(
                    venda.IdVenda,
                    venda.CodigoVenda,
                    venda.DataVenda.ToString("dd/MM/yyyy"),
                    nomeVendedor,
                    nomeCliente,
                    venda.FormaPagamento,
                    venda.DescontoPercentual.ToString("F2") + "%",
                    venda.DescontoValor.ToString("C2", CultureInfo.GetCultureInfo("pt-BR")),
                    venda.ValorTotalOriginal.ToString("C2", CultureInfo.GetCultureInfo("pt-BR")),
                    venda.ValorTotalFinal.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"))
                );
            }
        }

        // ============================================================
        // LIMPAR GRID
        // ============================================================
        private void LimparGrid()
        {
            dgvRelatorio.Rows.Clear();
            dgvItens.Rows.Clear();
        }

        // ============================================================
        // ATUALIZAR TOTALIZADORES
        // ============================================================
        private void AtualizarTotalizadores(int totalVendas, double totalArrecadado)
        {
            lblTotalVendas.Text = $"Total de Vendas: {totalVendas}";
            lblTotalArrecadado.Text = $"Total Arrecadado: {totalArrecadado.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"))}";
        }

        // ============================================================
        // SELEÇÃO DE VENDA NO GRID
        // ============================================================
        private void dgvRelatorio_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRelatorio.SelectedRows.Count == 0)
            {
                dgvItens.Rows.Clear();
                return;
            }

            try
            {
                int idVenda = Convert.ToInt32(dgvRelatorio.SelectedRows[0].Cells["colIdVenda"].Value);
                CarregarItensVenda(idVenda);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar itens da venda:\n\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // CARREGAR ITENS DA VENDA
        // ============================================================
        private void CarregarItensVenda(int idVenda)
        {
            dgvItens.Rows.Clear();

            var itens = _vendaRepository.ListarItensPorVenda(idVenda);

            foreach (var item in itens)
            {
                string nomeFornecedor = ObterNomeParceiro(item.IdFornecedor);

                dgvItens.Rows.Add(
                    item.IdProduto,
                    item.NomeProduto,
                    item.MarcaProduto,
                    item.CategoriaProduto,
                    nomeFornecedor,
                    item.PrecoOriginal.ToString("C2", CultureInfo.GetCultureInfo("pt-BR")),
                    item.PrecoFinalNegociado.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"))
                );
            }
        }

        // ============================================================
        // BOTÃO: EXPORTAR PARA EXCEL
        // ============================================================
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (_vendasCarregadas.Count == 0)
            {
                MessageBox.Show("Não há dados para exportar. Gere o relatório primeiro.",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int mes = cmbMes.SelectedIndex + 1;
                int ano = (int)numAno.Value;

                using (var wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Relatório de Vendas");

                    // ============================================================
                    // CABEÇALHO DO RELATÓRIO
                    // ============================================================
                    ws.Cell(1, 1).Value = $"RELATÓRIO DE VENDAS - {cmbMes.Text.ToUpper()} / {ano}";
                    ws.Cell(1, 1).Style.Font.Bold = true;
                    ws.Cell(1, 1).Style.Font.FontSize = 14;

                    ws.Cell(2, 1).Value = $"Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm}";
                    ws.Cell(2, 1).Style.Font.Italic = true;

                    // ============================================================
                    // CABEÇALHO DA TABELA DE VENDAS
                    // ============================================================
                    int row = 4;

                    ws.Cell(row, 1).Value = "Id";
                    ws.Cell(row, 2).Value = "Código";
                    ws.Cell(row, 3).Value = "Data";
                    ws.Cell(row, 4).Value = "Vendedor";
                    ws.Cell(row, 5).Value = "Cliente";
                    ws.Cell(row, 6).Value = "Forma Pag.";
                    ws.Cell(row, 7).Value = "Desc %";
                    ws.Cell(row, 8).Value = "Desc R$";
                    ws.Cell(row, 9).Value = "Total Orig.";
                    ws.Cell(row, 10).Value = "Total Final";

                    // Formatar cabeçalho
                    var headerRange = ws.Range(row, 1, row, 10);
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.BackgroundColor = XLColor.LightBlue;
                    headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    row++;

                    // ============================================================
                    // DADOS DAS VENDAS
                    // ============================================================
                    foreach (var venda in _vendasCarregadas)
                    {
                        string nomeVendedor = ObterNomeParceiro(venda.IdVendedor);
                        string nomeCliente = ObterNomeParceiro(venda.IdCliente);

                        ws.Cell(row, 1).Value = venda.IdVenda;
                        ws.Cell(row, 2).Value = venda.CodigoVenda;
                        ws.Cell(row, 3).Value = venda.DataVenda.ToString("dd/MM/yyyy");
                        ws.Cell(row, 4).Value = nomeVendedor;
                        ws.Cell(row, 5).Value = nomeCliente;
                        ws.Cell(row, 6).Value = venda.FormaPagamento;
                        ws.Cell(row, 7).Value = venda.DescontoPercentual.ToString("F2") + "%";
                        ws.Cell(row, 8).Value = venda.DescontoValor;
                        ws.Cell(row, 9).Value = venda.ValorTotalOriginal;
                        ws.Cell(row, 10).Value = venda.ValorTotalFinal;

                        // Formatar valores monetários
                        ws.Cell(row, 8).Style.NumberFormat.Format = "R$ #,##0.00";
                        ws.Cell(row, 9).Style.NumberFormat.Format = "R$ #,##0.00";
                        ws.Cell(row, 10).Style.NumberFormat.Format = "R$ #,##0.00";

                        row++;

                        // ============================================================
                        // ITENS DA VENDA
                        // ============================================================
                        var itens = _vendaRepository.ListarItensPorVenda(venda.IdVenda);
                        
                        if (itens.Count > 0)
                        {
                            // Cabeçalho dos itens
                            ws.Cell(row, 2).Value = "Itens da Venda:";
                            ws.Cell(row, 2).Style.Font.Italic = true;
                            ws.Cell(row, 2).Style.Font.Bold = true;
                            row++;

                            ws.Cell(row, 2).Value = "Produto";
                            ws.Cell(row, 3).Value = "Descrição";
                            ws.Cell(row, 4).Value = "Marca";
                            ws.Cell(row, 5).Value = "Categoria";
                            ws.Cell(row, 6).Value = "Fornecedor";
                            ws.Cell(row, 7).Value = "Preço Orig.";
                            ws.Cell(row, 8).Value = "Preço Final";

                            var itemHeaderRange = ws.Range(row, 2, row, 8);
                            itemHeaderRange.Style.Font.Bold = true;
                            itemHeaderRange.Style.Fill.BackgroundColor = XLColor.LightGray;

                            row++;

                            foreach (var item in itens)
                            {
                                string nomeFornecedor = ObterNomeParceiro(item.IdFornecedor);

                                ws.Cell(row, 2).Value = item.IdProduto;
                                ws.Cell(row, 3).Value = item.NomeProduto;
                                ws.Cell(row, 4).Value = item.MarcaProduto;
                                ws.Cell(row, 5).Value = item.CategoriaProduto;
                                ws.Cell(row, 6).Value = nomeFornecedor;
                                ws.Cell(row, 7).Value = item.PrecoOriginal;
                                ws.Cell(row, 8).Value = item.PrecoFinalNegociado;

                                // Formatar valores
                                ws.Cell(row, 7).Style.NumberFormat.Format = "R$ #,##0.00";
                                ws.Cell(row, 8).Style.NumberFormat.Format = "R$ #,##0.00";

                                row++;
                            }

                            row++; // Linha em branco entre vendas
                        }
                    }

                    // ============================================================
                    // TOTALIZADORES
                    // ============================================================
                    row++;
                    ws.Cell(row, 1).Value = "TOTALIZADORES:";
                    ws.Cell(row, 1).Style.Font.Bold = true;
                    ws.Cell(row, 1).Style.Font.FontSize = 12;

                    row++;
                    ws.Cell(row, 1).Value = "Total de Vendas:";
                    ws.Cell(row, 1).Style.Font.Bold = true;
                    ws.Cell(row, 2).Value = _vendasCarregadas.Count;
                    ws.Cell(row, 2).Style.Font.Bold = true;

                    row++;
                    ws.Cell(row, 1).Value = "Total Arrecadado:";
                    ws.Cell(row, 1).Style.Font.Bold = true;
                    ws.Cell(row, 2).Value = _vendasCarregadas.Sum(v => v.ValorTotalFinal);
                    ws.Cell(row, 2).Style.NumberFormat.Format = "R$ #,##0.00";
                    ws.Cell(row, 2).Style.Font.Bold = true;

                    // ============================================================
                    // FORMATAÇÃO FINAL
                    // ============================================================
                    ws.Columns().AdjustToContents();
                    ws.RangeUsed().SetAutoFilter();
                    ws.SheetView.FreezeRows(4); // Congelar até a linha de cabeçalho

                    // ============================================================
                    // SALVAR ARQUIVO
                    // ============================================================
                    var dialog = new SaveFileDialog
                    {
                        Filter = "Excel (*.xlsx)|*.xlsx",
                        FileName = $"Relatorio_Vendas_{mes:00}_{ano}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                        Title = "Salvar Relatório de Vendas"
                    };

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        wb.SaveAs(dialog.FileName);

                        var result = MessageBox.Show(
                            $"Relatório exportado com sucesso!\n\n" +
                            $"Arquivo: {dialog.FileName}\n\n" +
                            "Deseja abrir o arquivo agora?",
                            "Sucesso",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = dialog.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar relatório:\n\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // BOTÃO: FECHAR
        // ============================================================
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
