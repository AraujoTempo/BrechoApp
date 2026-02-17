namespace BrechoApp
{
    partial class FormRelatoriosGerenciais
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
            this.btnRelatorioVendasMes = new System.Windows.Forms.Button();
            this.btnRelatorioFinanceiro = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(360, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Relatórios Gerenciais";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRelatorioVendasMes
            // 
            this.btnRelatorioVendasMes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnRelatorioVendasMes.Location = new System.Drawing.Point(20, 70);
            this.btnRelatorioVendasMes.Name = "btnRelatorioVendasMes";
            this.btnRelatorioVendasMes.Size = new System.Drawing.Size(360, 50);
            this.btnRelatorioVendasMes.TabIndex = 1;
            this.btnRelatorioVendasMes.Text = "Relatório de Vendas do Mês";
            this.btnRelatorioVendasMes.UseVisualStyleBackColor = true;
            this.btnRelatorioVendasMes.Click += new System.EventHandler(this.btnRelatorioVendasMes_Click);
            // 
            // btnRelatorioFinanceiro
            // 
            this.btnRelatorioFinanceiro.Enabled = false;
            this.btnRelatorioFinanceiro.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnRelatorioFinanceiro.Location = new System.Drawing.Point(20, 130);
            this.btnRelatorioFinanceiro.Name = "btnRelatorioFinanceiro";
            this.btnRelatorioFinanceiro.Size = new System.Drawing.Size(360, 50);
            this.btnRelatorioFinanceiro.TabIndex = 2;
            this.btnRelatorioFinanceiro.Text = "Relatório Financeiro (Em Desenvolvimento)";
            this.btnRelatorioFinanceiro.UseVisualStyleBackColor = true;
            this.btnRelatorioFinanceiro.Click += new System.EventHandler(this.btnRelatorioFinanceiro_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnVoltar.Location = new System.Drawing.Point(20, 200);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(360, 40);
            this.btnVoltar.TabIndex = 3;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // FormRelatoriosGerenciais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 260);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnRelatorioFinanceiro);
            this.Controls.Add(this.btnRelatorioVendasMes);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRelatoriosGerenciais";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatórios Gerenciais";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnRelatorioVendasMes;
        private System.Windows.Forms.Button btnRelatorioFinanceiro;
        private System.Windows.Forms.Button btnVoltar;
    }
}
