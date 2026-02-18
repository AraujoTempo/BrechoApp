namespace BrechoApp
{
    partial class FormRelatorioVendasMes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.lblMes = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.lblAno = new System.Windows.Forms.Label();
            this.numAno = new System.Windows.Forms.NumericUpDown();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.btnSelecionarVendedor = new System.Windows.Forms.Button();
            this.btnLimparVendedor = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnSelecionarCliente = new System.Windows.Forms.Button();
            this.btnLimparCliente = new System.Windows.Forms.Button();
            this.btnGerar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.grpRelatorio = new System.Windows.Forms.GroupBox();
            this.dgvRelatorio = new System.Windows.Forms.DataGridView();
            this.colIdVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigoVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFormaPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescontoPerc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescontoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescontoCampanhaPerc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescontoCampanhaValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorOriginal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpItens = new System.Windows.Forms.GroupBox();
            this.dgvItens = new System.Windows.Forms.DataGridView();
            this.colProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecoOriginal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecoFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTotalizadores = new System.Windows.Forms.Panel();
            this.lblTotalVendas = new System.Windows.Forms.Label();
            this.lblTotalArrecadado = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).BeginInit();
            this.grpRelatorio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorio)).BeginInit();
            this.grpItens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).BeginInit();
            this.pnlTotalizadores.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1200, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Relatório de Vendas do Mês";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.lblMes);
            this.grpFiltros.Controls.Add(this.cmbMes);
            this.grpFiltros.Controls.Add(this.lblAno);
            this.grpFiltros.Controls.Add(this.numAno);
            this.grpFiltros.Controls.Add(this.lblVendedor);
            this.grpFiltros.Controls.Add(this.txtVendedor);
            this.grpFiltros.Controls.Add(this.btnSelecionarVendedor);
            this.grpFiltros.Controls.Add(this.btnLimparVendedor);
            this.grpFiltros.Controls.Add(this.lblCliente);
            this.grpFiltros.Controls.Add(this.txtCliente);
            this.grpFiltros.Controls.Add(this.btnSelecionarCliente);
            this.grpFiltros.Controls.Add(this.btnLimparCliente);
            this.grpFiltros.Controls.Add(this.btnGerar);
            this.grpFiltros.Controls.Add(this.btnExportar);
            this.grpFiltros.Location = new System.Drawing.Point(10, 45);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(1180, 120);
            this.grpFiltros.TabIndex = 1;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(15, 30);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(33, 15);
            this.lblMes.TabIndex = 0;
            this.lblMes.Text = "Mês:";
            // 
            // cmbMes
            // 
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Location = new System.Drawing.Point(55, 27);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(150, 23);
            this.cmbMes.TabIndex = 1;
            // 
            // lblAno
            // 
            this.lblAno.AutoSize = true;
            this.lblAno.Location = new System.Drawing.Point(220, 30);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(32, 15);
            this.lblAno.TabIndex = 2;
            this.lblAno.Text = "Ano:";
            // 
            // numAno
            // 
            this.numAno.Location = new System.Drawing.Point(258, 28);
            this.numAno.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.numAno.Minimum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numAno.Name = "numAno";
            this.numAno.Size = new System.Drawing.Size(80, 23);
            this.numAno.TabIndex = 3;
            this.numAno.Value = new decimal(new int[] {
            2026,
            0,
            0,
            0});
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(15, 65);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(60, 15);
            this.lblVendedor.TabIndex = 4;
            this.lblVendedor.Text = "Vendedor:";
            // 
            // txtVendedor
            // 
            this.txtVendedor.Location = new System.Drawing.Point(80, 62);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.ReadOnly = true;
            this.txtVendedor.Size = new System.Drawing.Size(250, 23);
            this.txtVendedor.TabIndex = 5;
            // 
            // btnSelecionarVendedor
            // 
            this.btnSelecionarVendedor.Location = new System.Drawing.Point(340, 61);
            this.btnSelecionarVendedor.Name = "btnSelecionarVendedor";
            this.btnSelecionarVendedor.Size = new System.Drawing.Size(90, 25);
            this.btnSelecionarVendedor.TabIndex = 6;
            this.btnSelecionarVendedor.Text = "Selecionar";
            this.btnSelecionarVendedor.UseVisualStyleBackColor = true;
            this.btnSelecionarVendedor.Click += new System.EventHandler(this.btnSelecionarVendedor_Click);
            // 
            // btnLimparVendedor
            // 
            this.btnLimparVendedor.Location = new System.Drawing.Point(440, 61);
            this.btnLimparVendedor.Name = "btnLimparVendedor";
            this.btnLimparVendedor.Size = new System.Drawing.Size(70, 25);
            this.btnLimparVendedor.TabIndex = 7;
            this.btnLimparVendedor.Text = "Limpar";
            this.btnLimparVendedor.UseVisualStyleBackColor = true;
            this.btnLimparVendedor.Click += new System.EventHandler(this.btnLimparVendedor_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(530, 65);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(47, 15);
            this.lblCliente.TabIndex = 8;
            this.lblCliente.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(580, 62);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(250, 23);
            this.txtCliente.TabIndex = 9;
            // 
            // btnSelecionarCliente
            // 
            this.btnSelecionarCliente.Location = new System.Drawing.Point(840, 61);
            this.btnSelecionarCliente.Name = "btnSelecionarCliente";
            this.btnSelecionarCliente.Size = new System.Drawing.Size(90, 25);
            this.btnSelecionarCliente.TabIndex = 10;
            this.btnSelecionarCliente.Text = "Selecionar";
            this.btnSelecionarCliente.UseVisualStyleBackColor = true;
            this.btnSelecionarCliente.Click += new System.EventHandler(this.btnSelecionarCliente_Click);
            // 
            // btnLimparCliente
            // 
            this.btnLimparCliente.Location = new System.Drawing.Point(940, 61);
            this.btnLimparCliente.Name = "btnLimparCliente";
            this.btnLimparCliente.Size = new System.Drawing.Size(70, 25);
            this.btnLimparCliente.TabIndex = 11;
            this.btnLimparCliente.Text = "Limpar";
            this.btnLimparCliente.UseVisualStyleBackColor = true;
            this.btnLimparCliente.Click += new System.EventHandler(this.btnLimparCliente_Click);
            // 
            // btnGerar
            // 
            this.btnGerar.Location = new System.Drawing.Point(360, 25);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(120, 30);
            this.btnGerar.TabIndex = 12;
            this.btnGerar.Text = "Gerar Relatório";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Enabled = false;
            this.btnExportar.Location = new System.Drawing.Point(490, 25);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(150, 30);
            this.btnExportar.TabIndex = 13;
            this.btnExportar.Text = "Exportar para Excel";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // grpRelatorio
            // 
            this.grpRelatorio.Controls.Add(this.dgvRelatorio);
            this.grpRelatorio.Location = new System.Drawing.Point(10, 170);
            this.grpRelatorio.Name = "grpRelatorio";
            this.grpRelatorio.Size = new System.Drawing.Size(1180, 300);
            this.grpRelatorio.TabIndex = 2;
            this.grpRelatorio.TabStop = false;
            this.grpRelatorio.Text = "Vendas do Período";
            // 
            // dgvRelatorio
            // 
            this.dgvRelatorio.AllowUserToAddRows = false;
            this.dgvRelatorio.AllowUserToDeleteRows = false;
            this.dgvRelatorio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRelatorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatorio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdVenda,
            this.colCodigoVenda,
            this.colDataVenda,
            this.colVendedor,
            this.colCliente,
            this.colFormaPagamento,
            this.colDescontoPerc,
            this.colDescontoValor,
            this.colDescontoCampanhaPerc,
            this.colDescontoCampanhaValor,
            this.colValorOriginal,
            this.colValorFinal});
            this.dgvRelatorio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRelatorio.Location = new System.Drawing.Point(3, 19);
            this.dgvRelatorio.MultiSelect = false;
            this.dgvRelatorio.Name = "dgvRelatorio";
            this.dgvRelatorio.ReadOnly = true;
            this.dgvRelatorio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRelatorio.Size = new System.Drawing.Size(1174, 278);
            this.dgvRelatorio.TabIndex = 0;
            this.dgvRelatorio.SelectionChanged += new System.EventHandler(this.dgvRelatorio_SelectionChanged);
            // 
            // colIdVenda
            // 
            this.colIdVenda.HeaderText = "Id";
            this.colIdVenda.Name = "colIdVenda";
            this.colIdVenda.ReadOnly = true;
            this.colIdVenda.Visible = false;
            // 
            // colCodigoVenda
            // 
            this.colCodigoVenda.HeaderText = "Código";
            this.colCodigoVenda.Name = "colCodigoVenda";
            this.colCodigoVenda.ReadOnly = true;
            // 
            // colDataVenda
            // 
            this.colDataVenda.HeaderText = "Data";
            this.colDataVenda.Name = "colDataVenda";
            this.colDataVenda.ReadOnly = true;
            // 
            // colVendedor
            // 
            this.colVendedor.HeaderText = "Vendedor";
            this.colVendedor.Name = "colVendedor";
            this.colVendedor.ReadOnly = true;
            // 
            // colCliente
            // 
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            // 
            // colFormaPagamento
            // 
            this.colFormaPagamento.HeaderText = "Forma Pag.";
            this.colFormaPagamento.Name = "colFormaPagamento";
            this.colFormaPagamento.ReadOnly = true;
            // 
            // colDescontoPerc
            // 
            this.colDescontoPerc.HeaderText = "Desc (%)";
            this.colDescontoPerc.Name = "colDescontoPerc";
            this.colDescontoPerc.ReadOnly = true;
            // 
            // colDescontoValor
            // 
            this.colDescontoValor.HeaderText = "Desc (R$)";
            this.colDescontoValor.Name = "colDescontoValor";
            this.colDescontoValor.ReadOnly = true;
            // 
            // colDescontoCampanhaPerc
            // 
            this.colDescontoCampanhaPerc.HeaderText = "Desc Camp (%)";
            this.colDescontoCampanhaPerc.Name = "colDescontoCampanhaPerc";
            this.colDescontoCampanhaPerc.ReadOnly = true;
            // 
            // colDescontoCampanhaValor
            // 
            this.colDescontoCampanhaValor.HeaderText = "Desc Camp (R$)";
            this.colDescontoCampanhaValor.Name = "colDescontoCampanhaValor";
            this.colDescontoCampanhaValor.ReadOnly = true;
            // 
            // colValorOriginal
            // 
            this.colValorOriginal.HeaderText = "Total Orig.";
            this.colValorOriginal.Name = "colValorOriginal";
            this.colValorOriginal.ReadOnly = true;
            // 
            // colValorFinal
            // 
            this.colValorFinal.HeaderText = "Total Final";
            this.colValorFinal.Name = "colValorFinal";
            this.colValorFinal.ReadOnly = true;
            // 
            // grpItens
            // 
            this.grpItens.Controls.Add(this.dgvItens);
            this.grpItens.Location = new System.Drawing.Point(10, 480);
            this.grpItens.Name = "grpItens";
            this.grpItens.Size = new System.Drawing.Size(1180, 200);
            this.grpItens.TabIndex = 3;
            this.grpItens.TabStop = false;
            this.grpItens.Text = "Itens da Venda Selecionada";
            // 
            // dgvItens
            // 
            this.dgvItens.AllowUserToAddRows = false;
            this.dgvItens.AllowUserToDeleteRows = false;
            this.dgvItens.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProduto,
            this.colDescricao,
            this.colMarca,
            this.colCategoria,
            this.colFornecedor,
            this.colPrecoOriginal,
            this.colPrecoFinal});
            this.dgvItens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItens.Location = new System.Drawing.Point(3, 19);
            this.dgvItens.Name = "dgvItens";
            this.dgvItens.ReadOnly = true;
            this.dgvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItens.Size = new System.Drawing.Size(1174, 178);
            this.dgvItens.TabIndex = 0;
            // 
            // colProduto
            // 
            this.colProduto.HeaderText = "Código Produto";
            this.colProduto.Name = "colProduto";
            this.colProduto.ReadOnly = true;
            // 
            // colDescricao
            // 
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            // 
            // colMarca
            // 
            this.colMarca.HeaderText = "Marca";
            this.colMarca.Name = "colMarca";
            this.colMarca.ReadOnly = true;
            // 
            // colCategoria
            // 
            this.colCategoria.HeaderText = "Categoria";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            // 
            // colFornecedor
            // 
            this.colFornecedor.HeaderText = "Fornecedor";
            this.colFornecedor.Name = "colFornecedor";
            this.colFornecedor.ReadOnly = true;
            // 
            // colPrecoOriginal
            // 
            this.colPrecoOriginal.HeaderText = "Preço Orig.";
            this.colPrecoOriginal.Name = "colPrecoOriginal";
            this.colPrecoOriginal.ReadOnly = true;
            // 
            // colPrecoFinal
            // 
            this.colPrecoFinal.HeaderText = "Preço Final";
            this.colPrecoFinal.Name = "colPrecoFinal";
            this.colPrecoFinal.ReadOnly = true;
            // 
            // pnlTotalizadores
            // 
            this.pnlTotalizadores.Controls.Add(this.lblTotalVendas);
            this.pnlTotalizadores.Controls.Add(this.lblTotalArrecadado);
            this.pnlTotalizadores.Location = new System.Drawing.Point(10, 690);
            this.pnlTotalizadores.Name = "pnlTotalizadores";
            this.pnlTotalizadores.Size = new System.Drawing.Size(1180, 40);
            this.pnlTotalizadores.TabIndex = 4;
            // 
            // lblTotalVendas
            // 
            this.lblTotalVendas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalVendas.Location = new System.Drawing.Point(10, 10);
            this.lblTotalVendas.Name = "lblTotalVendas";
            this.lblTotalVendas.Size = new System.Drawing.Size(300, 20);
            this.lblTotalVendas.TabIndex = 0;
            this.lblTotalVendas.Text = "Total de Vendas: 0";
            // 
            // lblTotalArrecadado
            // 
            this.lblTotalArrecadado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalArrecadado.Location = new System.Drawing.Point(400, 10);
            this.lblTotalArrecadado.Name = "lblTotalArrecadado";
            this.lblTotalArrecadado.Size = new System.Drawing.Size(400, 20);
            this.lblTotalArrecadado.TabIndex = 1;
            this.lblTotalArrecadado.Text = "Total Arrecadado: R$ 0,00";
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(1090, 740);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(100, 35);
            this.btnFechar.TabIndex = 5;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // FormRelatorioVendasMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 785);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.pnlTotalizadores);
            this.Controls.Add(this.grpItens);
            this.Controls.Add(this.grpRelatorio);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRelatorioVendasMes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Vendas do Mês";
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).EndInit();
            this.grpRelatorio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorio)).EndInit();
            this.grpItens.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).EndInit();
            this.pnlTotalizadores.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Label lblAno;
        private System.Windows.Forms.NumericUpDown numAno;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.Button btnSelecionarVendedor;
        private System.Windows.Forms.Button btnLimparVendedor;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnSelecionarCliente;
        private System.Windows.Forms.Button btnLimparCliente;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.GroupBox grpRelatorio;
        private System.Windows.Forms.DataGridView dgvRelatorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormaPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescontoPerc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescontoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescontoCampanhaPerc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescontoCampanhaValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorOriginal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorFinal;
        private System.Windows.Forms.GroupBox grpItens;
        private System.Windows.Forms.DataGridView dgvItens;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecoOriginal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecoFinal;
        private System.Windows.Forms.Panel pnlTotalizadores;
        private System.Windows.Forms.Label lblTotalVendas;
        private System.Windows.Forms.Label lblTotalArrecadado;
        private System.Windows.Forms.Button btnFechar;
    }
}
