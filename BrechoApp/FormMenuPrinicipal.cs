using System;
using System.Windows.Forms;

namespace BrechoApp
{
    /// <summary>
    /// Tela principal do sistema.
    /// Centraliza o acesso aos módulos disponíveis.
    /// </summary>
    public partial class FormMenuPrincipal : Form
    {
        public FormMenuPrincipal()
        {
            InitializeComponent();
        }

        // ============================================================
        // BOTÃO: FINANCEIRO
        // Módulo ainda não implementado
        // ============================================================
        private void btnFinanceiro_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo Financeiro ainda não implementado.");
        }

        // ============================================================
        // BOTÃO: MARKETING
        // Módulo ainda não implementado
        // ============================================================
        private void btnMarketing_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo Marketing ainda não implementado.");
        }

        // ============================================================
        // BOTÃO: CURADORIA
        // Abre o cadastro de Parceiro de Negócio (PN)
        // Este é o ponto de entrada do fluxo:
        // PN → Lote → Item → Produto
        // ============================================================
        private void btnCuradoria_Click(object sender, EventArgs e)
        {
            var form = new FormCadastroParceiroNegocio();
            form.ShowDialog();
        }

        // ============================================================
        // BOTÃO: OPERAÇÕES
        // Abre o módulo de operações (exportações, relatórios, etc.)
        // ============================================================
        private void btnOperacoes_Click(object sender, EventArgs e)
        {
            var form = new FormOperacoes();
            form.ShowDialog();
        }

        // ============================================================
        // BOTÃO: VENDAS
        // Abre o formulário de vendas
        // ============================================================
        private void btnVendas_Click(object sender, EventArgs e)
        {
            var form = new FormVenda();
            form.ShowDialog();
        }

        // ============================================================
        // BOTÃO: RELATÓRIOS GERENCIAIS
        // Abre o módulo de relatórios gerenciais
        // ============================================================
        private void btnRelatoriosGerenciais_Click(object sender, EventArgs e)
        {
            var form = new FormRelatoriosGerenciais();
            form.ShowDialog();
        }
    }
}
