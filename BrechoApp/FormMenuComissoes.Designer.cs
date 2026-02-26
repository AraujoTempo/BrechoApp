namespace BrechoApp
{
    partial class FormMenuComissoes
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnGestaoComissoes = new System.Windows.Forms.Button();
            this.btnExtratoComissoes = new System.Windows.Forms.Button();
            this.btnAjustarDataVendas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(260, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Módulo de Comissões";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGestaoComissoes
            // 
            this.btnGestaoComissoes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnGestaoComissoes.Location = new System.Drawing.Point(20, 70);
            this.btnGestaoComissoes.Name = "btnGestaoComissoes";
            this.btnGestaoComissoes.Size = new System.Drawing.Size(260, 45);
            this.btnGestaoComissoes.TabIndex = 1;
            this.btnGestaoComissoes.Text = "Gestão de Comissões";
            this.btnGestaoComissoes.UseVisualStyleBackColor = true;
            this.btnGestaoComissoes.Click += new System.EventHandler(this.btnGestaoComissoes_Click);
            // 
            // btnExtratoComissoes
            // 
            this.btnExtratoComissoes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnExtratoComissoes.Location = new System.Drawing.Point(20, 125);
            this.btnExtratoComissoes.Name = "btnExtratoComissoes";
            this.btnExtratoComissoes.Size = new System.Drawing.Size(260, 45);
            this.btnExtratoComissoes.TabIndex = 2;
            this.btnExtratoComissoes.Text = "Extrato de Comissões";
            this.btnExtratoComissoes.UseVisualStyleBackColor = true;
            this.btnExtratoComissoes.Click += new System.EventHandler(this.btnExtratoComissoes_Click);
            // 
            // btnAjustarDataVendas
            // 
            this.btnAjustarDataVendas.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAjustarDataVendas.Location = new System.Drawing.Point(20, 180);
            this.btnAjustarDataVendas.Name = "btnAjustarDataVendas";
            this.btnAjustarDataVendas.Size = new System.Drawing.Size(260, 45);
            this.btnAjustarDataVendas.TabIndex = 3;
            this.btnAjustarDataVendas.Text = "Ajustar Data de Vendas";
            this.btnAjustarDataVendas.UseVisualStyleBackColor = true;
            this.btnAjustarDataVendas.Click += new System.EventHandler(this.btnAjustarDataVendas_Click);
            // 
            // FormMenuComissoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 250);
            this.Controls.Add(this.btnAjustarDataVendas);
            this.Controls.Add(this.btnExtratoComissoes);
            this.Controls.Add(this.btnGestaoComissoes);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMenuComissoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comissões";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnGestaoComissoes;
        private System.Windows.Forms.Button btnExtratoComissoes;
        private System.Windows.Forms.Button btnAjustarDataVendas;
    }
}