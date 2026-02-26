using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BrechoApp.Enums;
using BrechoApp.Models;

namespace BrechoApp
{
    public partial class FormPagamentosCombinados : Form
    {
        private readonly Venda _venda;

        public List<Pagamento> Pagamentos { get; private set; } = new List<Pagamento>();

        public FormPagamentosCombinados(Venda venda)
        {
            InitializeComponent();
            _venda = venda;

            // Configurar DataGridView
            dgvPagamentos.Columns.Add("Tipo", "Tipo");
            dgvPagamentos.Columns.Add("Valor", "Valor");

            // Preencher combo com enum TipoPagamento
            cmbTipoPagamento.DataSource = Enum.GetValues(typeof(TipoPagamento));

            // Mostrar o valor total da venda
            lblValorTotal.Text = _venda.ValorTotalFinal.ToString("C2");
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtValor.Text, out double valor) || valor <= 0)
            {
                MessageBox.Show("Informe um valor válido.");
                return;
            }

            var tipo = (TipoPagamento)cmbTipoPagamento.SelectedItem;

            dgvPagamentos.Rows.Add(tipo.ToString(), valor.ToString("F2"));
            txtValor.Clear();
            txtValor.Focus();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            double soma = 0;
            Pagamentos.Clear();

            foreach (DataGridViewRow row in dgvPagamentos.Rows)
            {
                if (row.IsNewRow) continue;

                var tipo = (TipoPagamento)Enum.Parse(typeof(TipoPagamento), row.Cells[0].Value.ToString());
                var valor = double.Parse(row.Cells[1].Value.ToString());

                soma += valor;

                Pagamentos.Add(new Pagamento
                {
                    Tipo = tipo,
                    Valor = valor
                });
            }

            if (Math.Abs(soma - _venda.ValorTotalFinal) > 0.01)
            {
                MessageBox.Show("A soma dos pagamentos deve ser igual ao valor total da venda.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}