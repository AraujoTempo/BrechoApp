namespace BrechoApp
{
    partial class FormOperacoes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnListarProdutosDisponiveis = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            
            // ============================================================
            // TÍTULO
            // ============================================================
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(120, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(160, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "OPERAÇÕES";
            
            // ============================================================
            // BOTÃO: LISTAR PRODUTOS DISPONÍVEIS
            // ============================================================
            this.btnListarProdutosDisponiveis.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnListarProdutosDisponiveis.FlatAppearance.BorderSize = 0;
            this.btnListarProdutosDisponiveis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListarProdutosDisponiveis.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnListarProdutosDisponiveis.ForeColor = System.Drawing.Color.White;
            this.btnListarProdutosDisponiveis.Location = new System.Drawing.Point(40, 80);
            this.btnListarProdutosDisponiveis.Name = "btnListarProdutosDisponiveis";
            this.btnListarProdutosDisponiveis.Size = new System.Drawing.Size(320, 60);
            this.btnListarProdutosDisponiveis.TabIndex = 1;
            this.btnListarProdutosDisponiveis.Text = "Listar Produtos Disponíveis\r\n(Exportar para Excel)";
            this.btnListarProdutosDisponiveis.UseVisualStyleBackColor = false;
            this.btnListarProdutosDisponiveis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnListarProdutosDisponiveis.Click += new System.EventHandler(this.btnListarProdutosDisponiveis_Click);
            
            // Efeito hover
            this.btnListarProdutosDisponiveis.MouseEnter += (s, e) => {
                this.btnListarProdutosDisponiveis.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            };
            this.btnListarProdutosDisponiveis.MouseLeave += (s, e) => {
                this.btnListarProdutosDisponiveis.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            };
            
            // ============================================================
            // FORM
            // ============================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 180);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnListarProdutosDisponiveis);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOperacoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Operações - BrechoApp";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnListarProdutosDisponiveis;
        private System.Windows.Forms.Label lblTitulo;
    }
}
