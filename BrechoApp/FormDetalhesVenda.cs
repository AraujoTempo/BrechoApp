using System;
using System.Windows.Forms;
using BrechoApp.Models;
using System.Linq;

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

            // NOVO: pagamentos combinados
            string formasPagamento = string.Join(", ",
                _venda.Pagamentos.Select(p => p.Tipo.ToString())
            );

            txtFormaPagamento.Text = formasPagamento;

            txtObservacoes.Text = _venda.Observacoes;
        }
    }
}