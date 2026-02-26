using System;
using System.Windows.Forms;

namespace BrechoApp
{
    public partial class FormMenuComissoes : Form
    {
        public FormMenuComissoes()
        {
            InitializeComponent();   // ← ESSENCIAL
        }

        private void btnGestaoComissoes_Click(object sender, EventArgs e)
        {
            var tela = new FormGestaoComissoes();
            tela.ShowDialog();
        }

        private void btnExtratoComissoes_Click(object sender, EventArgs e)
        {
            var form = new FormComissoesFornecedor();
            form.ShowDialog();
        }

        private void btnAjustarDataVendas_Click(object sender, EventArgs e)
        {
            var tela = new FormAjustarDataVendas();
            tela.ShowDialog();
        }
    }
}