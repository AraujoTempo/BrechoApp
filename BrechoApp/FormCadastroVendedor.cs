using System;
using System.Windows.Forms;
using BrechoApp.Data;
using BrechoApp.Models;

namespace BrechoApp
{
    /// <summary>
    /// Tela de cadastro de vendedores.
    /// Estrutura semelhante ao cadastro de fornecedor.
    /// </summary>
    public partial class FormCadastroVendedor : Form
    {
        private readonly VendedorRepository _repo = new VendedorRepository();
        private Vendedor vendedorAtual;

        public FormCadastroVendedor()
        {
            InitializeComponent();
            CarregarVendedores();
            GerarNovoCodigo();
        }

        /// <summary>
        /// Gera automaticamente o próximo código de vendedor (V-0001, V-0002...).
        /// </summary>
        private void GerarNovoCodigo()
        {
            txtCodigo.Text = _repo.GerarCodigo();
        }

        /// <summary>
        /// Carrega todos os vendedores no grid.
        /// </summary>
        private void CarregarVendedores()
        {
            dgvVendedores.DataSource = _repo.ListarTodos();
        }

        /// <summary>
        /// Salva ou atualiza um vendedor.
        /// </summary>
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var vendedor = new Vendedor
            {
                CodigoVendedor = txtCodigo.Text,
                Nome = txtNome.Text,
                CPF = txtCPF.Text,
                Telefone = txtTelefone.Text,
                Email = txtEmail.Text,
                Endereco = txtEndereco.Text,

                Banco = txtBanco.Text,
                Agencia = txtAgencia.Text,
                Conta = txtConta.Text,

                ComissaoVendedor = decimal.TryParse(txtComissao.Text, out var c) ? c : 0,
                Observacao = txtObservacao.Text,

                // Como o checkbox foi removido, o vendedor será sempre ativo
                Ativo = true
            };

            if (vendedorAtual == null)
                _repo.Inserir(vendedor);
            else
                _repo.Atualizar(vendedor);

            MessageBox.Show("Vendedor salvo com sucesso!");

            LimparCampos();
            CarregarVendedores();
            GerarNovoCodigo();
        }

        /// <summary>
        /// Carrega os dados do vendedor selecionado no grid.
        /// </summary>
        private void dgvVendedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            vendedorAtual = (Vendedor)dgvVendedores.Rows[e.RowIndex].DataBoundItem;

            txtCodigo.Text = vendedorAtual.CodigoVendedor;
            txtNome.Text = vendedorAtual.Nome;
            txtCPF.Text = vendedorAtual.CPF;
            txtTelefone.Text = vendedorAtual.Telefone;
            txtEmail.Text = vendedorAtual.Email;
            txtEndereco.Text = vendedorAtual.Endereco;

            txtBanco.Text = vendedorAtual.Banco;
            txtAgencia.Text = vendedorAtual.Agencia;
            txtConta.Text = vendedorAtual.Conta;

            txtComissao.Text = vendedorAtual.ComissaoVendedor.ToString();
            txtObservacao.Text = vendedorAtual.Observacao;

            // Linha removida: chkAutoriza não existe mais
            // chkAutoriza.Checked = vendedorAtual.Ativo;
        }

        /// <summary>
        /// Prepara o formulário para um novo cadastro.
        /// </summary>
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            LimparCampos();
            vendedorAtual = null;
            GerarNovoCodigo();
        }

        /// <summary>
        /// Limpa todos os campos do formulário.
        /// </summary>
        private void LimparCampos()
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            txtEndereco.Text = "";

            txtBanco.Text = "";
            txtAgencia.Text = "";
            txtConta.Text = "";

            txtPix.Text = "";
            txtSaldo.Text = "";
            txtComissao.Text = "0";
            txtObservacao.Text = "";

            // Linha removida: chkAutoriza não existe mais
            // chkAutoriza.Checked = true;
        }

        /// <summary>
        /// Botão "Gerar Venda" — placeholder.
        /// Apenas abre uma mensagem e retorna.
        /// </summary>
        private void btnGerarVenda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rotina de venda ainda será implementada.");
        }
    }
}



