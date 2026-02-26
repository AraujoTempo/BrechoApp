using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BrechoApp.Data;
using BrechoApp.Models;

namespace BrechoApp
{
    /// <summary>
    /// Tela de seleção de forma de pagamento para finalização de venda.
    /// 
    /// Suporta:
    ///   - Seleção de forma única: 100% do valor é alocado nessa forma.
    ///   - Modo Combinado: rateio com múltiplas formas e valores parciais.
    /// 
    /// O botão Confirmar só é habilitado quando o total alocado bate com o
    /// total da venda (tolerância de 0,01).
    /// </summary>
    public partial class FormPagamentoVenda : Form
    {
        private const decimal TOLERANCIA = 0.01m;

        // Formas disponíveis (exceto Combinado)
        public static readonly string[] FormasPagamento = new[]
        {
            "Dinheiro",
            "PIX",
            "Débito",
            "Crédito",
            "Transferencia cc Brecho",
            "Transferencia cc Socio1",
            "Transferencia cc Socio2",
            "Futuro"
        };

        // Mapeamento forma -> nome do centro financeiro
        private static readonly Dictionary<string, string> MapaCentros = new Dictionary<string, string>
        {
            { "Dinheiro",                 "Caixa Fisico" },
            { "PIX",                      "Conta Corrente Brecho" },
            { "Débito",                   "Cartao de Debito" },
            { "Crédito",                  "Cartao de Credito" },
            { "Transferencia cc Brecho",  "Conta Corrente Brecho" },
            { "Transferencia cc Socio1",  "Conta Corrente Socio1" },
            { "Transferencia cc Socio2",  "Conta Corrente Socio2" },
            { "Futuro",                   "Contas a Receber - Vendas nao pagas" }
        };

        private readonly decimal _totalVenda;
        private readonly CentroFinanceiroRepository _centroRepo;

        // Resultado: lista de pagamentos confirmados
        public List<VendaPagamento> PagamentosConfirmados { get; private set; }

        // ============================================================
        // CONTROLES DA UI (criados programaticamente)
        // ============================================================
        private Label lblTotalVenda;
        private Label lblTotalAlocado;
        private Label lblFalta;

        private RadioButton[] _radioButtons;
        private RadioButton rbtCombinado;

        private Panel pnlCombinado;
        private DataGridView dgvPagamentos;
        private DataGridViewComboBoxColumn colForma;
        private DataGridViewTextBoxColumn colValor;
        private Button btnAdicionarLinha;
        private Button btnRemoverLinha;

        private Button btnConfirmar;
        private Button btnCancelar;

        public FormPagamentoVenda(decimal totalVenda)
        {
            InitializeComponent();

            _totalVenda = totalVenda;
            _centroRepo = new CentroFinanceiroRepository();

            ConstruirUI();
        }

