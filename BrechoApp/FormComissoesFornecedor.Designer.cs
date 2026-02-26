namespace BrechoApp
{
    partial class FormComissoesFornecedor
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
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

            this.lblFornecedor = new System.Windows.Forms.Label();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.btnSelecionarFornecedor = new System.Windows.Forms.Button();
            this.btnLimparFornecedor = new System.Windows.Forms.Button();

            this.btnGerarExtrato = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();

            this.grpRelatorio = new System.Windows.Forms.GroupBox();
            this.dgvRelatorio = new System.Windows.Forms.DataGridView();

            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigoVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecoFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPercentual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComissao = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlTotalizadores = new System.Windows.Forms.Panel();
            this.lblTotalItens = new System.Windows.Forms.Label();
            this.lblTotalComissao = new System.Windows.Forms.Label();

            this.btnFechar = new System.Windows.Forms.Button();

            // ============================================================
            // TÍTULO
            // ============================================================
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1200, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Extrato de Comissões do Fornecedor (PN)";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ============================================================
            // GRUPO DE FILTROS
            // ============================================================
            this.grpFiltros.Controls.Add(this.lblMes);
            this.grpFiltros.Controls.Add(this.cmbMes);
            this.grpFiltros.Controls.Add(this.lblAno);
            this.grpFiltros.Controls.Add(this.numAno);

            this.grpFiltros.Controls.Add(this.lblFornecedor);
            this.grpFiltros.Controls.Add(this.txtFornecedor);
            this.grpFiltros.Controls.Add(this.btnSelecionarFornecedor);
            this.grpFiltros.Controls.Add(this.btnLimparFornecedor);

            this.grpFiltros.Controls.Add(this.btnGerarExtrato);
            this.grpFiltros.Controls.Add(this.btnExportar);

            this.grpFiltros.Location = new System.Drawing.Point(10, 45);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(1180, 120);
            this.grpFiltros.TabIndex = 1;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";

            // Mês
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(15, 30);
            this.lblMes.Text = "Mês:";

            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.Location = new System.Drawing.Point(55, 27);
            this.cmbMes.Size = new System.Drawing.Size(150, 23);

            // Ano
            this.lblAno.AutoSize = true;
            this.lblAno.Location = new System.Drawing.Point(220, 30);
            this.lblAno.Text = "Ano:";

            this.numAno.Location = new System.Drawing.Point(258, 28);
            this.numAno.Minimum = 2020;
            this.numAno.Maximum = 2050;
            this.numAno.Size = new System.Drawing.Size(80, 23);

            // Fornecedor
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Location = new System.Drawing.Point(15, 70);
            this.lblFornecedor.Text = "Fornecedor (PN):";

            this.txtFornecedor.Location = new System.Drawing.Point(130, 67);
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(250, 23);

            this.btnSelecionarFornecedor.Location = new System.Drawing.Point(390, 66);
            this.btnSelecionarFornecedor.Size = new System.Drawing.Size(90, 25);
            this.btnSelecionarFornecedor.Text = "Selecionar";
            this.btnSelecionarFornecedor.Click += new System.EventHandler(this.btnSelecionarFornecedor_Click);

            this.btnLimparFornecedor.Location = new System.Drawing.Point(490, 66);
            this.btnLimparFornecedor.Size = new System.Drawing.Size(70, 25);
            this.btnLimparFornecedor.Text = "Limpar";
            this.btnLimparFornecedor.Click += new System.EventHandler(this.btnLimparFornecedor_Click);

            // Botão Gerar Extrato
            this.btnGerarExtrato.Location = new System.Drawing.Point(360, 25);
            this.btnGerarExtrato.Size = new System.Drawing.Size(120, 30);
            this.btnGerarExtrato.Text = "Gerar Extrato";
            this.btnGerarExtrato.Click += new System.EventHandler(this.btnGerarExtrato_Click);

            // Botão Exportar
            this.btnExportar.Location = new System.Drawing.Point(490, 25);
            this.btnExportar.Size = new System.Drawing.Size(150, 30);
            this.btnExportar.Text = "Exportar para Excel";
            this.btnExportar.Enabled = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);

            // ============================================================
            // GRID PRINCIPAL
            // ============================================================
            this.grpRelatorio.Controls.Add(this.dgvRelatorio);
            this.grpRelatorio.Location = new System.Drawing.Point(10, 170);
            this.grpRelatorio.Size = new System.Drawing.Size(1180, 400);
            this.grpRelatorio.Text = "Itens Vendidos no Período";

            this.dgvRelatorio.AllowUserToAddRows = false;
            this.dgvRelatorio.AllowUserToDeleteRows = false;
            this.dgvRelatorio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRelatorio.ReadOnly = true;
            this.dgvRelatorio.Dock = System.Windows.Forms.DockStyle.Fill;

            this.dgvRelatorio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colData,
                this.colCodigoVenda,
                this.colProduto,
                this.colMarca,
                this.colCategoria,
                this.colPrecoFinal,
                this.colPercentual,
                this.colComissao
            });

            // Colunas
            this.colData.HeaderText = "Data";
            this.colCodigoVenda.HeaderText = "Código Venda";
            this.colProduto.HeaderText = "Produto";
            this.colMarca.HeaderText = "Marca";
            this.colCategoria.HeaderText = "Categoria";
            this.colPrecoFinal.HeaderText = "Preço Final";
            this.colPercentual.HeaderText = "% PN";
            this.colComissao.HeaderText = "Comissão";

            // ============================================================
            // TOTALIZADORES
            // ============================================================
            this.pnlTotalizadores.Controls.Add(this.lblTotalItens);
            this.pnlTotalizadores.Controls.Add(this.lblTotalComissao);
            this.pnlTotalizadores.Location = new System.Drawing.Point(10, 580);
            this.pnlTotalizadores.Size = new System.Drawing.Size(1180, 40);

            this.lblTotalItens.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalItens.Location = new System.Drawing.Point(10, 10);
            this.lblTotalItens.Size = new System.Drawing.Size(300, 20);
            this.lblTotalItens.Text = "Total de Itens: 0";

            this.lblTotalComissao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalComissao.Location = new System.Drawing.Point(400, 10);
            this.lblTotalComissao.Size = new System.Drawing.Size(400, 20);
            this.lblTotalComissao.Text = "Total de Comissão: R$ 0,00";

            // ============================================================
            // BOTÃO FECHAR
            // ============================================================
            this.btnFechar.Location = new System.Drawing.Point(1090, 630);
            this.btnFechar.Size = new System.Drawing.Size(100, 35);
            this.btnFechar.Text = "Fechar";
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);

            // ============================================================
            // FORM
            // ============================================================
            this.ClientSize = new System.Drawing.Size(1200, 680);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.pnlTotalizadores);
            this.Controls.Add(this.grpRelatorio);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extrato de Comissões do Fornecedor (PN)";
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Label lblAno;
        private System.Windows.Forms.NumericUpDown numAno;

        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Button btnSelecionarFornecedor;
        private System.Windows.Forms.Button btnLimparFornecedor;

        private System.Windows.Forms.Button btnGerarExtrato;
        private System.Windows.Forms.Button btnExportar;

        private System.Windows.Forms.GroupBox grpRelatorio;
        private System.Windows.Forms.DataGridView dgvRelatorio;

        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecoFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPercentual;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComissao;

        private System.Windows.Forms.Panel pnlTotalizadores;
        private System.Windows.Forms.Label lblTotalItens;
        private System.Windows.Forms.Label lblTotalComissao;

        private System.Windows.Forms.Button btnFechar;
    }
}