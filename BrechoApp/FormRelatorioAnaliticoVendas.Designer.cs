namespace BrechoApp
{
    partial class FormRelatorioAnaliticoVendas
    {
        private System.ComponentModel.IContainer components = null;

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
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.lblMes = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.lblAno = new System.Windows.Forms.Label();
            this.numAno = new System.Windows.Forms.NumericUpDown();
            this.btnGerar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.dgvRelatorio = new System.Windows.Forms.DataGridView();
            this.lblTotalItens = new System.Windows.Forms.Label();
            this.lblTotalArrecadado = new System.Windows.Forms.Label();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorio)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFiltros
            // 
            this.panelFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFiltros.Controls.Add(this.lblMes);
            this.panelFiltros.Controls.Add(this.cmbMes);
            this.panelFiltros.Controls.Add(this.lblAno);
            this.panelFiltros.Controls.Add(this.numAno);
            this.panelFiltros.Controls.Add(this.btnGerar);
            this.panelFiltros.Controls.Add(this.btnExportar);
            this.panelFiltros.Controls.Add(this.btnFechar);
            this.panelFiltros.Location = new System.Drawing.Point(10, 10);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(1080, 60);
            this.panelFiltros.TabIndex = 0;
            // 
            // lblMes
            // 
            this.lblMes.Text = "Mês:";
            this.lblMes.Location = new System.Drawing.Point(10, 20);
            this.lblMes.Size = new System.Drawing.Size(40, 20);
            // 
            // cmbMes
            // 
            this.cmbMes.Location = new System.Drawing.Point(60, 17);
            this.cmbMes.Size = new System.Drawing.Size(150, 23);
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // lblAno
            // 
            this.lblAno.Text = "Ano:";
            this.lblAno.Location = new System.Drawing.Point(230, 20);
            this.lblAno.Size = new System.Drawing.Size(40, 20);
            // 
            // numAno
            // 
            this.numAno.Location = new System.Drawing.Point(270, 17);
            this.numAno.Size = new System.Drawing.Size(80, 23);
            // (mínimo/máximo/valor são configurados no código .cs, em ConfigurarFormulario)
            // 
            // btnGerar
            // 
            this.btnGerar.Text = "Gerar";
            this.btnGerar.Location = new System.Drawing.Point(400, 15);
            this.btnGerar.Size = new System.Drawing.Size(100, 30);
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Text = "Exportar";
            this.btnExportar.Location = new System.Drawing.Point(510, 15);
            this.btnExportar.Size = new System.Drawing.Size(100, 30);
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Text = "Fechar";
            this.btnFechar.Location = new System.Drawing.Point(620, 15);
            this.btnFechar.Size = new System.Drawing.Size(100, 30);
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // dgvRelatorio
            // 
            this.dgvRelatorio.Location = new System.Drawing.Point(10, 80);
            this.dgvRelatorio.Size = new System.Drawing.Size(1080, 480);
            this.dgvRelatorio.AllowUserToAddRows = false;
            this.dgvRelatorio.AllowUserToDeleteRows = false;
            this.dgvRelatorio.ReadOnly = true;
            this.dgvRelatorio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRelatorio.MultiSelect = false;
            this.dgvRelatorio.RowHeadersVisible = false;
            this.dgvRelatorio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvRelatorio.Columns.Add("colData", "Data");
            this.dgvRelatorio.Columns.Add("colVendedor", "Vendedor");
            this.dgvRelatorio.Columns.Add("colCliente", "Cliente");
            this.dgvRelatorio.Columns.Add("colCodigo", "Código Produto");
            this.dgvRelatorio.Columns.Add("colDescricao", "Descrição");
            this.dgvRelatorio.Columns.Add("colMarca", "Marca");
            this.dgvRelatorio.Columns.Add("colCategoria", "Categoria");
            this.dgvRelatorio.Columns.Add("colFornecedor", "Fornecedor");
            this.dgvRelatorio.Columns.Add("colDescValor", "Desc R$");
            this.dgvRelatorio.Columns.Add("colDescCamp", "Desc Camp R$");
            this.dgvRelatorio.Columns.Add("colCampanha", "Campanha");
            this.dgvRelatorio.Columns.Add("colPrecoOrig", "Preço Original");
            this.dgvRelatorio.Columns.Add("colPrecoFinal", "Preço Final");
            // 
            // lblTotalItens
            // 
            this.lblTotalItens.Text = "Total de Itens: 0";
            this.lblTotalItens.Location = new System.Drawing.Point(10, 570);
            this.lblTotalItens.Size = new System.Drawing.Size(300, 25);
            this.lblTotalItens.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            // 
            // lblTotalArrecadado
            // 
            this.lblTotalArrecadado.Text = "Total Arrecadado: R$ 0,00";
            this.lblTotalArrecadado.Location = new System.Drawing.Point(300, 570);
            this.lblTotalArrecadado.Size = new System.Drawing.Size(400, 25);
            this.lblTotalArrecadado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            // 
            // FormRelatorioAnaliticoVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 610);
            this.Controls.Add(this.lblTotalArrecadado);
            this.Controls.Add(this.lblTotalItens);
            this.Controls.Add(this.dgvRelatorio);
            this.Controls.Add(this.panelFiltros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRelatorioAnaliticoVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório Analítico de Vendas";
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorio)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Label lblAno;
        private System.Windows.Forms.NumericUpDown numAno;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.DataGridView dgvRelatorio;
        private System.Windows.Forms.Label lblTotalItens;
        private System.Windows.Forms.Label lblTotalArrecadado;
    }
}

