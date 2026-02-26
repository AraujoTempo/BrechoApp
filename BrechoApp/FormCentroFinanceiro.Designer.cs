namespace BrechoApp
{
    partial class FormCentroFinanceiro
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
            this.dgvCentros = new System.Windows.Forms.DataGridView();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();

            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAtivo = new System.Windows.Forms.DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCentros)).BeginInit();
            this.SuspendLayout();

            // ============================================================
            // GRID
            // ============================================================
            this.dgvCentros.AllowUserToAddRows = false;
            this.dgvCentros.AllowUserToDeleteRows = false;
            this.dgvCentros.ReadOnly = true;
            this.dgvCentros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCentros.MultiSelect = false;
            this.dgvCentros.RowHeadersVisible = false;
            this.dgvCentros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvCentros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId,
                this.colNome,
                this.colTipo,
                this.colSaldo,
                this.colAtivo
            });

            this.dgvCentros.Location = new System.Drawing.Point(10, 10);
            this.dgvCentros.Size = new System.Drawing.Size(560, 300);

            // ============================================================
            // BOTÕES
            // ============================================================
            this.btnNovo.Text = "Novo";
            this.btnNovo.Location = new System.Drawing.Point(10, 320);
            this.btnNovo.Size = new System.Drawing.Size(100, 35);
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);

            this.btnEditar.Text = "Editar";
            this.btnEditar.Location = new System.Drawing.Point(120, 320);
            this.btnEditar.Size = new System.Drawing.Size(100, 35);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Location = new System.Drawing.Point(230, 320);
            this.btnExcluir.Size = new System.Drawing.Size(100, 35);
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);

            this.btnFechar.Text = "Fechar";
            this.btnFechar.Location = new System.Drawing.Point(470, 320);
            this.btnFechar.Size = new System.Drawing.Size(100, 35);
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);

            // ============================================================
            // FORM
            // ============================================================
            this.ClientSize = new System.Drawing.Size(580, 370);
            this.Controls.Add(this.dgvCentros);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnFechar);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Centros Financeiros";

            ((System.ComponentModel.ISupportInitialize)(this.dgvCentros)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCentros;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnFechar;

        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAtivo;
    }
}