        // ============================================================
        // CONSTRUIR UI PROGRAMATICAMENTE
        // ============================================================
        private void ConstruirUI()
        {
            int left = 20;
            int top = 15;
            int spacing = 30;

            // --- Cabeçalho: Total da Venda ---
            var lblTitulo = new Label
            {
                Text = "Selecione a Forma de Pagamento",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(left, top),
                AutoSize = true
            };
            Controls.Add(lblTitulo);
            top += 35;

            lblTotalVenda = new Label
            {
                Text = $"Total da Venda: {_totalVenda:C2}",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Location = new Point(left, top),
                AutoSize = true
            };
            Controls.Add(lblTotalVenda);
            top += 35;

            // --- Separador ---
            var sep = new Label
            {
                Text = "─────────────────────────────────────────────",
                Location = new Point(left, top),
                AutoSize = true
            };
            Controls.Add(sep);
            top += 22;

            // --- RadioButtons: formas simples ---
            _radioButtons = new RadioButton[FormasPagamento.Length];
            for (int i = 0; i < FormasPagamento.Length; i++)
            {
                var rbt = new RadioButton
                {
                    Text = FormasPagamento[i],
                    Location = new Point(left + 10, top),
                    AutoSize = true,
                    Tag = FormasPagamento[i]
                };
                rbt.CheckedChanged += RadioButton_CheckedChanged;
                Controls.Add(rbt);
                _radioButtons[i] = rbt;
                top += spacing;
            }

            // --- RadioButton: Combinado ---
            rbtCombinado = new RadioButton
            {
                Text = "Combinado",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(left + 10, top),
                AutoSize = true
            };
            rbtCombinado.CheckedChanged += RadioButton_CheckedChanged;
            Controls.Add(rbtCombinado);
            top += spacing + 5;

            // --- Separador ---
            var sep2 = new Label
            {
                Text = "─────────────────────────────────────────────",
                Location = new Point(left, top),
                AutoSize = true
            };
            Controls.Add(sep2);
            top += 22;

            // --- Painel Combinado (inicialmente oculto) ---
            pnlCombinado = new Panel
            {
                Location = new Point(left, top),
                Size = new Size(520, 220),
                Visible = false,
                BorderStyle = BorderStyle.FixedSingle
            };
            Controls.Add(pnlCombinado);

            // Grid de rateio
            dgvPagamentos = new DataGridView
            {
                Location = new Point(5, 5),
                Size = new Size(510, 140),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoGenerateColumns = false,
                RowHeadersVisible = false
            };

            colForma = new DataGridViewComboBoxColumn
            {
                HeaderText = "Forma de Pagamento",
                Width = 220,
                DataSource = FormasPagamento,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
            };
            colValor = new DataGridViewTextBoxColumn
            {
                HeaderText = "Valor (R$)",
                Width = 120
            };

            dgvPagamentos.Columns.Add(colForma);
            dgvPagamentos.Columns.Add(colValor);
            dgvPagamentos.CellValueChanged += DgvPagamentos_CellValueChanged;
            dgvPagamentos.CurrentCellDirtyStateChanged += DgvPagamentos_CurrentCellDirtyStateChanged;
            pnlCombinado.Controls.Add(dgvPagamentos);

            btnAdicionarLinha = new Button
            {
                Text = "Adicionar",
                Location = new Point(5, 150),
                Size = new Size(100, 28)
            };
            btnAdicionarLinha.Click += BtnAdicionarLinha_Click;
            pnlCombinado.Controls.Add(btnAdicionarLinha);

            btnRemoverLinha = new Button
            {
                Text = "Remover",
                Location = new Point(115, 150),
                Size = new Size(100, 28)
            };
            btnRemoverLinha.Click += BtnRemoverLinha_Click;
            pnlCombinado.Controls.Add(btnRemoverLinha);

            // Totalizadores do rateio
            lblTotalAlocado = new Label
            {
                Text = "Alocado: R$ 0,00",
                Location = new Point(230, 153),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F)
            };
            pnlCombinado.Controls.Add(lblTotalAlocado);

            lblFalta = new Label
            {
                Text = $"Falta: {_totalVenda:C2}",
                Location = new Point(380, 153),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.Red
            };
            pnlCombinado.Controls.Add(lblFalta);

            top += 230;

            // --- Botões ---
            btnConfirmar = new Button
            {
                Text = "Confirmar",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(left, top),
                Size = new Size(200, 35),
                Enabled = false
            };
            btnConfirmar.Click += BtnConfirmar_Click;
            Controls.Add(btnConfirmar);

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(left + 220, top),
                Size = new Size(200, 35)
            };
            btnCancelar.Click += BtnCancelar_Click;
            Controls.Add(btnCancelar);

