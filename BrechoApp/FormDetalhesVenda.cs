using System;
using System.Linq;
using System.Windows.Forms;
using BrechoApp.Models;

namespace BrechoApp
{
    public partial class FormDetalhesVenda : Form
    {
        private readonly Venda _venda;

        public FormDetalhesVenda(Venda venda)
        {
            InitializeComponent();
            _venda = venda;
            PreencherCampos();
        }

        private void PreencherCampos()
        {
            txtCodigo.Text = _venda.CodigoVenda;
            txtData.Text = _venda.DataVenda.ToString("dd/MM/yyyy HH:mm");
            txtVendedor.Text = _venda.IdVendedor;
            txtCliente.Text = _venda.IdCliente;

            txtValorOriginal.Text = _venda.ValorTotalOriginal.ToString("F2");
            txtDescontoPercentual.Text = _venda.DescontoPercentual.ToString("F2");
            txtDescontoValor.Text = _venda.DescontoValor.ToString("F2");
            txtCampanha.Text = _venda.Campanha;
            txtDescontoCampanhaPercentual.Text = _venda.DescontoCampanhaPercentual.ToString("F2");
            txtDescontoCampanha.Text = _venda.DescontoCampanha.ToString("F2");
            txtValorFinal.Text = _venda.ValorTotalFinal.ToString("F2");

            // Exibir pagamentos: se houver lista detalhada, mostrá-la; senão, usar campo legado
            if (_venda.Pagamentos != null && _venda.Pagamentos.Count > 1)
            {
                // Combinado: mostrar lista
                string detalhes = string.Join("\n", _venda.Pagamentos
                    .Select(p => $"  {p.FormaPagamento}: {p.Valor:C2}"));
                txtFormaPagamento.Text = $"Combinado:\n{detalhes}";
                txtFormaPagamento.Multiline = true;
                int linhas = _venda.Pagamentos.Count + 1;
                txtFormaPagamento.Size = new System.Drawing.Size(
                    txtFormaPagamento.Width,
                    Math.Max(txtFormaPagamento.Height, linhas * 18 + 4));
            }
            else if (_venda.Pagamentos != null && _venda.Pagamentos.Count == 1)
            {
                txtFormaPagamento.Text = $"{_venda.Pagamentos[0].FormaPagamento}: {_venda.Pagamentos[0].Valor:C2}";
            }
            else
            {
                txtFormaPagamento.Text = _venda.FormaPagamento;
            }

            txtObservacoes.Text = _venda.Observacoes;
        }
    }
}
