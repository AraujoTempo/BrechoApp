namespace BrechoApp
{
    partial class FormMenuFinanceiro
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
            this.btnCentrosFinanceiros = new System.Windows.Forms.Button();
            this.btnMovimentacoes = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // btnCentrosFinanceiros
            // 
            this.btnCentrosFinanceiros.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCentrosFinanceiros.Location = new System.Drawing.Point(20, 20);
            this.btnCentrosFinanceiros.Name = "btnCentrosFinanceiros";
            this.btnCentrosFinanceiros.Size = new System.Drawing.Size(260, 45);
            this.btnCentrosFinanceiros.TabIndex = 0;
            this.btnCentrosFinanceiros.Text = "Centros Financeiros";
            this.btnCentrosFinanceiros.UseVisualStyleBackColor = true;
            this.btnCentrosFinanceiros.Click += new System.EventHandler(this.btnCentrosFinanceiros_Click);

            // 
            // btnMovimentacoes
            // 
            this.btnMovimentacoes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnMovimentacoes.Location = new System.Drawing.Point(20, 75);
            this.btnMovimentacoes.Name = "btnMovimentacoes";
            this.btnMovimentacoes.Size = new System.Drawing.Size(260, 45);
            this.btnMovimentacoes.TabIndex = 1;
            this.btnMovimentacoes.Text = "Movimentações Financeiras";
            this.btnMovimentacoes.UseVisualStyleBackColor = true;
            this.btnMovimentacoes.Click += new System.EventHandler(this.btnMovimentacoes_Click);

            // 
            // btnFechar
            // 
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnFechar.Location = new System.Drawing.Point(20, 130);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(260, 45);
            this.btnFechar.TabIndex = 2;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);

            // 
            // FormMenuFinanceiro
            // 
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.btnCentrosFinanceiros);
            this.Controls.Add(this.btnMovimentacoes);
            this.Controls.Add(this.btnFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Menu Financeiro";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnCentrosFinanceiros;
        private System.Windows.Forms.Button btnMovimentacoes;
        private System.Windows.Forms.Button btnFechar;
    }
}