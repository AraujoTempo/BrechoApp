namespace BrechoApp
{
    partial class FormAjustarDataVendas
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblMesOrigem;
        private System.Windows.Forms.Label lblAnoOrigem;
        private System.Windows.Forms.ComboBox cmbMesOrigem;
        private System.Windows.Forms.ComboBox cmbAnoOrigem;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView gridVendas;
        private System.Windows.Forms.Label lblNovaData;
        private System.Windows.Forms.DateTimePicker dtpNovaData;
        private System.Windows.Forms.Button btnSalvarAjuste;

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
            this.lblMesOrigem = new System.Windows.Forms.Label();
            this.lblAnoOrigem = new System.Windows.Forms.Label();
            this.cmbMesOrigem = new System.Windows.Forms.ComboBox();
            this.cmbAnoOrigem = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gridVendas = new System.Windows.Forms.DataGridView();
            this.lblNovaData = new System.Windows.Forms.Label();
            this.dtpNovaData = new System.Windows.Forms.DateTimePicker();
            this.btnSalvarAjuste = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridVendas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMesOrigem
            // 
            this.lblMesOrigem.Text = "Mês Origem:";
            this.lblMesOrigem.Location = new System.Drawing.Point(20, 20);
            this.lblMesOrigem.Size = new System.Drawing.Size(140, 25);
            // 
            // lblAnoOrigem
            // 
            this.lblAnoOrigem.Text = "Ano Origem:";
            this.lblAnoOrigem.Location = new System.Drawing.Point(180, 20);
            this.lblAnoOrigem.Size = new System.Drawing.Size(140, 25);
            // 
            // cmbMesOrigem
            // 
            this.cmbMesOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMesOrigem.Location = new System.Drawing.Point(20, 45);
            this.cmbMesOrigem.Size = new System.Drawing.Size(140, 28);
            // 
            // cmbAnoOrigem
            // 
            this.cmbAnoOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnoOrigem.Location = new System.Drawing.Point(180, 45);
            this.cmbAnoOrigem.Size = new System.Drawing.Size(140, 28);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Location = new System.Drawing.Point(340, 45);
            this.btnBuscar.Size = new System.Drawing.Size(120, 30);
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gridVendas
            // 
            this.gridVendas.Location = new System.Drawing.Point(20, 90);
            this.gridVendas.Size = new System.Drawing.Size(760, 320);
            this.gridVendas.ReadOnly = true;
            this.gridVendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridVendas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridVendas.SelectionChanged += new System.EventHandler(this.gridVendas_SelectionChanged);
            this.gridVendas.DoubleClick += new System.EventHandler(this.gridVendas_DoubleClick);
            // 
            // lblNovaData
            // 
            this.lblNovaData.Text = "Nova Data:";
            this.lblNovaData.Location = new System.Drawing.Point(20, 430);
            this.lblNovaData.Size = new System.Drawing.Size(140, 25);
            // 
            // dtpNovaData
            // 
            this.dtpNovaData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNovaData.Location = new System.Drawing.Point(160, 430);
            this.dtpNovaData.Size = new System.Drawing.Size(230, 28);
            // 
            // btnSalvarAjuste
            // 
            this.btnSalvarAjuste.Text = "Salvar Ajuste";
            this.btnSalvarAjuste.Location = new System.Drawing.Point(390, 428);
            this.btnSalvarAjuste.Size = new System.Drawing.Size(160, 32);
            this.btnSalvarAjuste.Click += new System.EventHandler(this.btnSalvarAjuste_Click);
            // 
            // FormAjustarDataVendas
            // 
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.lblMesOrigem);
            this.Controls.Add(this.lblAnoOrigem);
            this.Controls.Add(this.cmbMesOrigem);
            this.Controls.Add(this.cmbAnoOrigem);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.gridVendas);
            this.Controls.Add(this.lblNovaData);
            this.Controls.Add(this.dtpNovaData);
            this.Controls.Add(this.btnSalvarAjuste);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajustar Data de Vendas";
            ((System.ComponentModel.ISupportInitialize)(this.gridVendas)).EndInit();
            this.ResumeLayout(false);
        }
    }
}