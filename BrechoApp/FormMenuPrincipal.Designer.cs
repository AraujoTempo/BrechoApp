namespace BrechoApp
{
    partial class FormMenuPrincipal
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
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.lblEmpresa = new System.Windows.Forms.Label();

            this.btnVendas = new System.Windows.Forms.Button();
            this.btnFinanceiro = new System.Windows.Forms.Button();
            this.btnCuradoria = new System.Windows.Forms.Button();
            this.btnComissoes = new System.Windows.Forms.Button();
            this.btnRelatoriosGerenciais = new System.Windows.Forms.Button();
            this.btnOperacoes = new System.Windows.Forms.Button();
            this.btnMarketing = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();

            // 
            // pictureLogo
            // 
            this.pictureLogo.BackColor = System.Drawing.Color.LightGray;
            this.pictureLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureLogo.Location = new System.Drawing.Point(20, 20);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(260, 140);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLogo.TabIndex = 0;
            this.pictureLogo.TabStop = false;

            // 
            // lblEmpresa
            // 
            this.lblEmpresa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEmpresa.Location = new System.Drawing.Point(20, 165);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(260, 23);
            this.lblEmpresa.TabIndex = 1;
            this.lblEmpresa.Text = "Bob Sun Sistemas de Informação";
            this.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ============================================================
            // BOTÃO: VENDAS
            // ============================================================
            this.btnVendas.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnVendas.Location = new System.Drawing.Point(20, 210);
            this.btnVendas.Name = "btnVendas";
            this.btnVendas.Size = new System.Drawing.Size(260, 45);
            this.btnVendas.TabIndex = 2;
            this.btnVendas.Text = "Vendas";
            this.btnVendas.UseVisualStyleBackColor = true;
            this.btnVendas.Click += new System.EventHandler(this.btnVendas_Click);

            // ============================================================
            // BOTÃO: FINANCEIRO
            // ============================================================
            this.btnFinanceiro.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnFinanceiro.Location = new System.Drawing.Point(20, 265);
            this.btnFinanceiro.Name = "btnFinanceiro";
            this.btnFinanceiro.Size = new System.Drawing.Size(260, 45);
            this.btnFinanceiro.TabIndex = 3;
            this.btnFinanceiro.Text = "Financeiro";
            this.btnFinanceiro.UseVisualStyleBackColor = true;
            this.btnFinanceiro.Click += new System.EventHandler(this.btnFinanceiro_Click);

            // ============================================================
            // BOTÃO: CURADORIA
            // ============================================================
            this.btnCuradoria.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCuradoria.Location = new System.Drawing.Point(20, 320);
            this.btnCuradoria.Name = "btnCuradoria";
            this.btnCuradoria.Size = new System.Drawing.Size(260, 45);
            this.btnCuradoria.TabIndex = 4;
            this.btnCuradoria.Text = "Curadoria";
            this.btnCuradoria.UseVisualStyleBackColor = true;
            this.btnCuradoria.Click += new System.EventHandler(this.btnCuradoria_Click);

            // ============================================================
            // BOTÃO: COMISSÕES
            // ============================================================
            this.btnComissoes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnComissoes.Location = new System.Drawing.Point(20, 375);
            this.btnComissoes.Name = "btnComissoes";
            this.btnComissoes.Size = new System.Drawing.Size(260, 45);
            this.btnComissoes.TabIndex = 5;
            this.btnComissoes.Text = "Comissões";
            this.btnComissoes.UseVisualStyleBackColor = true;
            this.btnComissoes.Click += new System.EventHandler(this.btnComissoes_Click);

            // ============================================================
            // BOTÃO: RELATÓRIOS GERENCIAIS
            // ============================================================
            this.btnRelatoriosGerenciais.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnRelatoriosGerenciais.Location = new System.Drawing.Point(20, 430);
            this.btnRelatoriosGerenciais.Name = "btnRelatoriosGerenciais";
            this.btnRelatoriosGerenciais.Size = new System.Drawing.Size(260, 45);
            this.btnRelatoriosGerenciais.TabIndex = 6;
            this.btnRelatoriosGerenciais.Text = "Relatórios Gerenciais";
            this.btnRelatoriosGerenciais.UseVisualStyleBackColor = true;
            this.btnRelatoriosGerenciais.Click += new System.EventHandler(this.btnRelatoriosGerenciais_Click);

            // ============================================================
            // BOTÃO: OPERAÇÕES
            // ============================================================
            this.btnOperacoes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnOperacoes.Location = new System.Drawing.Point(20, 485);
            this.btnOperacoes.Name = "btnOperacoes";
            this.btnOperacoes.Size = new System.Drawing.Size(260, 45);
            this.btnOperacoes.TabIndex = 7;
            this.btnOperacoes.Text = "Operações";
            this.btnOperacoes.UseVisualStyleBackColor = true;
            this.btnOperacoes.Click += new System.EventHandler(this.btnOperacoes_Click);

            // ============================================================
            // BOTÃO: MARKETING
            // ============================================================
            this.btnMarketing.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnMarketing.Location = new System.Drawing.Point(20, 540);
            this.btnMarketing.Name = "btnMarketing";
            this.btnMarketing.Size = new System.Drawing.Size(260, 45);
            this.btnMarketing.TabIndex = 8;
            this.btnMarketing.Text = "Marketing";
            this.btnMarketing.UseVisualStyleBackColor = true;
            this.btnMarketing.Click += new System.EventHandler(this.btnMarketing_Click);

            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 610);
            this.Controls.Add(this.btnMarketing);
            this.Controls.Add(this.btnOperacoes);
            this.Controls.Add(this.btnRelatoriosGerenciais);
            this.Controls.Add(this.btnComissoes);
            this.Controls.Add(this.btnCuradoria);
            this.Controls.Add(this.btnFinanceiro);
            this.Controls.Add(this.btnVendas);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.pictureLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";

            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.Label lblEmpresa;

        private System.Windows.Forms.Button btnVendas;
        private System.Windows.Forms.Button btnFinanceiro;
        private System.Windows.Forms.Button btnCuradoria;
        private System.Windows.Forms.Button btnComissoes;
        private System.Windows.Forms.Button btnRelatoriosGerenciais;
        private System.Windows.Forms.Button btnOperacoes;
        private System.Windows.Forms.Button btnMarketing;
    }
}
