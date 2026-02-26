using System;
using System.Windows.Forms;
using BrechoApp.Data;
using BrechoApp.Models;

namespace BrechoApp
{
    public partial class FormMovimentacaoCadastro : Form
    {
        private readonly MovimentacaoFinanceiraRepository _repositoryMov;
        private readonly CentroFinanceiroRepository _repositoryCentros;

        private readonly string _tipoMov; // Entrada, Saida, Transferencia

        public FormMovimentacaoCadastro(string tipoMov)
        {
            InitializeComponent();

            _repositoryMov = new MovimentacaoFinanceiraRepository();
            _repositoryCentros = new CentroFinanceiroRepository();

            _tipoMov = tipoMov;

            ConfigurarTela();
            CarregarCentros();
        }

        // ============================================================
        // CONFIGURA A TELA DE ACORDO COM O TIPO
        // ============================================================
        private void ConfigurarTela()
        {
            lblTipo.Text = $"Tipo: {_tipoMov}";

            if (_tipoMov == "Entrada")
            {
                lblOrigem.Visible = false;
                cmbOrigem.Visible = false;
            }
            else if (_tipoMov == "Saida")
            {
                lblDestino.Visible = false;
                cmbDestino.Visible = false;
            }
        }

        // ============================================================
        // CARREGAR CENTROS FINANCEIROS
        // ============================================================
        private void CarregarCentros()
        {
            var lista = _repositoryCentros.Listar();

            cmbOrigem.Items.Clear();
            cmbDestino.Items.Clear();

            foreach (var c in lista)
            {
                if (c.Ativo)
                {
                    cmbOrigem.Items.Add(new ComboItem(c.Nome, c.IdCentroFinanceiro));
                    cmbDestino.Items.Add(new ComboItem(c.Nome, c.IdCentroFinanceiro));
                }
            }
        }

        // ============================================================
        // BOTÃO: SALVAR
        // ============================================================
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (numValor.Value <= 0)
            {
                MessageBox.Show("Informe um valor válido.",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_tipoMov != "Entrada" && cmbOrigem.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione o centro de origem.",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_tipoMov != "Saida" && cmbDestino.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione o centro de destino.",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var mov = new MovimentacaoFinanceira
            {
                Data = dtData.Value,
                Tipo = _tipoMov,
                Valor = numValor.Value,
                Categoria = txtCategoria.Text.Trim(),
                Descricao = txtDescricao.Text.Trim(),
                Previsto = false
            };

            if (_tipoMov == "Entrada")
            {
                mov.IdCentroOrigem = null;
                mov.IdCentroDestino = ((ComboItem)cmbDestino.SelectedItem).Value;
            }
            else if (_tipoMov == "Saida")
            {
                mov.IdCentroOrigem = ((ComboItem)cmbOrigem.SelectedItem).Value;
                mov.IdCentroDestino = null;
            }
            else // Transferência
            {
                mov.IdCentroOrigem = ((ComboItem)cmbOrigem.SelectedItem).Value;
                mov.IdCentroDestino = ((ComboItem)cmbDestino.SelectedItem).Value;
            }

            _repositoryMov.Inserir(mov);

            MessageBox.Show("Movimentação registrada com sucesso!",
                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        // ============================================================
        // BOTÃO: CANCELAR
        // ============================================================
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // ============================================================
    // CLASSE AUXILIAR PARA COMBOBOX
    // ============================================================
    public class ComboItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public ComboItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString() => Text;
    }
}
