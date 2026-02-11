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
        /// Required method for Designer support — do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnListarProdutosDisponiveis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnListarProdutosDisponiveis
            // 
            this.btnListarProdutosDisponiveis.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnListarProdutosDisponiveis.Location = new System.Drawing.Point(40, 40);
            this.btnListarProdutosDisponiveis.Name = "btnListarProdutosDisponiveis";
            this.btnListarProdutosDisponiveis.Size = new System.Drawing.Size(300, 60);
            this.btnListarProdutosDisponiveis.TabIndex = 0;
            this.btnListarProdutosDisponiveis.Text = "Listar Produtos Disponíveis";
            this.btnListarProdutosDisponiveis.UseVisualStyleBackColor = true;
            this.btnListarProdutosDisponiveis.Click += new System.EventHandler(this.btnListarProdutosDisponiveis_Click);
            // 
            // FormOperacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 150);
            this.Controls.Add(this.btnListarProdutosDisponiveis);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOperacoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Operações";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnListarProdutosDisponiveis;
    }
}