            // Ajustar tamanho do formulário
            this.ClientSize = new Size(560, top + 60);
        }

        // ============================================================
        // EVENTOS DOS RADIOBUTTONS
        // ============================================================
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var rbt = sender as RadioButton;
            if (rbt == null || !rbt.Checked) return;

            bool isCombinado = rbt == rbtCombinado;
            pnlCombinado.Visible = isCombinado;

            if (isCombinado)
            {
                AtualizarTotalizadores();
                ValidarConfirmar();
            }
            else
            {
                // Forma única: botão sempre habilitado
                btnConfirmar.Enabled = true;
            }
        }

        // ============================================================
        // GRID COMBINADO
        // ============================================================
        private void DgvPagamentos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvPagamentos.IsCurrentCellDirty)
                dgvPagamentos.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DgvPagamentos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            AtualizarTotalizadores();
            ValidarConfirmar();
        }

        private void BtnAdicionarLinha_Click(object sender, EventArgs e)
        {
            var row = new DataGridViewRow();
            row.CreateCells(dgvPagamentos);
            row.Cells[0].Value = FormasPagamento[0];
            row.Cells[1].Value = "0,00";
            dgvPagamentos.Rows.Add(row);

            AtualizarTotalizadores();
            ValidarConfirmar();
        }

        private void BtnRemoverLinha_Click(object sender, EventArgs e)
        {
            if (dgvPagamentos.SelectedRows.Count == 0) return;
            foreach (DataGridViewRow row in dgvPagamentos.SelectedRows)
            {
                if (!row.IsNewRow)
                    dgvPagamentos.Rows.Remove(row);
            }
            AtualizarTotalizadores();
            ValidarConfirmar();
        }

        // ============================================================
        // TOTALIZADORES DO RATEIO
        // ============================================================
        private static bool TryParseValor(string input, out decimal result)
        {
            string normalized = (input ?? "0").Replace(",", ".");
            return decimal.TryParse(normalized, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out result);
        }

        private decimal ObterTotalAlocado()
        {
            decimal total = 0m;
            foreach (DataGridViewRow row in dgvPagamentos.Rows)
            {
                if (row.IsNewRow) continue;
                if (TryParseValor(row.Cells[1].Value?.ToString(), out decimal val))
                    total += val;
            }
            return total;
        }

        private void AtualizarTotalizadores()
        {
            decimal alocado = ObterTotalAlocado();
            decimal falta = _totalVenda - alocado;

            lblTotalAlocado.Text = $"Alocado: {alocado:C2}";
            lblFalta.Text = $"Falta: {falta:C2}";
            lblFalta.ForeColor = Math.Abs(falta) <= TOLERANCIA ? Color.DarkGreen : Color.Red;
        }

        private void ValidarConfirmar()
        {
            if (!rbtCombinado.Checked)
            {
                btnConfirmar.Enabled = true;
                return;
            }

            decimal alocado = ObterTotalAlocado();
            btnConfirmar.Enabled = Math.Abs(_totalVenda - alocado) <= TOLERANCIA
                                   && dgvPagamentos.Rows.Count > 0; // ao menos 1 linha
        }

        // ============================================================
        // CONFIRMAR
        // ============================================================
        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (rbtCombinado.Checked)
            {
                // Modo combinado: ler linhas do grid
                var pagamentos = new List<VendaPagamento>();
                foreach (DataGridViewRow row in dgvPagamentos.Rows)
                {
                    if (row.IsNewRow) continue;
                    string forma = row.Cells[0].Value?.ToString() ?? string.Empty;
                    string valStr = row.Cells[1].Value?.ToString() ?? "0";

                    if (string.IsNullOrWhiteSpace(forma)) continue;
                    if (!TryParseValor(valStr, out decimal val))
                        continue;

                    var centro = MapaCentros.ContainsKey(forma) ? _centroRepo.BuscarPorNome(MapaCentros[forma]) : null;
                    pagamentos.Add(new VendaPagamento
                    {
                        FormaPagamento = forma,
                        Valor = val,
                        IdCentroFinanceiro = centro?.IdCentroFinanceiro
                    });
                }

                if (pagamentos.Count == 0)
                {
                    MessageBox.Show("Adicione pelo menos uma forma de pagamento.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal totalAlocado = pagamentos.Sum(p => p.Valor);
                if (Math.Abs(_totalVenda - totalAlocado) > TOLERANCIA)
                {
                    MessageBox.Show(
                        $"A soma dos valores ({totalAlocado:C2}) não corresponde ao total da venda ({_totalVenda:C2}).\n" +
                        $"Diferença: {Math.Abs(_totalVenda - totalAlocado):C2}",
                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PagamentosConfirmados = pagamentos;
            }
            else
            {
                // Forma única
                string formaSelecionada = ObterFormaSelecionada();
                if (string.IsNullOrEmpty(formaSelecionada))
                {
                    MessageBox.Show("Selecione uma forma de pagamento.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var centro = MapaCentros.ContainsKey(formaSelecionada)
                    ? _centroRepo.BuscarPorNome(MapaCentros[formaSelecionada])
                    : null;

                PagamentosConfirmados = new List<VendaPagamento>
                {
                    new VendaPagamento
                    {
                        FormaPagamento = formaSelecionada,
                        Valor = _totalVenda,
                        IdCentroFinanceiro = centro?.IdCentroFinanceiro
                    }
                };
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private string ObterFormaSelecionada()
        {
            foreach (var rbt in _radioButtons)
            {
                if (rbt.Checked) return rbt.Tag as string;
            }
            return string.Empty;
        }

        // ============================================================
        // CANCELAR
        // ============================================================
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
