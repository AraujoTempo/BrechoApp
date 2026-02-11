using System;
using System.Windows.Forms;
using BrechoApp.Data;
using ClosedXML.Excel;

namespace BrechoApp
{
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
                    MessageBox.Show("Não há produtos disponíveis para exportar.");
                    return;
                }

                using (var wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Produtos Disponíveis");

                    // Cabeçalho
                    ws.Cell(1, 1).Value = "Código Produto";
                    ws.Cell(1, 2).Value = "Nome";
                    ws.Cell(1, 3).Value = "Marca";
                    ws.Cell(1, 4).Value = "Categoria";
                    ws.Cell(1, 5).Value = "Tamanho/Cor";
                    ws.Cell(1, 6).Value = "Observação";
                    ws.Cell(1, 7).Value = "Preço Venda";
                    ws.Cell(1, 8).Value = "Status";
                    ws.Cell(1, 9).Value = "Parceiro";              // <<< atualizado
                    ws.Cell(1, 10).Value = "Lote";
                    ws.Cell(1, 11).Value = "Data Criação";
                    ws.Cell(1, 12).Value = "Última Atualização";

                    ws.Range(1, 1, 1, 12).Style.Font.Bold = true;

                    int row = 2;

                    foreach (var p in produtos)
                    {
                        ws.Cell(row, 1).Value = p.CodigoProduto;
                        ws.Cell(row, 2).Value = p.NomeDoItem;
                        ws.Cell(row, 3).Value = p.MarcaDoItem;
                        ws.Cell(row, 4).Value = p.CategoriaDoItem;
                        ws.Cell(row, 5).Value = p.TamanhoCorDoItem;
                        ws.Cell(row, 6).Value = p.ObservacaoDoItem;
                        ws.Cell(row, 7).Value = p.PrecoVendaDoItem;
                        ws.Cell(row, 8).Value = p.StatusDoProduto;
                        ws.Cell(row, 9).Value = p.CodigoParceiro;     // <<< atualizado
                        ws.Cell(row, 10).Value = p.CodigoLoteRecebimento;
                        ws.Cell(row, 11).Value = p.DataCriacao.ToString("dd/MM/yyyy HH:mm");
                        ws.Cell(row, 12).Value = p.UltimaAtualizacao.ToString("dd/MM/yyyy HH:mm");

                        row++;
                    }

                    ws.Columns().AdjustToContents();

                    var dialog = new SaveFileDialog
                    {
                        Filter = "Excel (*.xlsx)|*.xlsx",
                        FileName = "Produtos_Disponiveis.xlsx"
                    };

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        wb.SaveAs(dialog.FileName);
                        MessageBox.Show("Arquivo Excel gerado com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar Excel: " + ex.Message);
            }
        }
    }
}

