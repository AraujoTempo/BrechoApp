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
            // Por enquanto apenas abre e fecha
            MessageBox.Show("Módulo de vendas ainda será desenvolvido.");
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
