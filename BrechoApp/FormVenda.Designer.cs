namespace BrechoApp
{
    partial class FormVenda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCodigoVenda = new System.Windows.Forms.TextBox();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtCodigoProduto = new System.Windows.Forms.TextBox();
            this.txtDescontoPercentual = new System.Windows.Forms.TextBox();
            this.txtDescontoValor = new System.Windows.Forms.TextBox();
            this.txtCampanha = new System.Windows.Forms.TextBox();
            this.txtDescontoCampanhaPercentual = new System.Windows.Forms.TextBox();
            this.txtDescontoCampanhaValor = new System.Windows.Forms.TextBox();
            this.txtValorTotalOriginal = new System.Windows.Forms.TextBox();
            this.txtValorTotalFinal = new System.Windows.Forms.TextBox();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.btnSelecionarVendedor = new System.Windows.Forms.Button();
            this.btnSelecionarCliente = new System.Windows.Forms.Button();
            this.btnAdicionarProduto = new System.Windows.Forms.Button();
            this.btnRemoverProduto = new System.Windows.Forms.Button();
            this.btnFinalizarVenda = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cboFormaPagamento = new System.Windows.Forms.ComboBox();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.lblCodigoVenda = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblCodigoProduto = new System.Windows.Forms.Label();
            this.lblProdutos = new System.Windows.Forms.Label();
            this.lblDescontoPercentual = new System.Windows.Forms.Label();
            this.lblDescontoValor = new System.Windows.Forms.Label();
            this.lblCampanha = new System.Windows.Forms.Label();
            this.lblDescontoCampanhaPercentual = new System.Windows.Forms.Label();
            this.lblDescontoCampanhaValor = new System.Windows.Forms.Label();
            this.lblValorTotalOriginal = new System.Windows.Forms.Label();
            this.lblValorTotalFinal = new System.Windows.Forms.Label();
            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.lblObservacoes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCodigoVenda
            // 
            this.txtCodigoVenda.Location = new System.Drawing.Point(150, 20);
            this.txtCodigoVenda.Name = "txtCodigoVenda";
            this.txtCodigoVenda.ReadOnly = true;
            this.txtCodigoVenda.Size = new System.Drawing.Size(150, 23);
            this.txtCodigoVenda.TabIndex = 0;
            // 
            // txtVendedor
            // 
            this.txtVendedor.Location = new System.Drawing.Point(150, 60);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.ReadOnly = true;
            this.txtVendedor.Size = new System.Drawing.Size(400, 23);
            this.txtVendedor.TabIndex = 1;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(150, 100);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(400, 23);
            this.txtCliente.TabIndex = 3;
            // 
            // txtCodigoProduto
            // 
            this.txtCodigoProduto.Location = new System.Drawing.Point(150, 140);
            this.txtCodigoProduto.Name = "txtCodigoProduto";
            this.txtCodigoProduto.Size = new System.Drawing.Size(200, 23);
            this.txtCodigoProduto.TabIndex = 5;
            this.txtCodigoProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProduto_KeyPress);
            // 
            // txtDescontoPercentual
            // 
            this.txtDescontoPercentual.Location = new System.Drawing.Point(150, 460);
            this.txtDescontoPercentual.Name = "txtDescontoPercentual";
            this.txtDescontoPercentual.Size = new System.Drawing.Size(100, 23);
            this.txtDescontoPercentual.TabIndex = 9;
            this.txtDescontoPercentual.Text = "0";
            this.txtDescontoPercentual.TextChanged += new System.EventHandler(this.txtDescontoPercentual_TextChanged);
            // 
            // txtDescontoValor
            // 
            this.txtDescontoValor.Location = new System.Drawing.Point(400, 460);
            this.txtDescontoValor.Name = "txtDescontoValor";
            this.txtDescontoValor.ReadOnly = true;
            this.txtDescontoValor.Size = new System.Drawing.Size(150, 23);
            this.txtDescontoValor.TabIndex = 10;
            this.txtDescontoValor.Text = "0,00";
            this.txtDescontoValor.TextChanged += new System.EventHandler(this.txtDescontoValor_TextChanged);
            // 
            // txtCampanha
            this.txtCampanha.Location = new System.Drawing.Point(150, 495);
            this.txtCampanha.MaxLength = 25;
            this.txtCampanha.Name = "txtCampanha";
            this.txtCampanha.Size = new System.Drawing.Size(180, 23);
            this.txtCampanha.TabIndex = 11;

            // txtDescontoCampanhaPercentual
            this.txtDescontoCampanhaPercentual.Location = new System.Drawing.Point(480, 495);
            this.txtDescontoCampanhaPercentual.Name = "txtDescontoCampanhaPercentual";
            this.txtDescontoCampanhaPercentual.Size = new System.Drawing.Size(60, 23);
            this.txtDescontoCampanhaPercentual.TabIndex = 12;
            this.txtDescontoCampanhaPercentual.Text = "0";
            this.txtDescontoCampanhaPercentual.TextChanged += new System.EventHandler(this.txtDescontoCampanhaPercentual_TextChanged);

            // txtDescontoCampanhaValor
            this.txtDescontoCampanhaValor.Location = new System.Drawing.Point(650, 495);
            this.txtDescontoCampanhaValor.Name = "txtDescontoCampanhaValor";
            this.txtDescontoCampanhaValor.ReadOnly = true;
            this.txtDescontoCampanhaValor.Size = new System.Drawing.Size(100, 23);
            this.txtDescontoCampanhaValor.TabIndex = 13;
            this.txtDescontoCampanhaValor.Text = "0,00";
            // 
            // txtValorTotalOriginal
            // 
            this.txtValorTotalOriginal.Location = new System.Drawing.Point(150, 540);
            this.txtValorTotalOriginal.Name = "txtValorTotalOriginal";
            this.txtValorTotalOriginal.ReadOnly = true;
            this.txtValorTotalOriginal.Size = new System.Drawing.Size(150, 23);
            this.txtValorTotalOriginal.TabIndex = 14;
            // 
            // txtValorTotalFinal
            // 
            this.txtValorTotalFinal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtValorTotalFinal.Location = new System.Drawing.Point(400, 540);
            this.txtValorTotalFinal.Name = "txtValorTotalFinal";
            this.txtValorTotalFinal.ReadOnly = true;
            this.txtValorTotalFinal.Size = new System.Drawing.Size(150, 29);
            this.txtValorTotalFinal.TabIndex = 15;
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.Location = new System.Drawing.Point(150, 620);
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.Size = new System.Drawing.Size(600, 60);
            this.txtObservacoes.TabIndex = 17;
            // 
            // btnSelecionarVendedor
            // 
            this.btnSelecionarVendedor.Location = new System.Drawing.Point(560, 60);
            this.btnSelecionarVendedor.Name = "btnSelecionarVendedor";
            this.btnSelecionarVendedor.Size = new System.Drawing.Size(190, 23);
            this.btnSelecionarVendedor.TabIndex = 2;
            this.btnSelecionarVendedor.Text = "Selecionar Vendedor";
            this.btnSelecionarVendedor.UseVisualStyleBackColor = true;
            this.btnSelecionarVendedor.Click += new System.EventHandler(this.btnSelecionarVendedor_Click);
            // 
            // btnSelecionarCliente
            // 
            this.btnSelecionarCliente.Location = new System.Drawing.Point(560, 100);
            this.btnSelecionarCliente.Name = "btnSelecionarCliente";
            this.btnSelecionarCliente.Size = new System.Drawing.Size(190, 23);
            this.btnSelecionarCliente.TabIndex = 4;
            this.btnSelecionarCliente.Text = "Selecionar Cliente";
            this.btnSelecionarCliente.UseVisualStyleBackColor = true;
            this.btnSelecionarCliente.Click += new System.EventHandler(this.btnSelecionarCliente_Click);
            // 
            // btnAdicionarProduto
            // 
            this.btnAdicionarProduto.Location = new System.Drawing.Point(360, 140);
            this.btnAdicionarProduto.Name = "btnAdicionarProduto";
            this.btnAdicionarProduto.Size = new System.Drawing.Size(150, 23);
            this.btnAdicionarProduto.TabIndex = 6;
            this.btnAdicionarProduto.Text = "Adicionar Produto";
            this.btnAdicionarProduto.UseVisualStyleBackColor = true;
            this.btnAdicionarProduto.Click += new System.EventHandler(this.btnAdicionarProduto_Click);
            // 
            // btnRemoverProduto
            // 
            this.btnRemoverProduto.Location = new System.Drawing.Point(520, 140);
            this.btnRemoverProduto.Name = "btnRemoverProduto";
            this.btnRemoverProduto.Size = new System.Drawing.Size(150, 23);
            this.btnRemoverProduto.TabIndex = 7;
            this.btnRemoverProduto.Text = "Remover Produto";
            this.btnRemoverProduto.UseVisualStyleBackColor = true;
            this.btnRemoverProduto.Click += new System.EventHandler(this.btnRemoverProduto_Click);
            // 
            // btnFinalizarVenda
            // 
            this.btnFinalizarVenda.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnFinalizarVenda.Location = new System.Drawing.Point(150, 695);
            this.btnFinalizarVenda.Name = "btnFinalizarVenda";
            this.btnFinalizarVenda.Size = new System.Drawing.Size(300, 40);
            this.btnFinalizarVenda.TabIndex = 18;
            this.btnFinalizarVenda.Text = "Finalizar Venda";
            this.btnFinalizarVenda.UseVisualStyleBackColor = true;
            this.btnFinalizarVenda.Click += new System.EventHandler(this.btnFinalizarVenda_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(470, 695);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(280, 40);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cboFormaPagamento (hidden - moved to FormPagamentoVenda)
            // 
            this.cboFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormaPagamento.FormattingEnabled = true;
            this.cboFormaPagamento.Items.AddRange(new object[] {
            "Dinheiro",
            "PIX",
            "Débito",
            "Crédito",
            "Transferência",
            "Combinado",
            "Futuro"});
            this.cboFormaPagamento.Location = new System.Drawing.Point(180, 580);
            this.cboFormaPagamento.Name = "cboFormaPagamento";
            this.cboFormaPagamento.Size = new System.Drawing.Size(200, 23);
            this.cboFormaPagamento.TabIndex = 16;
            this.cboFormaPagamento.Visible = false;
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Location = new System.Drawing.Point(150, 200);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new System.Drawing.Size(600, 240);
            this.dgvProdutos.TabIndex = 8;
            // 
            // lblCodigoVenda
            // 
            this.lblCodigoVenda.AutoSize = true;
            this.lblCodigoVenda.Location = new System.Drawing.Point(30, 23);
            this.lblCodigoVenda.Name = "lblCodigoVenda";
            this.lblCodigoVenda.Size = new System.Drawing.Size(98, 15);
            this.lblCodigoVenda.TabIndex = 100;
            this.lblCodigoVenda.Text = "Código da Venda:";
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(30, 63);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(62, 15);
            this.lblVendedor.TabIndex = 101;
            this.lblVendedor.Text = "Vendedor:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(30, 103);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(47, 15);
            this.lblCliente.TabIndex = 102;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblCodigoProduto
            // 
            this.lblCodigoProduto.AutoSize = true;
            this.lblCodigoProduto.Location = new System.Drawing.Point(30, 143);
            this.lblCodigoProduto.Name = "lblCodigoProduto";
            this.lblCodigoProduto.Size = new System.Drawing.Size(111, 15);
            this.lblCodigoProduto.TabIndex = 103;
            this.lblCodigoProduto.Text = "Código do Produto:";
            // 
            // lblProdutos
            // 
            this.lblProdutos.AutoSize = true;
            this.lblProdutos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProdutos.Location = new System.Drawing.Point(30, 180);
            this.lblProdutos.Name = "lblProdutos";
            this.lblProdutos.Size = new System.Drawing.Size(131, 15);
            this.lblProdutos.TabIndex = 104;
            this.lblProdutos.Text = "Produtos Adicionados:";
            // 
            // lblDescontoPercentual
            // 
            this.lblDescontoPercentual.AutoSize = true;
            this.lblDescontoPercentual.Location = new System.Drawing.Point(30, 463);
            this.lblDescontoPercentual.Name = "lblDescontoPercentual";
            this.lblDescontoPercentual.Size = new System.Drawing.Size(77, 15);
            this.lblDescontoPercentual.TabIndex = 105;
            this.lblDescontoPercentual.Text = "Desconto %:";
            // 
            // lblDescontoValor
            // 
            this.lblDescontoValor.AutoSize = true;
            this.lblDescontoValor.Location = new System.Drawing.Point(260, 463);
            this.lblDescontoValor.Name = "lblDescontoValor";
            this.lblDescontoValor.Size = new System.Drawing.Size(82, 15);
            this.lblDescontoValor.TabIndex = 106;
            this.lblDescontoValor.Text = "Desconto Ger R$:";
            // 
            // lblCampanha
            // 
            this.lblCampanha.AutoSize = true;
            this.lblCampanha.Location = new System.Drawing.Point(30, 498);
            this.lblCampanha.Name = "lblCampanha";
            this.lblCampanha.Size = new System.Drawing.Size(67, 15);
            this.lblCampanha.TabIndex = 107;
            this.lblCampanha.Text = "Campanha:";
            // 
            // lblDescontoCampanhaPercentual
            // 
            this.lblDescontoCampanhaPercentual.AutoSize = true;
            this.lblDescontoCampanhaPercentual.Location = new System.Drawing.Point(360, 498);
            this.lblDescontoCampanhaPercentual.Name = "lblDescontoCampanhaPercentual";
            this.lblDescontoCampanhaPercentual.Size = new System.Drawing.Size(114, 15);
            this.lblDescontoCampanhaPercentual.TabIndex = 108;
            this.lblDescontoCampanhaPercentual.Text = "Desconto Camp %:";
            // 
            // lblDescontoCampanhaValor
            // 
            this.lblDescontoCampanhaValor.AutoSize = true;
            this.lblDescontoCampanhaValor.Location = new System.Drawing.Point(540, 498);
            this.lblDescontoCampanhaValor.Name = "lblDescontoCampanhaValor";
            this.lblDescontoCampanhaValor.Size = new System.Drawing.Size(104, 15);
            this.lblDescontoCampanhaValor.TabIndex = 109;
            this.lblDescontoCampanhaValor.Text = "Desc Camp R$:";
            // 
            // lblValorTotalOriginal
            // 
            this.lblValorTotalOriginal.AutoSize = true;
            this.lblValorTotalOriginal.Location = new System.Drawing.Point(30, 543);
            this.lblValorTotalOriginal.Name = "lblValorTotalOriginal";
            this.lblValorTotalOriginal.Size = new System.Drawing.Size(104, 15);
            this.lblValorTotalOriginal.TabIndex = 110;
            this.lblValorTotalOriginal.Text = "Valor Total Original:";
            // 
            // lblValorTotalFinal
            // 
            this.lblValorTotalFinal.AutoSize = true;
            this.lblValorTotalFinal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblValorTotalFinal.Location = new System.Drawing.Point(310, 543);
            this.lblValorTotalFinal.Name = "lblValorTotalFinal";
            this.lblValorTotalFinal.Size = new System.Drawing.Size(82, 19);
            this.lblValorTotalFinal.TabIndex = 111;
            this.lblValorTotalFinal.Text = "Valor Final:";
            // 
            // lblFormaPagamento (hidden - moved to FormPagamentoVenda)
            // 
            this.lblFormaPagamento.AutoSize = true;
            this.lblFormaPagamento.Location = new System.Drawing.Point(30, 583);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(120, 15);
            this.lblFormaPagamento.TabIndex = 112;
            this.lblFormaPagamento.Text = "Forma de Pagamento:";
            this.lblFormaPagamento.Visible = false;
            // 
            // lblObservacoes
            // 
            this.lblObservacoes.AutoSize = true;
            this.lblObservacoes.Location = new System.Drawing.Point(30, 623);
            this.lblObservacoes.Name = "lblObservacoes";
            this.lblObservacoes.Size = new System.Drawing.Size(77, 15);
            this.lblObservacoes.TabIndex = 113;
            this.lblObservacoes.Text = "Observações:";
            // 
            // FormVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 750);
            this.Controls.Add(this.lblObservacoes);
            this.Controls.Add(this.lblFormaPagamento);
            this.Controls.Add(this.lblValorTotalFinal);
            this.Controls.Add(this.lblValorTotalOriginal);
            this.Controls.Add(this.lblDescontoCampanhaValor);
            this.Controls.Add(this.lblDescontoCampanhaPercentual);
            this.Controls.Add(this.lblCampanha);
            this.Controls.Add(this.lblDescontoValor);
            this.Controls.Add(this.lblDescontoPercentual);
            this.Controls.Add(this.lblProdutos);
            this.Controls.Add(this.lblCodigoProduto);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.lblCodigoVenda);
            this.Controls.Add(this.dgvProdutos);
            this.Controls.Add(this.cboFormaPagamento);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnFinalizarVenda);
            this.Controls.Add(this.btnRemoverProduto);
            this.Controls.Add(this.btnAdicionarProduto);
            this.Controls.Add(this.btnSelecionarCliente);
            this.Controls.Add(this.btnSelecionarVendedor);
            this.Controls.Add(this.txtObservacoes);
            this.Controls.Add(this.txtValorTotalFinal);
            this.Controls.Add(this.txtValorTotalOriginal);
            this.Controls.Add(this.txtDescontoCampanhaValor);
            this.Controls.Add(this.txtDescontoCampanhaPercentual);
            this.Controls.Add(this.txtCampanha);
            this.Controls.Add(this.txtDescontoValor);
            this.Controls.Add(this.txtDescontoPercentual);
            this.Controls.Add(this.txtCodigoProduto);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtVendedor);
            this.Controls.Add(this.txtCodigoVenda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Venda";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtCodigoVenda;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtCodigoProduto;
        private System.Windows.Forms.TextBox txtDescontoPercentual;
        private System.Windows.Forms.TextBox txtDescontoValor;
        private System.Windows.Forms.TextBox txtCampanha;
        private System.Windows.Forms.TextBox txtDescontoCampanhaPercentual;
        private System.Windows.Forms.TextBox txtDescontoCampanhaValor;
        private System.Windows.Forms.TextBox txtValorTotalOriginal;
        private System.Windows.Forms.TextBox txtValorTotalFinal;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.Button btnSelecionarVendedor;
        private System.Windows.Forms.Button btnSelecionarCliente;
        private System.Windows.Forms.Button btnAdicionarProduto;
        private System.Windows.Forms.Button btnRemoverProduto;
        private System.Windows.Forms.Button btnFinalizarVenda;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cboFormaPagamento;
        public System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.Label lblCodigoVenda;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblCodigoProduto;
        private System.Windows.Forms.Label lblProdutos;
        private System.Windows.Forms.Label lblDescontoPercentual;
        private System.Windows.Forms.Label lblDescontoValor;
        private System.Windows.Forms.Label lblCampanha;
        private System.Windows.Forms.Label lblDescontoCampanhaPercentual;
        private System.Windows.Forms.Label lblDescontoCampanhaValor;
        private System.Windows.Forms.Label lblValorTotalOriginal;
        private System.Windows.Forms.Label lblValorTotalFinal;
        private System.Windows.Forms.Label lblFormaPagamento;
        private System.Windows.Forms.Label lblObservacoes;
    }
}


