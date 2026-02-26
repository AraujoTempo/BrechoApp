namespace BrechoApp
{
    partial class FormDetalhesVenda
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblValorOriginal;
        private System.Windows.Forms.Label lblDescontoPercentual;
        private System.Windows.Forms.Label lblDescontoValor;
        private System.Windows.Forms.Label lblCampanha;
        private System.Windows.Forms.Label lblDescontoCampanhaPercentual;
        private System.Windows.Forms.Label lblDescontoCampanha;
        private System.Windows.Forms.Label lblValorFinal;
        private System.Windows.Forms.Label lblFormaPagamento;
        private System.Windows.Forms.Label lblObservacoes;

        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtValorOriginal;
        private System.Windows.Forms.TextBox txtDescontoPercentual;
        private System.Windows.Forms.TextBox txtDescontoValor;
        private System.Windows.Forms.TextBox txtCampanha;
        private System.Windows.Forms.TextBox txtDescontoCampanhaPercentual;
        private System.Windows.Forms.TextBox txtDescontoCampanha;
        private System.Windows.Forms.TextBox txtValorFinal;
        private System.Windows.Forms.TextBox txtFormaPagamento;
        private System.Windows.Forms.TextBox txtObservacoes;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            int leftLabel = 20;
            int leftInput = 180;
            int widthInput = 250;
            int height = 25;
            int top = 20;
            int spacing = 35;

            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblCodigo.Text = "Código da Venda:";
            this.lblCodigo.Location = new System.Drawing.Point(leftLabel, top);

            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtCodigo.Location = new System.Drawing.Point(leftInput, top);
            this.txtCodigo.Size = new System.Drawing.Size(widthInput, height);
            this.txtCodigo.ReadOnly = true;

            top += spacing;

            this.lblData = new System.Windows.Forms.Label();
            this.lblData.Text = "Data da Venda:";
            this.lblData.Location = new System.Drawing.Point(leftLabel, top);

            this.txtData = new System.Windows.Forms.TextBox();
            this.txtData.Location = new System.Drawing.Point(leftInput, top);
            this.txtData.Size = new System.Drawing.Size(widthInput, height);
            this.txtData.ReadOnly = true;

            top += spacing;

            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblVendedor.Text = "Vendedor:";
            this.lblVendedor.Location = new System.Drawing.Point(leftLabel, top);

            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.txtVendedor.Location = new System.Drawing.Point(leftInput, top);
            this.txtVendedor.Size = new System.Drawing.Size(widthInput, height);
            this.txtVendedor.ReadOnly = true;

            top += spacing;

            this.lblCliente = new System.Windows.Forms.Label();
            this.lblCliente.Text = "Cliente:";
            this.lblCliente.Location = new System.Drawing.Point(leftLabel, top);

            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtCliente.Location = new System.Drawing.Point(leftInput, top);
            this.txtCliente.Size = new System.Drawing.Size(widthInput, height);
            this.txtCliente.ReadOnly = true;

            top += spacing;

            this.lblValorOriginal = new System.Windows.Forms.Label();
            this.lblValorOriginal.Text = "Valor Original:";
            this.lblValorOriginal.Location = new System.Drawing.Point(leftLabel, top);

            this.txtValorOriginal = new System.Windows.Forms.TextBox();
            this.txtValorOriginal.Location = new System.Drawing.Point(leftInput, top);
            this.txtValorOriginal.Size = new System.Drawing.Size(widthInput, height);
            this.txtValorOriginal.ReadOnly = true;

            top += spacing;

            this.lblDescontoPercentual = new System.Windows.Forms.Label();
            this.lblDescontoPercentual.Text = "Desconto (%):";
            this.lblDescontoPercentual.Location = new System.Drawing.Point(leftLabel, top);

            this.txtDescontoPercentual = new System.Windows.Forms.TextBox();
            this.txtDescontoPercentual.Location = new System.Drawing.Point(leftInput, top);
            this.txtDescontoPercentual.Size = new System.Drawing.Size(widthInput, height);
            this.txtDescontoPercentual.ReadOnly = true;

            top += spacing;

            this.lblDescontoValor = new System.Windows.Forms.Label();
            this.lblDescontoValor.Text = "Desconto (R$):";
            this.lblDescontoValor.Location = new System.Drawing.Point(leftLabel, top);

            this.txtDescontoValor = new System.Windows.Forms.TextBox();
            this.txtDescontoValor.Location = new System.Drawing.Point(leftInput, top);
            this.txtDescontoValor.Size = new System.Drawing.Size(widthInput, height);
            this.txtDescontoValor.ReadOnly = true;

            top += spacing;

            this.lblCampanha = new System.Windows.Forms.Label();
            this.lblCampanha.Text = "Campanha:";
            this.lblCampanha.Location = new System.Drawing.Point(leftLabel, top);

            this.txtCampanha = new System.Windows.Forms.TextBox();
            this.txtCampanha.Location = new System.Drawing.Point(leftInput, top);
            this.txtCampanha.Size = new System.Drawing.Size(widthInput, height);
            this.txtCampanha.ReadOnly = true;

            top += spacing;

            this.lblDescontoCampanhaPercentual = new System.Windows.Forms.Label();
            this.lblDescontoCampanhaPercentual.Text = "Desc. Campanha (%):";
            this.lblDescontoCampanhaPercentual.Location = new System.Drawing.Point(leftLabel, top);

            this.txtDescontoCampanhaPercentual = new System.Windows.Forms.TextBox();
            this.txtDescontoCampanhaPercentual.Location = new System.Drawing.Point(leftInput, top);
            this.txtDescontoCampanhaPercentual.Size = new System.Drawing.Size(widthInput, height);
            this.txtDescontoCampanhaPercentual.ReadOnly = true;

            top += spacing;

            this.lblDescontoCampanha = new System.Windows.Forms.Label();
            this.lblDescontoCampanha.Text = "Desc. Campanha (R$):";
            this.lblDescontoCampanha.Location = new System.Drawing.Point(leftLabel, top);

            this.txtDescontoCampanha = new System.Windows.Forms.TextBox();
            this.txtDescontoCampanha.Location = new System.Drawing.Point(leftInput, top);
            this.txtDescontoCampanha.Size = new System.Drawing.Size(widthInput, height);
            this.txtDescontoCampanha.ReadOnly = true;

            top += spacing;

            this.lblValorFinal = new System.Windows.Forms.Label();
            this.lblValorFinal.Text = "Valor Final:";
            this.lblValorFinal.Location = new System.Drawing.Point(leftLabel, top);

            this.txtValorFinal = new System.Windows.Forms.TextBox();
            this.txtValorFinal.Location = new System.Drawing.Point(leftInput, top);
            this.txtValorFinal.Size = new System.Drawing.Size(widthInput, height);
            this.txtValorFinal.ReadOnly = true;

            top += spacing;

            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.lblFormaPagamento.Text = "Forma de Pagamento:";
            this.lblFormaPagamento.Location = new System.Drawing.Point(leftLabel, top);

            this.txtFormaPagamento = new System.Windows.Forms.TextBox();
            this.txtFormaPagamento.Location = new System.Drawing.Point(leftInput, top);
            this.txtFormaPagamento.Size = new System.Drawing.Size(widthInput, height);
            this.txtFormaPagamento.ReadOnly = true;

            top += spacing;

            this.lblObservacoes = new System.Windows.Forms.Label();
            this.lblObservacoes.Text = "Observações:";
            this.lblObservacoes.Location = new System.Drawing.Point(leftLabel, top);

            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.txtObservacoes.Location = new System.Drawing.Point(leftInput, top);
            this.txtObservacoes.Size = new System.Drawing.Size(widthInput, 80);
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.ReadOnly = true;

            // Form
            this.ClientSize = new System.Drawing.Size(470, top + 120);
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblCodigo, txtCodigo,
                lblData, txtData,
                lblVendedor, txtVendedor,
                lblCliente, txtCliente,
                lblValorOriginal, txtValorOriginal,
                lblDescontoPercentual, txtDescontoPercentual,
                lblDescontoValor, txtDescontoValor,
                lblCampanha, txtCampanha,
                lblDescontoCampanhaPercentual, txtDescontoCampanhaPercentual,
                lblDescontoCampanha, txtDescontoCampanha,
                lblValorFinal, txtValorFinal,
                lblFormaPagamento, txtFormaPagamento,
                lblObservacoes, txtObservacoes
            });

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalhes da Venda";
            this.ResumeLayout(false);
        }
    }
}