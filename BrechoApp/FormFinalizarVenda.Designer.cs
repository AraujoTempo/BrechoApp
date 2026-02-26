namespace BrechoApp
{
    partial class FormFinalizarVenda
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblValorTotalTitulo;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblFormaPagamento;
        private System.Windows.Forms.ComboBox cmbFormaPagamento;
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblValorTotalTitulo = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.cmbFormaPagamento = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(350, 30);
            this.lblTitulo.Text = "Finalizar Venda";
            // 
            // lblValorTotalTitulo
            // 
            this.lblValorTotalTitulo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblValorTotalTitulo.Location = new System.Drawing.Point(20, 60);
            this.lblValorTotalTitulo.Name = "lblValorTotalTitulo";
            this.lblValorTotalTitulo.Size = new System.Drawing.Size(120, 25);
            this.lblValorTotalTitulo.Text = "Valor Total:";
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblValorTotal.Location = new System.Drawing.Point(150, 60);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(200, 25);
            this.lblValorTotal.Text = "R$ 0,00";
            // 
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFormaPagamento.Location = new System.Drawing.Point(20, 110);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(200, 25);
            this.lblFormaPagamento.Text = "Forma de Pagamento:";
            // 
            // cmbFormaPagamento
            // 
            this.cmbFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormaPagamento.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbFormaPagamento.Location = new System.Drawing.Point(20, 140);
            this.cmbFormaPagamento.Name = "cmbFormaPagamento";
            this.cmbFormaPagamento.Size = new System.Drawing.Size(330, 30);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.Location = new System.Drawing.Point(20, 200);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(150, 40);
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCancelar.Location = new System.Drawing.Point(200, 200);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 40);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormFinalizarVenda
            // 
            this.ClientSize = new System.Drawing.Size(380, 270);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblValorTotalTitulo);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.lblFormaPagamento);
            this.Controls.Add(this.cmbFormaPagamento);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormFinalizarVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Finalizar Venda";
            this.ResumeLayout(false);
        }
    }
}