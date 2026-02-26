using System;
using System.Windows.Forms;
using BrechoApp.Data;

namespace BrechoApp
{
    public partial class FormMovimentacoesFinanceiras : Form
    {
        private readonly MovimentacaoFinanceiraRepository _repository;

        public FormMovimentacoesFinanceiras()
        {
            InitializeComponent();
            _repository = new MovimentacaoFinanceiraRepository();

            dtInicio.Value = DateTime.Today.AddDays(-7);
            dtFim.Value = DateTime.Today;

            CarregarMovimentacoes();
        }

        // ============================================================
        // CARREGAR MOVIMENTAÇÕES NO GRID
        // ============================================================
        private void CarregarMovimentacoes()
        {
            dgvMov.Rows.Clear();

            var lista = _repository.Listar(dtInicio.Value, dtFim.Value);

            foreach (var m in lista)
            {
                dgvMov.Rows.Add(
                    m.IdMovimentacao,
                    m.Data.ToString("dd/MM/yyyy"),
                    m.Tipo,
                    m.Valor.ToString("C2"),
                    m.IdCentroOrigem,
                    m.IdCentroDestino,
                    m.Categoria,
                    m.Descricao
                );
            }
        }

        // ============================================================
        // BOTÃO: FILTRAR
        // ============================================================
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CarregarMovimentacoes();
        }

        // ============================================================
        // BOTÃO: NOVA ENTRADA
        // ============================================================
        private void btnEntrada_Click(object sender, EventArgs e)
        {
            var form = new FormMovimentacaoCadastro("Entrada");
            form.ShowDialog();
            CarregarMovimentacoes();
        }

        // ============================================================
        // BOTÃO: NOVA SAÍDA
        // ============================================================
        private void btnSaida_Click(object sender, EventArgs e)
        {
            var form = new FormMovimentacaoCadastro("Saida");
            form.ShowDialog();
            CarregarMovimentacoes();
        }

        // ============================================================
        // BOTÃO: TRANSFERÊNCIA
        // ============================================================
        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            var form = new FormMovimentacaoCadastro("Transferencia");
            form.ShowDialog();
            CarregarMovimentacoes();
        }

        // ============================================================
        // BOTÃO: FECHAR
        // ============================================================
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
