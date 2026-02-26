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
        // BOTÃO: VENDAS
        // Abre o formulário de vendas
        // ============================================================
        private void btnVendas_Click(object sender, EventArgs e)
        {
            var form = new FormVenda();
            form.ShowDialog();
        }

        // ============================================================
        // BOTÃO: FINANCEIRO
        // Agora abre o menu financeiro
        // ============================================================
        private void btnFinanceiro_Click(object sender, EventArgs e)
        {
            var form = new FormMenuFinanceiro();
            form.ShowDialog();
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
        // BOTÃO / MENU: COMISSÕES
        // Abre o módulo de Gestão de Comissões
        // ============================================================
        private void btnComissoes_Click(object sender, EventArgs e)
        {
            // Aqui você pode futuramente abrir um menu completo de comissões.
            // Por enquanto, vamos direto para o Extrato de Comissões.
            var form = new FormMenuComissoes();
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
        // BOTÃO: MARKETING
        // Módulo ainda não implementado
        // ============================================================
        private void btnMarketing_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo Marketing ainda não implementado.");
        }

    }
}


