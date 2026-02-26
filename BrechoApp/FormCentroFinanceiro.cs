using System;
using System.Windows.Forms;
using BrechoApp.Data;

namespace BrechoApp
{
    public partial class FormCentroFinanceiro : Form
    {
        private readonly CentroFinanceiroRepository _repository;

        public FormCentroFinanceiro()
        {
            InitializeComponent();
            _repository = new CentroFinanceiroRepository();
            CarregarCentros();
        }

        // ============================================================
        // CARREGAR LISTA
        // ============================================================
        private void CarregarCentros()
        {
            dgvCentros.Rows.Clear();

            var lista = _repository.Listar();

            foreach (var c in lista)
            {
                dgvCentros.Rows.Add(
                    c.IdCentroFinanceiro,
                    c.Nome,
                    c.Tipo,
                    c.SaldoAtual.ToString("C2"),
                    c.Ativo ? "Sim" : "Não"
                );
            }
        }

        // ============================================================
        // BOTÃO: NOVO
        // ============================================================
        private void btnNovo_Click(object sender, EventArgs e)
        {
            var form = new FormCentroFinanceiroCadastro();
            form.ShowDialog();
            CarregarCentros();
        }

        // ============================================================
        // BOTÃO: EDITAR
        // ============================================================
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCentros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um registro para editar.");
                return;
            }

            int id = Convert.ToInt32(dgvCentros.SelectedRows[0].Cells[0].Value);

            var form = new FormCentroFinanceiroCadastro(id);
            form.ShowDialog();
            CarregarCentros();
        }

        // ============================================================
        // BOTÃO: EXCLUIR
        // ============================================================
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvCentros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um registro para excluir.");
                return;
            }

            int id = Convert.ToInt32(dgvCentros.SelectedRows[0].Cells[0].Value);

            if (MessageBox.Show("Confirma exclusão?", "Excluir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _repository.Excluir(id);
                CarregarCentros();
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