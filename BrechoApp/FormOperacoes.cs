using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using BrechoApp.Data;
using BrechoApp.Utils;
using ClosedXML.Excel;

namespace BrechoApp
{
    /// <summary>
    /// Tela de operações do sistema.
    /// Centraliza exportações, relatórios e operações administrativas.
    /// </summary>
    public partial class FormOperacoes : Form
    {
        public FormOperacoes()
        {
            InitializeComponent();
        }

        // ============================================================
        // BOTÃO: EXPORTAR PRODUTOS DISPONÍVEIS PARA EXCEL
        //
        // Gera uma planilha Excel contendo todos os produtos com
        // status "Disponível". Usa ClosedXML para criar o arquivo.
        // ============================================================
        private void btnListarProdutosDisponiveis_Click(object sender, EventArgs e)
        {
            try
            {
                var repo = new ProdutoRepository();
                var produtos = repo.ListarProdutosDisponiveis();

                if (produtos.Count == 0)
                {
                    MessageBox.Show("Não há produtos disponíveis para exportar.", 
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Produtos Disponíveis");

                    // ============================================================
                    // CABEÇALHO
                    // ============================================================
                    ws.Cell(1, 1).Value = "Código Produto";
                    ws.Cell(1, 2).Value = "Nome";
                    ws.Cell(1, 3).Value = "Marca";
                    ws.Cell(1, 4).Value = "Categoria";
                    ws.Cell(1, 5).Value = "Tamanho/Cor";
                    ws.Cell(1, 6).Value = "Observação";
                    ws.Cell(1, 7).Value = "Preço Sugerido";
                    ws.Cell(1, 8).Value = "Preço Venda";
                    ws.Cell(1, 9).Value = "Status";
                    ws.Cell(1, 10).Value = "Parceiro";
                    ws.Cell(1, 11).Value = "Lote";
                    ws.Cell(1, 12).Value = "Data Criação";
                    ws.Cell(1, 13).Value = "Última Atualização";

                    // Formatação do cabeçalho
                    var headerRange = ws.Range(1, 1, 1, 13);
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.BackgroundColor = XLColor.LightBlue;
                    headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    // ============================================================
                    // DADOS
                    // ============================================================
                    int row = 2;

                    foreach (var p in produtos)
                    {
                        ws.Cell(row, 1).Value = p.CodigoProduto;
                        ws.Cell(row, 2).Value = p.NomeDoItem;
                        ws.Cell(row, 3).Value = p.MarcaDoItem;
                        ws.Cell(row, 4).Value = p.CategoriaDoItem;
                        ws.Cell(row, 5).Value = p.TamanhoCorDoItem;
                        ws.Cell(row, 6).Value = p.ObservacaoDoItem ?? "";
                        ws.Cell(row, 7).Value = p.PrecoSugeridoDoItem;
                        ws.Cell(row, 8).Value = p.PrecoVendaDoItem;
                        ws.Cell(row, 9).Value = p.StatusDoProduto;
                        ws.Cell(row, 10).Value = p.CodigoParceiro;
                        ws.Cell(row, 11).Value = p.CodigoLoteRecebimento;
                        ws.Cell(row, 12).Value = p.DataCriacao.ToString("dd/MM/yyyy HH:mm");
                        ws.Cell(row, 13).Value = p.UltimaAtualizacao.ToString("dd/MM/yyyy HH:mm");

                        // Formatação dos preços
                        ws.Cell(row, 7).Style.NumberFormat.Format = "R$ #,##0.00";
                        ws.Cell(row, 8).Style.NumberFormat.Format = "R$ #,##0.00";

                        row++;
                    }

                    // ============================================================
                    // FORMATAÇÃO FINAL
                    // ============================================================
                    // Ajustar largura das colunas
                    ws.Columns().AdjustToContents();

                    // Adicionar filtros
                    ws.RangeUsed().SetAutoFilter();

                    // Congelar primeira linha
                    ws.SheetView.FreezeRows(1);

                    // Adicionar rodapé com total de produtos
                    int lastRow = row;
                    ws.Cell(lastRow, 1).Value = "TOTAL DE PRODUTOS:";
                    ws.Cell(lastRow, 1).Style.Font.Bold = true;
                    ws.Cell(lastRow, 2).Value = produtos.Count;
                    ws.Cell(lastRow, 2).Style.Font.Bold = true;

                    // ============================================================
                    // SALVAR ARQUIVO
                    // ============================================================
                    var dialog = new SaveFileDialog
                    {
                        Filter = "Excel (*.xlsx)|*.xlsx",
                        FileName = $"Produtos_Disponiveis_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                        Title = "Salvar Lista de Produtos Disponíveis"
                    };

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        wb.SaveAs(dialog.FileName);
                        
                        var result = MessageBox.Show(
                            $"Arquivo Excel gerado com sucesso!\n\n" +
                            $"Total de produtos: {produtos.Count}\n" +
                            $"Local: {dialog.FileName}\n\n" +
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
                MessageBox.Show($"Erro ao gerar arquivo Excel:\n\n{ex.Message}", 
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // HELPER: ABRIR ARQUIVO DE RELATÓRIO
        // ============================================================
        private void AbrirRelatorio(string reportPath)
        {
            if (File.Exists(reportPath))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = reportPath,
                    UseShellExecute = true
                });
            }
        }

        // ============================================================
        // BOTÃO: DIAGNÓSTICO DE PRODUTOS
        //
        // Executa verificação de inconsistências entre ItemLote e Produtos
        // e gera um relatório detalhado.
        // ============================================================
        private void btnDiagnosticoProdutos_Click(object sender, EventArgs e)
        {
            try
            {
                // Executar diagnóstico
                var inconsistencias = DiagnosticoProdutos.VerificarInconsistencias();
                var produtosIguais = DiagnosticoProdutos.VerificarProdutosComPrecosIguais();

                // Gerar relatório
                string reportPath = DiagnosticoProdutos.GerarRelatorio();

                // Mostrar resultado
                string mensagem = $"Diagnóstico concluído!\n\n" +
                                 $"Inconsistências encontradas: {inconsistencias.Count}\n" +
                                 $"Produtos com preços iguais: {produtosIguais.Count}\n\n" +
                                 $"Relatório salvo em:\n{reportPath}\n\n";

                if (inconsistencias.Count > 0)
                {
                    mensagem += "ATENÇÃO: Foram encontradas inconsistências!\n\n";
                    
                    var result = MessageBox.Show(
                        mensagem + "Deseja tentar corrigir automaticamente as inconsistências?\n\n" +
                        "AVISO: Esta operação irá modificar a tabela Produtos no banco de dados.",
                        "Diagnóstico de Produtos",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        int corrigidos = DiagnosticoProdutos.CorrigirInconsistencias();
                        
                        MessageBox.Show(
                            $"Correção concluída!\n\n" +
                            $"Produtos corrigidos: {corrigidos}\n\n" +
                            "Execute o diagnóstico novamente para verificar se ainda há inconsistências.",
                            "Correção Concluída",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else if (result == DialogResult.No)
                    {
                        // Abrir o relatório
                        AbrirRelatorio(reportPath);
                    }
                }
                else
                {
                    var result = MessageBox.Show(
                        mensagem + "Nenhuma inconsistência detectada.\n\n" +
                        "Deseja abrir o relatório completo?",
                        "Diagnóstico de Produtos",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        AbrirRelatorio(reportPath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao executar diagnóstico:\n\n{ex.Message}", 
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

