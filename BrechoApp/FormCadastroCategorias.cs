using BrechoApp.Data;
using BrechoApp.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrechoApp
{
    public partial class FormCadastroCategorias : Form
    {
        private readonly CategoriaRepository _repo = new CategoriaRepository();
        private Categoria? _categoriaSelecionada = null;

        public FormCadastroCategorias()
        {
            InitializeComponent();
            CarregarCategorias();
        }

        private void CarregarCategorias()
        {
            var categorias = _repo.ListarTodas();
            dgvCategorias.DataSource = categorias;

            // Verificar se há colunas E se as colunas esperadas existem
            if (dgvCategorias.Columns.Count > 0 && 
                dgvCategorias.Columns["Id"] != null &&
                dgvCategorias.Columns["NomeCategoria"] != null &&
                dgvCategorias.Columns["DataCriacao"] != null)
            {
                dgvCategorias.Columns["Id"].Visible = false;
                dgvCategorias.Columns["NomeCategoria"].HeaderText = "Categoria";
                dgvCategorias.Columns["NomeCategoria"].Width = 300;
                dgvCategorias.Columns["DataCriacao"].HeaderText = "Data de Criação";
                dgvCategorias.Columns["DataCriacao"].Width = 150;
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomeCategoria.Text))
            {
                MessageBox.Show("Digite o nome da categoria.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeCategoria.Focus();
                return;
            }

            if (_repo.Existe(txtNomeCategoria.Text.Trim()))
            {
                MessageBox.Show("Esta categoria já existe.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeCategoria.Focus();
                return;
            }

            var categoria = new Categoria
            {
                NomeCategoria = txtNomeCategoria.Text.Trim(),
                DataCriacao = DateTime.Now
            };

            _repo.Adicionar(categoria);
            MessageBox.Show("Categoria adicionada com sucesso!", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtNomeCategoria.Clear();
            txtNomeCategoria.Focus();
            CarregarCategorias();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (_categoriaSelecionada == null)
            {
                MessageBox.Show("Selecione uma categoria para editar.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNomeCategoria.Text))
            {
                MessageBox.Show("Digite o nome da categoria.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeCategoria.Focus();
                return;
            }

            if (_repo.Existe(txtNomeCategoria.Text.Trim(), _categoriaSelecionada.Id))
            {
                MessageBox.Show("Já existe outra categoria com este nome.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeCategoria.Focus();
                return;
            }

            _categoriaSelecionada.NomeCategoria = txtNomeCategoria.Text.Trim();
            _repo.Atualizar(_categoriaSelecionada);

            MessageBox.Show("Categoria atualizada com sucesso!", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtNomeCategoria.Clear();
            _categoriaSelecionada = null;
            CarregarCategorias();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_categoriaSelecionada == null)
            {
                MessageBox.Show("Selecione uma categoria para excluir.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                $"Deseja realmente excluir a categoria '{_categoriaSelecionada.NomeCategoria}'?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                _repo.Excluir(_categoriaSelecionada.Id);
                MessageBox.Show("Categoria excluída com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNomeCategoria.Clear();
                _categoriaSelecionada = null;
                CarregarCategorias();
            }
        }

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {
                _categoriaSelecionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                txtNomeCategoria.Text = _categoriaSelecionada.NomeCategoria;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
