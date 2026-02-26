using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BrechoApp.Enums;
using BrechoApp.Models;

namespace BrechoApp
{
    public partial class FormFinalizarVenda : Form
    {
        private readonly Venda _venda;

        public List<Pagamento> PagamentosSelecionados { get; private set; } = new List<Pagamento>();

        public FormFinalizarVenda(Venda venda)
        {
            InitializeComponent();
            _venda = venda;

            lblValorTotal.Text = venda.ValorTotalFinal.ToString("C2");

            // Carrega todas as formas de pagamento do enum
            cmbFormaPagamento.Items.AddRange(Enum.GetNames(typeof(TipoPagamento)));

            // Adiciona a opção especial
            cmbFormaPagamento.Items.Add("Combinado");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            var selecionado = cmbFormaPagamento.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selecionado))
            {
                MessageBox.Show("Selecione uma forma de pagamento.");
                return;
            }

            // ============================================================
            // PAGAMENTO COMBINADO
            // ============================================================
            if (selecionado == "Combinado")
            {
                using (var form = new FormPagamentosCombinados(_venda))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // AQUI ESTÁ CORRETO: sua tela retorna "Pagamentos"
                        PagamentosSelecionados = form.Pagamentos;

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                return;
            }

            // ============================================================
            // PAGAMENTO SIMPLES
            // ============================================================
            var tipo = (TipoPagamento)Enum.Parse(typeof(TipoPagamento), selecionado);

            PagamentosSelecionados.Add(new Pagamento
            {
                Tipo = tipo,
                Valor = _venda.ValorTotalFinal
            });

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
