using System;
using System.Windows.Forms;

namespace BrechoApp
{
    public partial class FormVendasPrincipal : Form
    {
        public FormVendasPrincipal()
        {
            InitializeComponent();
        }

        private void btnCadastrarVendedor_Click(object sender, EventArgs e)
        {
            var form = new FormCadastroVendedor();
            form.ShowDialog();
        }

        private void btnGerarVenda_Click(object sender, EventArgs e)
        {
            // Abrir o formulário de vendas
            var form = new FormVenda();
            form.ShowDialog();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
