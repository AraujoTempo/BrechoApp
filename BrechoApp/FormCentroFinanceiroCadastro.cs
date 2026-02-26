using System;
using System.Windows.Forms;
using BrechoApp.Data;
using BrechoApp.Models;

namespace BrechoApp
{
    public partial class FormCentroFinanceiroCadastro : Form
    {
        private readonly CentroFinanceiroRepository _repo;
        private int? _idCentro = null;

        public FormCentroFinanceiroCadastro()
        {
            InitializeComponent();
            _repo = new CentroFinanceiroRepository();
        }

        public FormCentroFinanceiroCadastro(int idCentro)
        {
            InitializeComponent();
            _repo = new CentroFinanceiroRepository();
            _idCentro = idCentro;

            CarregarDados();
        }

        private void CarregarDados()
        {
            var centro = _repo.BuscarPorId(_idCentro.Value);

            if (centro == null)
            {
                MessageBox.Show("Centro financeiro não encontrado.");
                this.Close();
                return;
            }

            txtNome.Text = centro.Nome;
            cboTipo.SelectedItem = centro.Tipo;
            txtSaldoInicial.Text = centro.SaldoAtual.ToString();
            chkAtivo.Checked = centro.Ativo;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o nome.");
                return;
            }

            if (cboTipo.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione o tipo.");
                return;
            }

            if (!decimal.TryParse(txtSaldoInicial.Text, out decimal saldo))
            {
                MessageBox.Show("Saldo inválido.");
                return;
            }

            var centro = new CentroFinanceiro
            {
                Nome = txtNome.Text.Trim(),
                Tipo = cboTipo.SelectedItem.ToString(),
                SaldoAtual = saldo,
                Ativo = chkAtivo.Checked
            };

            if (_idCentro == null)
            {
                _repo.Inserir(centro);
            }
            else
            {
                centro.IdCentroFinanceiro = _idCentro.Value;
                _repo.Atualizar(centro);
            }

            MessageBox.Show("Registro salvo com sucesso.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}