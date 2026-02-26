using System;
using System.Windows.Forms;

namespace BrechoApp
{
    public partial class FormMenuFinanceiro : Form
    {
        public FormMenuFinanceiro()
        {
            InitializeComponent();
        }

        private void btnCentrosFinanceiros_Click(object sender, EventArgs e)
        {
            var form = new FormCentroFinanceiro();
            form.ShowDialog();
        }

        private void btnMovimentacoes_Click(object sender, EventArgs e)
        {
            var form = new FormMovimentacoesFinanceiras();
            form.ShowDialog();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
