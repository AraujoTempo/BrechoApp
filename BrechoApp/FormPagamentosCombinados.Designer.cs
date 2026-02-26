namespace BrechoApp
{
    partial class FormPagamentosCombinados
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.ComboBox cmbTipoPagamento;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.DataGridView dgvPagamentos;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;

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
            this.label1 = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.cmbTipoPagamento = new System.Windows.Forms.ComboBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.dgvPagamentos = new System.Windows.Forms.DataGridView();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagamentos)).BeginInit();
            this.SuspendLayout();

            // label1 - "Valor Total:"
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.Text = "Valor Total:";

            // lblValorTotal
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblValorTotal.Location = new System.Drawing.Point(100, 18);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(50, 19);
            this.lblValorTotal.Text = "R$ 0,00";

            // cmbTipoPagamento
            this.cmbTipoPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPagamento.Location = new System.Drawing.Point(20, 60);
            this.cmbTipoPagamento.Name = "cmbTipoPagamento";
            this.cmbTipoPagamento.Size = new System.Drawing.Size(180, 23);

            // txtValor
            this.txtValor.Location = new System.Drawing.Point(210, 60);
            this.txtValor.Name = "txtValor";
            this.txtValor.PlaceholderText = "Valor";
            this.txtValor.Size = new System.Drawing.Size(100, 23);

            // btnAdicionar
            this.btnAdicionar.Location = new System.Drawing.Point(320, 60);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(90, 23);
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);

            // dgvPagamentos
            this.dgvPagamentos.AllowUserToAddRows = false;
            this.dgvPagamentos.AllowUserToDeleteRows = false;
            this.dgvPagamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagamentos.Location = new System.Drawing.Point(20, 100);
            this.dgvPagamentos.Name = "dgvPagamentos";
            this.dgvPagamentos.RowHeadersVisible = false;
            this.dgvPagamentos.Size = new System.Drawing.Size(390, 200);

            // btnConfirmar
            this.btnConfirmar.Location = new System.Drawing.Point(230, 320);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(90, 30);
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);

            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(120, 320);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // FormPagamentosCombinados
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(430, 370);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.cmbTipoPagamento);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.dgvPagamentos);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormPagamentosCombinados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pagamentos Combinados";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagamentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}