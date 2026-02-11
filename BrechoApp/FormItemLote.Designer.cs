namespace BrechoApp
{
    partial class FormItemLote
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNomeItem;

        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox txtMarca;

        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtCategoria;

        private System.Windows.Forms.Label lblTamanhoCor;
        private System.Windows.Forms.TextBox txtTamanhoCor;

        private System.Windows.Forms.Label lblObservacao;
        private System.Windows.Forms.TextBox txtObservacao;

        private System.Windows.Forms.Label lblPrecoSugerido;
        private System.Windows.Forms.TextBox txtPrecoSugerido;

        private System.Windows.Forms.Label lblPrecoVenda;
        private System.Windows.Forms.TextBox txtPrecoVenda;

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatusItem;

        private System.Windows.Forms.Label lblDataCriacao;
        private System.Windows.Forms.TextBox txtDataCriacao;

        private System.Windows.Forms.Label lblCodigoProdutoGerado;
        private System.Windows.Forms.TextBox txtCodigoProdutoGerado;

        private System.Windows.Forms.Label lblDataLimite;
        private System.Windows.Forms.TextBox txtDataLimite;

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNomeItem = new System.Windows.Forms.TextBox();

            this.lblMarca = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();

            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtCategoria = new System.Windows.Forms.TextBox();

            this.lblTamanhoCor = new System.Windows.Forms.Label();
            this.txtTamanhoCor = new System.Windows.Forms.TextBox();

            this.lblObservacao = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();

            this.lblPrecoSugerido = new System.Windows.Forms.Label();
            this.txtPrecoSugerido = new System.Windows.Forms.TextBox();

            this.lblPrecoVenda = new System.Windows.Forms.Label();
            this.txtPrecoVenda = new System.Windows.Forms.TextBox();

            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatusItem = new System.Windows.Forms.ComboBox();

            this.lblDataCriacao = new System.Windows.Forms.Label();
            this.txtDataCriacao = new System.Windows.Forms.TextBox();

            this.lblCodigoProdutoGerado = new System.Windows.Forms.Label();
            this.txtCodigoProdutoGerado = new System.Windows.Forms.TextBox();

            this.lblDataLimite = new System.Windows.Forms.Label();
            this.txtDataLimite = new System.Windows.Forms.TextBox();

            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // ============================================================
            // NOME DO ITEM
            // ============================================================
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(12, 15);
            this.lblNome.Text = "Nome do Item:";

            this.txtNomeItem.Location = new System.Drawing.Point(150, 12);
            this.txtNomeItem.Size = new System.Drawing.Size(330, 23);

            // ============================================================
            // MARCA
            // ============================================================
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(12, 50);
            this.lblMarca.Text = "Marca:";

            this.txtMarca.Location = new System.Drawing.Point(150, 47);
            this.txtMarca.Size = new System.Drawing.Size(200, 23);

            // ============================================================
            // CATEGORIA
            // ============================================================
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(12, 85);
            this.lblCategoria.Text = "Categoria:";

            this.txtCategoria.Location = new System.Drawing.Point(150, 82);
            this.txtCategoria.Size = new System.Drawing.Size(200, 23);

            // ============================================================
            // TAMANHO / COR
            // ============================================================
            this.lblTamanhoCor.AutoSize = true;
            this.lblTamanhoCor.Location = new System.Drawing.Point(12, 120);
            this.lblTamanhoCor.Text = "Tamanho / Cor:";

            this.txtTamanhoCor.Location = new System.Drawing.Point(150, 117);
            this.txtTamanhoCor.Size = new System.Drawing.Size(200, 23);

            // ============================================================
            // OBSERVAÇÃO
            // ============================================================
            this.lblObservacao.AutoSize = true;
            this.lblObservacao.Location = new System.Drawing.Point(12, 155);
            this.lblObservacao.Text = "Observação:";

            this.txtObservacao.Location = new System.Drawing.Point(150, 152);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Size = new System.Drawing.Size(330, 60);

            // ============================================================
            // PREÇO SUGERIDO
            // ============================================================
            this.lblPrecoSugerido.AutoSize = true;
            this.lblPrecoSugerido.Location = new System.Drawing.Point(12, 225);
            this.lblPrecoSugerido.Text = "Preço sugerido:";

            this.txtPrecoSugerido.Location = new System.Drawing.Point(150, 222);
            this.txtPrecoSugerido.Size = new System.Drawing.Size(100, 23);
            this.txtPrecoSugerido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // ============================================================
            // PREÇO VENDA
            // ============================================================
            this.lblPrecoVenda.AutoSize = true;
            this.lblPrecoVenda.Location = new System.Drawing.Point(12, 260);
            this.lblPrecoVenda.Text = "Preço venda:";

            this.txtPrecoVenda.Location = new System.Drawing.Point(150, 257);
            this.txtPrecoVenda.Size = new System.Drawing.Size(100, 23);
            this.txtPrecoVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // ============================================================
            // STATUS (COMBOBOX)
            // ============================================================
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 295);
            this.lblStatus.Text = "Status:";

            this.cboStatusItem.Location = new System.Drawing.Point(150, 292);
            this.cboStatusItem.Size = new System.Drawing.Size(150, 23);
            this.cboStatusItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatusItem.Items.AddRange(new object[]
            {
                "Em análise",
                "Aprovado",
                "Reprovado",
                "Vendido",
                "Descartado"
            });

            // ============================================================
            // DATA DE CRIAÇÃO
            // ============================================================
            this.lblDataCriacao.AutoSize = true;
            this.lblDataCriacao.Location = new System.Drawing.Point(12, 330);
            this.lblDataCriacao.Text = "Data criação:";

            this.txtDataCriacao.Location = new System.Drawing.Point(150, 327);
            this.txtDataCriacao.Size = new System.Drawing.Size(150, 23);
            this.txtDataCriacao.ReadOnly = true;

            // ============================================================
            // CÓDIGO DO PRODUTO GERADO
            // ============================================================
            this.lblCodigoProdutoGerado.AutoSize = true;
            this.lblCodigoProdutoGerado.Location = new System.Drawing.Point(12, 365);
            this.lblCodigoProdutoGerado.Text = "Código produto:";

            this.txtCodigoProdutoGerado.Location = new System.Drawing.Point(150, 362);
            this.txtCodigoProdutoGerado.Size = new System.Drawing.Size(150, 23);
            this.txtCodigoProdutoGerado.ReadOnly = true;

            // ============================================================
            // DATA LIMITE
            // ============================================================
            this.lblDataLimite.AutoSize = true;
            this.lblDataLimite.Location = new System.Drawing.Point(12, 400);
            this.lblDataLimite.Text = "Data limite:";

            this.txtDataLimite.Location = new System.Drawing.Point(150, 397);
            this.txtDataLimite.Size = new System.Drawing.Size(150, 23);
            this.txtDataLimite.Enabled = false;

            // ============================================================
            // BOTÕES
            // ============================================================
            this.btnSalvar.Location = new System.Drawing.Point(304, 440);
            this.btnSalvar.Size = new System.Drawing.Size(75, 27);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            this.btnCancelar.Location = new System.Drawing.Point(385, 440);
            this.btnCancelar.Size = new System.Drawing.Size(75, 27);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // ============================================================
            // FORM
            // ============================================================
            this.ClientSize = new System.Drawing.Size(500, 480);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNomeItem);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.lblTamanhoCor);
            this.Controls.Add(this.txtTamanhoCor);
            this.Controls.Add(this.lblObservacao);
            this.Controls.Add(this.txtObservacao);
            this.Controls.Add(this.lblPrecoSugerido);
            this.Controls.Add(this.txtPrecoSugerido);
            this.Controls.Add(this.lblPrecoVenda);
            this.Controls.Add(this.txtPrecoVenda);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cboStatusItem);
            this.Controls.Add(this.lblDataCriacao);
            this.Controls.Add(this.txtDataCriacao);
            this.Controls.Add(this.lblCodigoProdutoGerado);
            this.Controls.Add(this.txtCodigoProdutoGerado);
            this.Controls.Add(this.lblDataLimite);
            this.Controls.Add(this.txtDataLimite);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Item do Lote";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
