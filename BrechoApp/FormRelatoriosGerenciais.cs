using System;
using System.Windows.Forms;

namespace BrechoApp
{
    /// <summary>
    /// Menu de Relatórios Gerenciais.
    /// Centraliza o acesso aos diferentes tipos de relatórios do sistema.
    /// </summary>
    public partial class FormRelatoriosGerenciais : Form
    {
        public FormRelatoriosGerenciais()
        {
            InitializeComponent();
        }

        // ============================================================
        // BOTÃO: RELATÓRIO DE VENDAS DO MÊS
        // Abre o relatório de vendas mensal
        // ============================================================
        private void btnRelatorioVendasMes_Click(object sender, EventArgs e)
        {
            var form = new FormRelatorioVendasMes();
            form.ShowDialog();
        }

        // ============================================================
        // BOTÃO: RELATÓRIO FINANCEIRO
        // Ainda não implementado
        // ============================================================
        private void btnRelatorioFinanceiro_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Relatório Financeiro em desenvolvimento.", 
                "Em Desenvolvimento", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        // ============================================================
        // BOTÃO: VOLTAR
        // Fecha o formulário
        // ============================================================
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
