using BrechoApp.Data;
using BrechoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BrechoApp
{
    /// <summary>
    /// Tela para seleção de um lote de recebimento.
    /// Lista todos os lotes do Parceiro de Negócio informado.
    /// </summary>
    public partial class FormSelecionarLote : Form
    {
        private readonly string _codigoParceiro;
        private readonly LoteRecebimentoRepository _repo = new LoteRecebimentoRepository();

        /// <summary>
        /// Código do lote selecionado pelo usuário.
        /// </summary>
        public string? LoteSelecionado { get; private set; }

        public FormSelecionarLote(string codigoParceiro)
        {
            InitializeComponent();
            _codigoParceiro = codigoParceiro;
        }

        // =====================================================================
        // LOAD DO FORMULÁRIO
        // =====================================================================
        private void FormSelecionarLote_Load(object sender, EventArgs e)
        {
            try
            {
                // Carrega todos os lotes do parceiro
                List<LoteRecebimento> lotes = _repo
                    .ListarPorParceiro(_codigoParceiro)
                    .OrderByDescending(l => l.DataCriacao)
                    .ToList();

                dgvLotes.DataSource = lotes;

                // Configuração segura do grid
                dgvLotes.AutoGenerateColumns = true;
                dgvLotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvLotes.ReadOnly = true;
                dgvLotes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvLotes.MultiSelect = false;
                dgvLotes.AllowUserToAddRows = false;
                dgvLotes.AllowUserToDeleteRows = false;

                // Ajuste dos nomes das colunas
                if (dgvLotes.Columns.Contains("CodigoLoteRecebimento"))
                    dgvLotes.Columns["CodigoLoteRecebimento"].HeaderText = "Código do Lote";

                if (dgvLotes.Columns.Contains("DataCriacao"))
                    dgvLotes.Columns["DataCriacao"].HeaderText = "Criado em";

                if (dgvLotes.Columns.Contains("DataAprovacao"))
                    dgvLotes.Columns["DataAprovacao"].HeaderText = "Aprovado em";

                if (dgvLotes.Columns.Contains("StatusLote"))
                    dgvLotes.Columns["StatusLote"].HeaderText = "Status";

                if (dgvLotes.Columns.Contains("Observacoes"))
                    dgvLotes.Columns["Observacoes"].HeaderText = "Observações";

                // Ocultar colunas internas que não interessam ao usuário
                string[] ocultar =
                {
                    "UltimaAtualizacao",
                    "CodigoParceiro"
                };

                foreach (string col in ocultar)
                {
                    if (dgvLotes.Columns.Contains(col))
                        dgvLotes.Columns[col].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lotes:\n" + ex.Message);
            }
        }

        // =====================================================================
        // BOTÃO SELECIONAR
        // =====================================================================
        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (dgvLotes.CurrentRow == null)
            {
                MessageBox.Show("Selecione um lote.");
                return;
            }

            // Recupera o código do lote selecionado
            LoteSelecionado = dgvLotes.CurrentRow
                .Cells["CodigoLoteRecebimento"]
                .Value?
                .ToString();

            if (string.IsNullOrWhiteSpace(LoteSelecionado))
            {
                MessageBox.Show("O lote selecionado é inválido.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        // =====================================================================
        // BOTÃO CANCELAR
        // =====================================================================
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
