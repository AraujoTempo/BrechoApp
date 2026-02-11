using BrechoApp.Data;
using BrechoApp.Models;
using ClosedXML.Excel;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BrechoApp
{
    public partial class FormProduto : Form
    {
        private readonly ProdutoRepository _produtoRepo = new ProdutoRepository();
        private readonly LoteRecebimentoRepository _loteRepo = new LoteRecebimentoRepository();

        private string _produtoSelecionado = null;

        public FormProduto()
        {
            InitializeComponent();
            CarregarLotes();
        }

        // ============================================================
        //  CARREGAR LOTES (AGORA POR PARCEIRO)
        // ============================================================
        private void CarregarLotes()
        {
            // Aqui você deve substituir pelos códigos reais dos parceiros
            var parceiros = new[] { "PN1", "PN2", "PN3" };

            var lotes = parceiros
                .SelectMany(p => _loteRepo.ListarPorParceiro(p))
                .ToList();

            comboLote.DisplayMember = "CodigoLoteRecebimento";
            comboLote.ValueMember = "CodigoLoteRecebimento";
            comboLote.DataSource = lotes;
        }

        private void comboLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboLote.SelectedValue != null)
                CarregarProdutosDoLote(comboLote.SelectedValue.ToString());
        }

        // ============================================================
        //  CARREGAR PRODUTOS DO LOTE (AGORA POR PARCEIRO)
        // ============================================================
        private void CarregarProdutosDoLote(string codigoLote)
        {
            var parceiros = new[] { "PN1", "PN2", "PN3" };

            var produtos = parceiros
                .SelectMany(p => _produtoRepo.ListarPorParceiro(p))
                .Where(prod => prod.CodigoLoteRecebimento == codigoLote)
                .ToList();

            gridProdutos.DataSource = produtos;
        }
        // ============================================================
        //  LIMPAR CAMPOS
        // ============================================================
        private void LimparCampos()
        {
            _produtoSelecionado = null;
            txtNome.Clear();
            txtMarca.Clear();
            txtDescricao.Clear();
            txtCategoria.Clear();
            txtTamanhoCor.Clear();
            txtPreco.Clear();
            txtStatus.Clear();
        }

        // ============================================================
        //  SALVAR PRODUTO (AGORA USANDO CodigoParceiro)
        // ============================================================
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (comboLote.SelectedValue == null)
            {
                MessageBox.Show("Selecione um lote.");
                return;
            }

            if (txtDescricao.Text.Length > 60)
            {
                MessageBox.Show("A descrição deve ter no máximo 60 caracteres.");
                return;
            }

            // Aqui você deve definir qual parceiro está sendo usado
            // Pode vir de login, seleção, etc.
            string parceiroAtual = "PN1";

            var produto = new Produto
            {
                CodigoProduto = _produtoSelecionado ?? Guid.NewGuid().ToString(),
                CodigoLoteRecebimento = comboLote.SelectedValue.ToString(),
                CodigoParceiro = parceiroAtual,

                NomeDoItem = txtNome.Text,
                MarcaDoItem = txtMarca.Text,
                ObservacaoDoItem = txtDescricao.Text,
                CategoriaDoItem = txtCategoria.Text,
                TamanhoCorDoItem = txtTamanhoCor.Text,

                PrecoVendaDoItem = double.TryParse(txtPreco.Text, out var preco) ? preco : 0,
                StatusDoProduto = txtStatus.Text,

                DataCriacao = DateTime.Now,
                UltimaAtualizacao = DateTime.Now
            };

            if (_produtoSelecionado == null)
                _produtoRepo.CriarProduto(produto);
            else
                _produtoRepo.AtualizarProduto(produto);

            CarregarProdutosDoLote(comboLote.SelectedValue.ToString());
            LimparCampos();
        }

        // ============================================================
        //  SELECIONAR PRODUTO NO GRID
        // ============================================================
        private void gridProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = gridProdutos.Rows[e.RowIndex];

            _produtoSelecionado = row.Cells["CodigoProduto"].Value.ToString();

            txtNome.Text = row.Cells["NomeDoItem"].Value.ToString();
            txtMarca.Text = row.Cells["MarcaDoItem"].Value.ToString();
            txtDescricao.Text = row.Cells["ObservacaoDoItem"].Value.ToString();
            txtCategoria.Text = row.Cells["CategoriaDoItem"].Value.ToString();
            txtTamanhoCor.Text = row.Cells["TamanhoCorDoItem"].Value.ToString();
            txtPreco.Text = row.Cells["PrecoVendaDoItem"].Value.ToString();
            txtStatus.Text = row.Cells["StatusDoProduto"].Value.ToString();
        }

        // ============================================================
        //  EXCLUIR PRODUTO (STATUS = INATIVO)
        // ============================================================
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_produtoSelecionado == null)
            {
                MessageBox.Show("Selecione um produto.");
                return;
            }

            _produtoRepo.AtualizarStatus(_produtoSelecionado, "Inativo");

            CarregarProdutosDoLote(comboLote.SelectedValue.ToString());
            LimparCampos();
        }
        // ============================================================
        //  EXPORTAR EXCEL (AGORA USANDO PARCEIRO)
        // ============================================================
        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (comboLote.SelectedValue == null)
            {
                MessageBox.Show("Selecione um lote.");
                return;
            }

            var parceiros = new[] { "PN1", "PN2", "PN3" };

            var produtos = parceiros
                .SelectMany(p => _produtoRepo.ListarPorParceiro(p))
                .Where(prod => prod.CodigoLoteRecebimento == comboLote.SelectedValue.ToString())
                .ToList();

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Produtos do Lote");

                ws.Cell(1, 1).Value = "Código Produto";
                ws.Cell(1, 2).Value = "Nome";
                ws.Cell(1, 3).Value = "Marca";
                ws.Cell(1, 4).Value = "Descrição";
                ws.Cell(1, 5).Value = "Categoria";
                ws.Cell(1, 6).Value = "Tamanho/Cor";
                ws.Cell(1, 7).Value = "Preço Venda";
                ws.Cell(1, 8).Value = "Status";

                int row = 2;
                foreach (var p in produtos)
                {
                    ws.Cell(row, 1).Value = p.CodigoProduto;
                    ws.Cell(row, 2).Value = p.NomeDoItem;
                    ws.Cell(row, 3).Value = p.MarcaDoItem;
                    ws.Cell(row, 4).Value = p.ObservacaoDoItem;
                    ws.Cell(row, 5).Value = p.CategoriaDoItem;
                    ws.Cell(row, 6).Value = p.TamanhoCorDoItem;
                    ws.Cell(row, 7).Value = p.PrecoVendaDoItem;
                    ws.Cell(row, 8).Value = p.StatusDoProduto;
                    row++;
                }

                var dialog = new SaveFileDialog
                {
                    Filter = "Excel (*.xlsx)|*.xlsx",
                    FileName = $"Lote_{comboLote.SelectedValue}.xlsx"
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(dialog.FileName);
                    MessageBox.Show("Arquivo Excel gerado com sucesso!");
                }
            }
        }
    }
}
