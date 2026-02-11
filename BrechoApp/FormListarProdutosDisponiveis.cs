using BrechoApp.Data;
using BrechoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace BrechoApp
{
    public partial class FormListarProdutosDisponiveis : Form
    {
        private readonly ProdutoRepository _repoProduto = new ProdutoRepository();

        // Lista completa de produtos
        private List<Produto> _todosProdutos = new List<Produto>();

        // Lista filtrada (busca)
        private List<Produto> _produtosFiltrados = new List<Produto>();

        // Controle de paginação
        private int _paginaAtual = 1;
        private const int _itensPorPagina = 10;

        public FormListarProdutosDisponiveis()
        {
            InitializeComponent();
            ConfigurarPlaceholder();
            CarregarProdutos();
        }

        // ============================================================
        //  CONFIGURAR PLACEHOLDER MANUAL (WinForms não suporta nativo)
        // ============================================================
        private void ConfigurarPlaceholder()
        {
            txtBuscar.Text = "Buscar produto...";
            txtBuscar.ForeColor = Color.Gray;

            txtBuscar.Enter += (s, e) =>
            {
                if (txtBuscar.Text == "Buscar produto...")
                {
                    txtBuscar.Text = "";
                    txtBuscar.ForeColor = Color.Black;
                }
            };

            txtBuscar.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    txtBuscar.Text = "Buscar produto...";
                    txtBuscar.ForeColor = Color.Gray;
                }
            };
        }

        // ============================================================
        //  CARREGAR TODOS OS PRODUTOS DISPONÍVEIS
        // ============================================================
        private void CarregarProdutos()
        {
            _todosProdutos = _repoProduto.ListarProdutosDisponiveis();
            AplicarFiltro();
        }

        // ============================================================
        //  APLICAR FILTRO DE BUSCA
        // ============================================================
        private void AplicarFiltro()
        {
            string termo = txtBuscar.Text.Trim().ToLower();

            // Se estiver no placeholder, não filtra nada
            if (termo == "buscar produto...")
                termo = "";

            _produtosFiltrados = _todosProdutos
                .Where(p =>
                    p.CodigoProduto.ToLower().Contains(termo) ||
                    p.NomeDoItem.ToLower().Contains(termo) ||
                    p.MarcaDoItem.ToLower().Contains(termo) ||
                    p.CategoriaDoItem.ToLower().Contains(termo) ||
                    p.TamanhoCorDoItem.ToLower().Contains(termo)
                )
                .ToList();

            _paginaAtual = 1;
            AtualizarGrid();
        }

        // ============================================================
        //  ATUALIZAR GRID COM PAGINAÇÃO
        // ============================================================
        private void AtualizarGrid()
        {
            dgvProdutos.Rows.Clear();

            var pagina = _produtosFiltrados
                .Skip((_paginaAtual - 1) * _itensPorPagina)
                .Take(_itensPorPagina)
                .ToList();

            foreach (var p in pagina)
            {
                dgvProdutos.Rows.Add(
                    p.CodigoProduto,
                    p.NomeDoItem,
                    p.MarcaDoItem,
                    p.CategoriaDoItem,
                    p.TamanhoCorDoItem,
                    p.PrecoVendaDoItem.ToString("N2"),
                    p.StatusDoProduto
                );
            }

            lblPagina.Text = $"Página {_paginaAtual} / {Math.Max(1, TotalPaginas())}";
        }

        private int TotalPaginas()
        {
            return (int)Math.Ceiling((double)_produtosFiltrados.Count / _itensPorPagina);
        }

        // ============================================================
        //  BOTÃO PRÓXIMO
        // ============================================================
        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (_paginaAtual < TotalPaginas())
            {
                _paginaAtual++;
                AtualizarGrid();
            }
        }

        // ============================================================
        //  BOTÃO ANTERIOR
        // ============================================================
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (_paginaAtual > 1)
            {
                _paginaAtual--;
                AtualizarGrid();
            }
        }

        // ============================================================
        //  BUSCA DINÂMICA
        // ============================================================
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Evita filtrar enquanto está no placeholder
            if (txtBuscar.Text == "Buscar produto...")
                return;

            AplicarFiltro();
        }
    }
}

