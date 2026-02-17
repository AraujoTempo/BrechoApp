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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAjustesEstoque = new System.Windows.Forms.Button();
            this.btnAjustesVendas = new System.Windows.Forms.Button();
            this.btnAuditorias = new System.Windows.Forms.Button();
            this.btnDoacoes = new System.Windows.Forms.Button();
            this.btnDevolucoes = new System.Windows.Forms.Button();
            this.btnCadastroCategorias = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
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
            // BOTÃO: AJUSTES DE ESTOQUE
            // ============================================================
            this.btnAjustesEstoque.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnAjustesEstoque.Enabled = false;
            this.btnAjustesEstoque.FlatAppearance.BorderSize = 0;
            this.btnAjustesEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjustesEstoque.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAjustesEstoque.ForeColor = System.Drawing.Color.White;
            this.btnAjustesEstoque.Location = new System.Drawing.Point(40, 80);
            this.btnAjustesEstoque.Name = "btnAjustesEstoque";
            this.btnAjustesEstoque.Size = new System.Drawing.Size(320, 60);
            this.btnAjustesEstoque.TabIndex = 1;
            this.btnAjustesEstoque.Text = "Ajustes de Estoque\r\n(Em Desenvolvimento)";
            this.btnAjustesEstoque.UseVisualStyleBackColor = false;
            this.btnAjustesEstoque.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAjustesEstoque.Click += new System.EventHandler(this.btnAjustesEstoque_Click);
            
            // ============================================================
            // BOTÃO: AJUSTES DE VENDAS
            // ============================================================
            this.btnAjustesVendas.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnAjustesVendas.Enabled = false;
            this.btnAjustesVendas.FlatAppearance.BorderSize = 0;
            this.btnAjustesVendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjustesVendas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAjustesVendas.ForeColor = System.Drawing.Color.White;
            this.btnAjustesVendas.Location = new System.Drawing.Point(40, 150);
            this.btnAjustesVendas.Name = "btnAjustesVendas";
            this.btnAjustesVendas.Size = new System.Drawing.Size(320, 60);
            this.btnAjustesVendas.TabIndex = 2;
            this.btnAjustesVendas.Text = "Ajustes de Vendas\r\n(Alteração de Data) (Em Desenvolvimento)";
            this.btnAjustesVendas.UseVisualStyleBackColor = false;
            this.btnAjustesVendas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAjustesVendas.Click += new System.EventHandler(this.btnAjustesVendas_Click);
            
            // ============================================================
            // BOTÃO: AUDITORIAS
            // ============================================================
            this.btnAuditorias.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnAuditorias.Enabled = false;
            this.btnAuditorias.FlatAppearance.BorderSize = 0;
            this.btnAuditorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuditorias.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAuditorias.ForeColor = System.Drawing.Color.White;
            this.btnAuditorias.Location = new System.Drawing.Point(40, 220);
            this.btnAuditorias.Name = "btnAuditorias";
            this.btnAuditorias.Size = new System.Drawing.Size(320, 60);
            this.btnAuditorias.TabIndex = 3;
            this.btnAuditorias.Text = "Auditorias\r\n(Em Desenvolvimento)";
            this.btnAuditorias.UseVisualStyleBackColor = false;
            this.btnAuditorias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAuditorias.Click += new System.EventHandler(this.btnAuditorias_Click);
            
            // ============================================================
            // BOTÃO: DOAÇÕES
            // ============================================================
            this.btnDoacoes.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnDoacoes.Enabled = false;
            this.btnDoacoes.FlatAppearance.BorderSize = 0;
            this.btnDoacoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoacoes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDoacoes.ForeColor = System.Drawing.Color.White;
            this.btnDoacoes.Location = new System.Drawing.Point(40, 290);
            this.btnDoacoes.Name = "btnDoacoes";
            this.btnDoacoes.Size = new System.Drawing.Size(320, 60);
            this.btnDoacoes.TabIndex = 4;
            this.btnDoacoes.Text = "Doações\r\n(Em Desenvolvimento)";
            this.btnDoacoes.UseVisualStyleBackColor = false;
            this.btnDoacoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoacoes.Click += new System.EventHandler(this.btnDoacoes_Click);
            
            // ============================================================
            // BOTÃO: DEVOLUÇÕES
            // ============================================================
            this.btnDevolucoes.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnDevolucoes.Enabled = false;
            this.btnDevolucoes.FlatAppearance.BorderSize = 0;
            this.btnDevolucoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevolucoes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDevolucoes.ForeColor = System.Drawing.Color.White;
            this.btnDevolucoes.Location = new System.Drawing.Point(40, 360);
            this.btnDevolucoes.Name = "btnDevolucoes";
            this.btnDevolucoes.Size = new System.Drawing.Size(320, 60);
            this.btnDevolucoes.TabIndex = 5;
            this.btnDevolucoes.Text = "Devoluções\r\n(Em Desenvolvimento)";
            this.btnDevolucoes.UseVisualStyleBackColor = false;
            this.btnDevolucoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDevolucoes.Click += new System.EventHandler(this.btnDevolucoes_Click);
            
            // ============================================================
            // BOTÃO: CADASTRO DE CATEGORIAS DE PRODUTOS
            // ============================================================
            this.btnCadastroCategorias.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnCadastroCategorias.FlatAppearance.BorderSize = 0;
            this.btnCadastroCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastroCategorias.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCadastroCategorias.ForeColor = System.Drawing.Color.White;
            this.btnCadastroCategorias.Location = new System.Drawing.Point(40, 430);
            this.btnCadastroCategorias.Name = "btnCadastroCategorias";
            this.btnCadastroCategorias.Size = new System.Drawing.Size(320, 60);
            this.btnCadastroCategorias.TabIndex = 6;
            this.btnCadastroCategorias.Text = "Cadastro de Categorias de Produtos";
            this.btnCadastroCategorias.UseVisualStyleBackColor = false;
            this.btnCadastroCategorias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadastroCategorias.Click += new System.EventHandler(this.btnCadastroCategorias_Click);
            
            // ============================================================
            // BOTÃO: VOLTAR
            // ============================================================
            this.btnVoltar.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnVoltar.ForeColor = System.Drawing.Color.White;
            this.btnVoltar.Location = new System.Drawing.Point(40, 510);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(320, 50);
            this.btnVoltar.TabIndex = 7;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            
            // Efeito hover - btnVoltar
            this.btnVoltar.MouseEnter += (s, e) => {
                this.btnVoltar.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            };
            this.btnVoltar.MouseLeave += (s, e) => {
                this.btnVoltar.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            };
            
            // ============================================================
            // FORM
            // ============================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 590);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnCadastroCategorias);
            this.Controls.Add(this.btnDevolucoes);
            this.Controls.Add(this.btnDoacoes);
            this.Controls.Add(this.btnAuditorias);
            this.Controls.Add(this.btnAjustesVendas);
            this.Controls.Add(this.btnAjustesEstoque);
            this.Controls.Add(this.lblTitulo);
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

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAjustesEstoque;
        private System.Windows.Forms.Button btnAjustesVendas;
        private System.Windows.Forms.Button btnAuditorias;
        private System.Windows.Forms.Button btnDoacoes;
        private System.Windows.Forms.Button btnDevolucoes;
        private System.Windows.Forms.Button btnCadastroCategorias;
        private System.Windows.Forms.Button btnVoltar;
    }
}
