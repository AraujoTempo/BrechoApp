namespace BrechoApp
{
    partial class FormGestaoComissoes
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelMes;
        private System.Windows.Forms.Label labelAno;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.ComboBox cmbAno;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnFecharPeriodo;
        private System.Windows.Forms.Button btnDetalhes;
        private System.Windows.Forms.DataGridView gridSaldos;

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
            this.labelMes = new System.Windows.Forms.Label();
            this.labelAno = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.cmbAno = new System.Windows.Forms.ComboBox();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnFecharPeriodo = new System.Windows.Forms.Button();
            this.btnDetalhes = new System.Windows.Forms.Button();
            this.gridSaldos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridSaldos)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMes
            // 
            this.labelMes.AutoSize = true;
            this.labelMes.Location = new System.Drawing.Point(20, 20);
            this.labelMes.Name = "labelMes";
            this.labelMes.Size = new System.Drawing.Size(34, 15);
            this.labelMes.TabIndex = 0;
            this.labelMes.Text = "Mês:";
            // 
            // labelAno
            // 
            this.labelAno.AutoSize = true;
            this.labelAno.Location = new System.Drawing.Point(150, 20);
            this.labelAno.Name = "labelAno";
            this.labelAno.Size = new System.Drawing.Size(34, 15);
            this.labelAno.TabIndex = 1;
            this.labelAno.Text = "Ano:";
            // 
            // cmbMes
            // 
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.Location = new System.Drawing.Point(20, 40);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(80, 23);
            this.cmbMes.TabIndex = 2;
            // 
            // cmbAno
            // 
            this.cmbAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAno.Location = new System.Drawing.Point(150, 40);
            this.cmbAno.Name = "cmbAno";
            this.cmbAno.Size = new System.Drawing.Size(80, 23);
            this.cmbAno.TabIndex = 3;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(260, 40);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(100, 25);
            this.btnAtualizar.TabIndex = 4;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnFecharPeriodo
            // 
            this.btnFecharPeriodo.Location = new System.Drawing.Point(370, 40);
            this.btnFecharPeriodo.Name = "btnFecharPeriodo";
            this.btnFecharPeriodo.Size = new System.Drawing.Size(140, 25);
            this.btnFecharPeriodo.TabIndex = 5;
            this.btnFecharPeriodo.Text = "Fechar Período";
            this.btnFecharPeriodo.Click += new System.EventHandler(this.btnFecharPeriodo_Click);
            // 
            // btnDetalhes
            // 
            this.btnDetalhes.Location = new System.Drawing.Point(520, 40);
            this.btnDetalhes.Name = "btnDetalhes";
            this.btnDetalhes.Size = new System.Drawing.Size(120, 25);
            this.btnDetalhes.TabIndex = 6;
            this.btnDetalhes.Text = "Ver Detalhes";
            this.btnDetalhes.Click += new System.EventHandler(this.btnDetalhes_Click);
            // 
            // gridSaldos
            // 
            this.gridSaldos.AllowUserToAddRows = false;
            this.gridSaldos.AllowUserToDeleteRows = false;
            this.gridSaldos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSaldos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSaldos.Location = new System.Drawing.Point(20, 90);
            this.gridSaldos.Name = "gridSaldos";
            this.gridSaldos.ReadOnly = true;
            this.gridSaldos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSaldos.Size = new System.Drawing.Size(760, 330);
            this.gridSaldos.TabIndex = 7;
            // 
            // FormGestaoComissoes
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridSaldos);
            this.Controls.Add(this.btnDetalhes);
            this.Controls.Add(this.btnFecharPeriodo);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.cmbAno);
            this.Controls.Add(this.cmbMes);
            this.Controls.Add(this.labelAno);
            this.Controls.Add(this.labelMes);
            this.Name = "FormGestaoComissoes";
            this.Text = "Gestão de Comissões";
            ((System.ComponentModel.ISupportInitialize)(this.gridSaldos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}