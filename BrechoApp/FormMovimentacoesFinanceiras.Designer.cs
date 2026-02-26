namespace BrechoApp
{
    partial class FormMovimentacoesFinanceiras
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
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblFim = new System.Windows.Forms.Label();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.dtFim = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar = new System.Windows.Forms.Button();

            this.dgvMov = new System.Windows.Forms.DataGridView();

            this.btnEntrada = new System.Windows.Forms.Button();
            this.btnSaida = new System.Windows.Forms.Button();
            this.btnTransferencia = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvMov)).BeginInit();
            this.SuspendLayout();

            // ============================================================
            // FILTROS
            // ============================================================
            this.lblInicio.Text = "Início:";
            this.lblInicio.Location = new System.Drawing.Point(10, 15);

            this.dtInicio.Location = new System.Drawing.Point(60, 12);
            this.dtInicio.Size = new System.Drawing.Size(150, 23);

            this.lblFim.Text = "Fim:";
            this.lblFim.Location = new System.Drawing.Point(230, 15);

            this.dtFim.Location = new System.Drawing.Point(270, 12);
            this.dtFim.Size = new System.Drawing.Size(150, 23);

            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Location = new System.Drawing.Point(440, 10);
            this.btnFiltrar.Size = new System.Drawing.Size(80, 28);
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            // ============================================================
            // GRID
            // ============================================================
            this.dgvMov.Location = new System.Drawing.Point(10, 50);
            this.dgvMov.Size = new System.Drawing.Size(760, 350);
            this.dgvMov.AllowUserToAddRows = false;
            this.dgvMov.AllowUserToDeleteRows = false;
            this.dgvMov.ReadOnly = true;
            this.dgvMov.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMov.MultiSelect = false;
            this.dgvMov.RowHeadersVisible = false;
            this.dgvMov.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvMov.Columns.Add("colId", "ID");
            this.dgvMov.Columns.Add("colData", "Data");
            this.dgvMov.Columns.Add("colTipo", "Tipo");
            this.dgvMov.Columns.Add("colValor", "Valor");
            this.dgvMov.Columns.Add("colOrigem", "Centro Origem");
            this.dgvMov.Columns.Add("colDestino", "Centro Destino");
            this.dgvMov.Columns.Add("colCategoria", "Categoria");
            this.dgvMov.Columns.Add("colDescricao", "Descrição");

            // ============================================================
            // BOTÕES
            // ============================================================
            this.btnEntrada.Text = "Nova Entrada";
            this.btnEntrada.Location = new System.Drawing.Point(10, 410);
            this.btnEntrada.Size = new System.Drawing.Size(120, 30);
            this.btnEntrada.Click += new System.EventHandler(this.btnEntrada_Click);

            this.btnSaida.Text = "Nova Saída";
            this.btnSaida.Location = new System.Drawing.Point(140, 410);
            this.btnSaida.Size = new System.Drawing.Size(120, 30);
            this.btnSaida.Click += new System.EventHandler(this.btnSaida_Click);

            this.btnTransferencia.Text = "Transferência";
            this.btnTransferencia.Location = new System.Drawing.Point(270, 410);
            this.btnTransferencia.Size = new System.Drawing.Size(120, 30);
            this.btnTransferencia.Click += new System.EventHandler(this.btnTransferencia_Click);

            this.btnFechar.Text = "Fechar";
            this.btnFechar.Location = new System.Drawing.Point(650, 410);
            this.btnFechar.Size = new System.Drawing.Size(120, 30);
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);

            // ============================================================
            // FORM
            // ============================================================
            this.ClientSize = new System.Drawing.Size(780, 460);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.dtInicio);
            this.Controls.Add(this.lblFim);
            this.Controls.Add(this.dtFim);
            this.Controls.Add(this.btnFiltrar);

            this.Controls.Add(this.dgvMov);

            this.Controls.Add(this.btnEntrada);
            this.Controls.Add(this.btnSaida);
            this.Controls.Add(this.btnTransferencia);
            this.Controls.Add(this.btnFechar);

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimentações Financeiras";

            ((System.ComponentModel.ISupportInitialize)(this.dgvMov)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblFim;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.DateTimePicker dtFim;
        private System.Windows.Forms.Button btnFiltrar;

        private System.Windows.Forms.DataGridView dgvMov;

        private System.Windows.Forms.Button btnEntrada;
        private System.Windows.Forms.Button btnSaida;
        private System.Windows.Forms.Button btnTransferencia;
        private System.Windows.Forms.Button btnFechar;
    }
}