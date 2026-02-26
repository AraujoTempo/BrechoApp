using System;
using System.Windows.Forms;
using BrechoApp.Data;
using BrechoApp.Models;

namespace BrechoApp
{
    public partial class FormAjustarDataVendas : Form
    {
        private readonly VendaRepository _repo;

        public FormAjustarDataVendas()
        {
            InitializeComponent();
            _repo = new VendaRepository();

            CarregarMeses();
            CarregarAnos();
        }

        // ============================================================
        //  CARREGAR COMBOS
        // ============================================================
        private void CarregarMeses()
        {
            cmbMesOrigem.Items.Clear();
            for (int i = 1; i <= 12; i++)
                cmbMesOrigem.Items.Add(i);

            cmbMesOrigem.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void CarregarAnos()
        {
            cmbAnoOrigem.Items.Clear();
            for (int ano = DateTime.Now.Year - 3; ano <= DateTime.Now.Year + 1; ano++)
                cmbAnoOrigem.Items.Add(ano);

            cmbAnoOrigem.SelectedItem = DateTime.Now.Year;
        }

        // ============================================================
        //  BUSCAR VENDAS POR PERÍODO
        // ============================================================
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbMesOrigem.SelectedItem == null || cmbAnoOrigem.SelectedItem == null)
            {
                MessageBox.Show("Selecione mês e ano de origem.");
                return;
            }

            int mes = (int)cmbMesOrigem.SelectedItem;
            int ano = (int)cmbAnoOrigem.SelectedItem;

            DateTime inicio = new DateTime(ano, mes, 1);
            DateTime fim = inicio.AddMonths(1).AddDays(-1);

            var vendas = _repo.ListarVendasPorPeriodo(inicio, fim);

            gridVendas.DataSource = vendas;

            if (vendas.Count == 0)
                MessageBox.Show("Nenhuma venda encontrada nesse período.");
        }

        // ============================================================
        //  SELEÇÃO DO GRID → ATUALIZA O CAMPO DE DATA
        // ============================================================
        private void gridVendas_SelectionChanged(object sender, EventArgs e)
        {
            if (gridVendas.CurrentRow == null)
                return;

            var venda = gridVendas.CurrentRow.DataBoundItem as Venda;
            if (venda == null)
                return;

            dtpNovaData.Value = venda.DataVenda;
        }

        // ============================================================
        //  SALVAR AJUSTE DE DATA
        // ============================================================
        private void btnSalvarAjuste_Click(object sender, EventArgs e)
        {
            if (gridVendas.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma venda.");
                return;
            }

            var venda = gridVendas.CurrentRow.DataBoundItem as Venda;
            if (venda == null)
                return;

            venda.DataVenda = dtpNovaData.Value;

            try
            {
                _repo.AtualizarVenda(venda);
                MessageBox.Show("Data da venda ajustada com sucesso!");

                btnBuscar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar venda: " + ex.Message);
            }
        }

        // ============================================================
        //  DUPLO CLIQUE → ABRIR DETALHES DA VENDA
        // ============================================================
        private void gridVendas_DoubleClick(object sender, EventArgs e)
        {
            if (gridVendas.CurrentRow == null)
                return;

            var venda = gridVendas.CurrentRow.DataBoundItem as Venda;
            if (venda == null)
                return;

            var tela = new FormDetalhesVenda(venda);
            tela.ShowDialog();
        }
    }
}
