using System;
using System.Windows.Forms;
using ClosedXML.Excel;
using BrechoApp.Data;

namespace BrechoApp
{
    /// <summary>
    /// Menu de Relatórios Gerenciais.
    /// Centraliza o acesso aos diferentes tipos de relatórios do sistema.
    /// </summary>
    public partial class FormRelatoriosGerenciais : Form
    {
        public FormRelatoriosGerenciais()
        {
            InitializeComponent();
        }

        // ============================================================
        // BOTÃO: RELATÓRIO DE VENDAS DO MÊS
        // Abre o relatório de vendas mensal
        // ============================================================
        private void btnRelatorioVendasMes_Click(object sender, EventArgs e)
        {
            var form = new FormRelatorioVendasMes();
            form.ShowDialog();
        }

        // ============================================================
        // BOTÃO: RELATÓRIO ANALÍTICO DE VENDAS
        // Abre o relatório analítico recém-implementado
        // ============================================================
        private void btnRelatorioAnaliticoVendas_Click(object sender, EventArgs e)
        {
            var form = new FormRelatorioAnaliticoVendas();
            form.ShowDialog();
        }

        // ============================================================
        // BOTÃO: LISTAR PRODUTOS DISPONÍVEIS
        // Exporta produtos disponíveis para Excel
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
                    ws.Cell(1, 7).Value = "Preço Venda";
                    ws.Cell(1, 8).Value = "Status";
                    ws.Cell(1, 9).Value = "Parceiro";
                    ws.Cell(1, 10).Value = "Lote";
                    ws.Cell(1, 11).Value = "Data Criação";
                    ws.Cell(1, 12).Value = "Última Atualização";

                    // Formatação do cabeçalho
                    var headerRange = ws.Range(1, 1, 1, 12);
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
                        ws.Cell(row, 7).Value = p.PrecoVendaDoItem;
                        ws.Cell(row, 8).Value = p.StatusDoProduto;
                        ws.Cell(row, 9).Value = p.CodigoParceiro;
                        ws.Cell(row, 10).Value = p.CodigoLoteRecebimento;
                        ws.Cell(row, 11).Value = p.DataCriacao.ToString("dd/MM/yyyy HH:mm");
                        ws.Cell(row, 12).Value = p.UltimaAtualizacao.ToString("dd/MM/yyyy HH:mm");

                        // Formatação dos preços
                        ws.Cell(row, 7).Style.NumberFormat.Format = "R$ #,##0.00";

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
        // BOTÃO: RELATÓRIO DE CAIXA
        // Ainda não implementado
        // ============================================================
        private void btnRelatorioCaixa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Relatório de Caixa em desenvolvimento.",
                "Em Desenvolvimento",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ============================================================
        // BOTÃO: RELATÓRIO DE LUCRO
        // Ainda não implementado
        // ============================================================
        private void btnRelatorioLucro_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Relatório de Lucro em desenvolvimento.",
                "Em Desenvolvimento",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ============================================================
        // BOTÃO: RELATÓRIO FINANCEIRO
        // Ainda não implementado
        // ============================================================
        private void btnRelatorioFinanceiro_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Relatório Financeiro em desenvolvimento.",
                "Em Desenvolvimento",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ============================================================
        // BOTÃO: RELATÓRIO DE COMISSÕES
        // Ainda não implementado
        // ============================================================
        private void btnRelatorioComissoes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Relatório de Comissões em desenvolvimento.",
                "Em Desenvolvimento",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ============================================================
        // BOTÃO: RELATÓRIO DE PRODUTOS DEVOLVIDOS
        // Ainda não implementado
        // ============================================================
        private void btnRelatorioProdutosDevolvidos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Relatório de Produtos Devolvidos em desenvolvimento.",
                "Em Desenvolvimento",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ============================================================
        // BOTÃO: RELATÓRIO DE ESTOQUE
        // Ainda não implementado
        // ============================================================
        private void btnRelatorioEstoque_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Relatório de Estoque em desenvolvimento.",
                "Em Desenvolvimento",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ============================================================
        // BOTÃO: RELATÓRIO DE FORNECEDORES
        // Ainda não implementado
        // ============================================================
        private void btnRelatorioFornecedores_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Relatório de Fornecedores em desenvolvimento.",
                "Em Desenvolvimento",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ============================================================
        // BOTÃO: VOLTAR
        // Fecha o formulário
        // ============================================================
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


