#pragma warning disable CA1416
using System;
using System.Globalization;
using System.Windows.Forms;
using BrechoApp.Data;
using BrechoApp.Models;

namespace BrechoApp
{
    /// <summary>
    /// Tela de criação e edição de itens do lote.
    /// Integrada ao fluxo PN → Lote → Itens → Produtos.
    /// Agora com normalização de códigos para evitar falhas de FK.
    /// </summary>
    public partial class FormItemLote : Form
    {
        // ============================================================
        // REPOSITÓRIO
        // ============================================================
        private readonly ItemLoteRepository _repoItem = new ItemLoteRepository();

        // ============================================================
        // CONTEXTO
        // ============================================================
        private readonly string _codigoLote;
        private readonly string _codigoParceiro;
        private readonly string _statusLote;
        private ItemLote _itemEdicao;

        // ============================================================
        // NORMALIZAÇÃO DE CÓDIGOS
        //
        // Remove espaços, quebras de linha e hífens unicode.
        // Garante consistência entre Form → Repository → Banco.
        // ============================================================
        private string NormalizarCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return "";

            return codigo
                .Trim()
                .Replace("–", "-")
                .Replace("—", "-")
                .Replace("‑", "-")
                .Replace("\r", "")
                .Replace("\n", "");
        }

        // ============================================================
        // CONSTRUTOR PARA NOVO ITEM
        // ============================================================
        public FormItemLote(string codigoLote, string codigoParceiro, string statusLote)
        {
            InitializeComponent();

            _codigoLote = NormalizarCodigo(codigoLote);
            _codigoParceiro = NormalizarCodigo(codigoParceiro);
            _statusLote = statusLote;

            // Valores padrão
            txtPrecoSugerido.Text = "9,90";
            txtPrecoVenda.Text = "9,90";

            txtPrecoSugerido.Leave += CorrigirCampoVazio;
            txtPrecoVenda.Leave += CorrigirCampoVazio;

            cboStatusItem.SelectedItem = "Em análise";

            if (_statusLote == "Aprovado")
                BloquearEdicao();
        }

        // ============================================================
        // CONSTRUTOR PARA EDITAR ITEM EXISTENTE
        // ============================================================
        public FormItemLote(string codigoLote, string codigoParceiro, string statusLote, ItemLote item)
        {
            InitializeComponent();

            _codigoLote = NormalizarCodigo(codigoLote);
            _codigoParceiro = NormalizarCodigo(codigoParceiro);
            _statusLote = statusLote;
            _itemEdicao = item;

            txtPrecoSugerido.Leave += CorrigirCampoVazio;
            txtPrecoVenda.Leave += CorrigirCampoVazio;

            CarregarItem();

            if (_statusLote == "Aprovado")
                BloquearEdicao();
        }

        // ============================================================
        // Se o usuário apagar tudo, volta para 0,00
        // ============================================================
        private void CorrigirCampoVazio(object sender, EventArgs e)
        {
            if (sender is TextBox txt && string.IsNullOrWhiteSpace(txt.Text))
                txt.Text = "0,00";
        }

        // ============================================================
        // Bloqueia edição quando o lote está aprovado
        // ============================================================
        private void BloquearEdicao()
        {
            foreach (Control c in Controls)
                c.Enabled = false;

            btnCancelar.Enabled = true;
        }

        // ============================================================
        // Carrega dados do item em edição
        // ============================================================
        private void CarregarItem()
        {
            if (_itemEdicao == null)
                return;

            txtNomeItem.Text = _itemEdicao.NomeDoItem;
            txtMarca.Text = _itemEdicao.MarcaDoItem;
            txtCategoria.Text = _itemEdicao.CategoriaDoItem;
            txtTamanhoCor.Text = _itemEdicao.TamanhoCorDoItem;
            txtObservacao.Text = _itemEdicao.ObservacaoDoItem ?? "";

            txtPrecoSugerido.Text = _itemEdicao.PrecoSugeridoDoItem.ToString("N2");
            txtPrecoVenda.Text = _itemEdicao.PrecoVendaDoItem.ToString("N2");

            cboStatusItem.SelectedItem = _itemEdicao.StatusItem;
        }
        // ============================================================
        // Validação aprimorada
        // ============================================================
        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNomeItem.Text))
            {
                MessageBox.Show("Informe o nome do item.");
                txtNomeItem.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                MessageBox.Show("Informe a categoria do item.");
                txtCategoria.Focus();
                return false;
            }

            if (!double.TryParse(
                    txtPrecoVenda.Text.Replace(",", "."),
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out double precoVenda))
            {
                MessageBox.Show("Preço de venda inválido.");
                txtPrecoVenda.Focus();
                return false;
            }

            if (precoVenda < 0)
            {
                MessageBox.Show("Preço de venda não pode ser negativo.");
                txtPrecoVenda.Focus();
                return false;
            }

            return true;
        }

        // ============================================================
        // Conversão segura de preço
        // ============================================================
        private double ParsePreco(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return 0;

            texto = texto.Replace("R$", "").Trim()
                         .Replace(".", "")
                         .Replace(",", ".");

            if (double.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out double valor))
                return valor;

            return 0;
        }

        // ============================================================
        // BOTÃO SALVAR
        //
        // Normaliza código do lote antes de salvar.
        // Garante consistência com o repositório e o banco.
        // ============================================================
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            double precoSugerido = ParsePreco(txtPrecoSugerido.Text);
            double precoVenda = ParsePreco(txtPrecoVenda.Text);

            if (_itemEdicao == null)
            {
                _itemEdicao = new ItemLote
                {
                    DataCriacao = DateTime.Now
                };
            }

            // Normalização aplicada aqui
            _itemEdicao.CodigoLoteRecebimento = NormalizarCodigo(_codigoLote);
            _itemEdicao.CodigoParceiro = NormalizarCodigo(_codigoParceiro);

            _itemEdicao.NomeDoItem = txtNomeItem.Text.Trim();
            _itemEdicao.MarcaDoItem = txtMarca.Text.Trim();
            _itemEdicao.CategoriaDoItem = txtCategoria.Text.Trim();
            _itemEdicao.TamanhoCorDoItem = txtTamanhoCor.Text.Trim();
            _itemEdicao.ObservacaoDoItem = txtObservacao.Text.Trim();

            _itemEdicao.PrecoSugeridoDoItem = precoSugerido;
            _itemEdicao.PrecoVendaDoItem = precoVenda;

            _itemEdicao.StatusItem = cboStatusItem.SelectedItem?.ToString() ?? "Em análise";
            _itemEdicao.UltimaAtualizacao = DateTime.Now;

            _repoItem.SalvarItem(_itemEdicao);

            DialogResult = DialogResult.OK;
            Close();
        }

        // ============================================================
        // BOTÃO CANCELAR
        // ============================================================
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
