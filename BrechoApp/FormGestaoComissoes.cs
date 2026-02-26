using System;
using System.Windows.Forms;
using BrechoApp.Services;
using BrechoApp.Models;

namespace BrechoApp
{
    public partial class FormGestaoComissoes : Form
    {
        private readonly ComissaoService _service;

        public FormGestaoComissoes()
        {
            InitializeComponent();
            _service = new ComissaoService();

            CarregarMeses();
            CarregarAnos();
        }

        private void CarregarMeses()
        {
            cmbMes.Items.Clear();
            for (int i = 1; i <= 12; i++)
                cmbMes.Items.Add(i);

            cmbMes.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void CarregarAnos()
        {
            cmbAno.Items.Clear();
            for (int ano = DateTime.Now.Year - 3; ano <= DateTime.Now.Year + 1; ano++)
                cmbAno.Items.Add(ano);

            cmbAno.SelectedItem = DateTime.Now.Year;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarSelecao())
                return;

            int mes = (int)cmbMes.SelectedItem;
            int ano = (int)cmbAno.SelectedItem;

            CarregarSaldos(mes, ano);
        }

        private void btnFecharPeriodo_Click(object sender, EventArgs e)
        {
            if (!ValidarSelecao())
                return;

            int mes = (int)cmbMes.SelectedItem;
            int ano = (int)cmbAno.SelectedItem;

            var saldos = _service.FecharPeriodo(mes, ano);

            MessageBox.Show("Período fechado com sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CarregarSaldos(mes, ano);
        }

        private bool ValidarSelecao()
        {
            if (cmbMes.SelectedItem == null || cmbAno.SelectedItem == null)
            {
                MessageBox.Show("Selecione mês e ano.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void CarregarSaldos(int mes, int ano)
        {
            var periodoRepo = new BrechoApp.Data.ComissaoPeriodoRepository();
            var saldoRepo = new BrechoApp.Data.ComissaoSaldoPNRepository();

            var periodo = periodoRepo.BuscarPeriodo(mes, ano);
            if (periodo == null)
            {
                gridSaldos.DataSource = null;
                MessageBox.Show("Nenhum período encontrado para este mês/ano.", "Informação");
                return;
            }

            var saldos = saldoRepo.ListarPorPeriodo(periodo.IdPeriodo);

            gridSaldos.DataSource = saldos;

            // 🔥 FORMATAÇÃO DE TODAS AS COLUNAS NUMÉRICAS
            FormatarColunasNumericas();
        }

        // ============================================================
        //  FORMATAÇÃO DE COLUNAS NUMÉRICAS (2 casas decimais)
        // ============================================================
        private void FormatarColunasNumericas()
        {
            foreach (DataGridViewColumn col in gridSaldos.Columns)
            {
                if (col.ValueType == typeof(decimal) || col.ValueType == typeof(double) || col.ValueType == typeof(float))
                {
                    col.DefaultCellStyle.Format = "N2"; // duas casas decimais
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            if (gridSaldos.CurrentRow == null)
            {
                MessageBox.Show("Selecione um PN na lista.", "Atenção");
                return;
            }

            var saldo = gridSaldos.CurrentRow.DataBoundItem as ComissaoSaldoPN;

            if (saldo == null)
                return;

            MessageBox.Show($"Abrir detalhes do PN: {saldo.CodigoPN}");
        }
    }
}
