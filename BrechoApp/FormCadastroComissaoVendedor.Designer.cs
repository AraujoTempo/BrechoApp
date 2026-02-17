namespace BrechoApp
{
    partial class FormCadastroComissaoVendedor
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

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.cmbVendedor = new System.Windows.Forms.ComboBox();
            this.lblPercentual = new System.Windows.Forms.Label();
            this.txtPercentual = new System.Windows.Forms.TextBox();
            this.lblPercentualSimbolo = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.dgvComissoes = new System.Windows.Forms.DataGridView();
            this.btnVoltar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComissoes)).BeginInit();
            this.SuspendLayout();
            
            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(150, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(450, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "CADASTRO DE COMISSÃO DE VENDEDORES";
            
            // lblVendedor
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblVendedor.Location = new System.Drawing.Point(30, 70);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(130, 19);
            this.lblVendedor.TabIndex = 1;
            this.lblVendedor.Text = "Selecione o Vendedor:";
            
            // cmbVendedor
            this.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVendedor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbVendedor.FormattingEnabled = true;
            this.cmbVendedor.Location = new System.Drawing.Point(30, 95);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.Size = new System.Drawing.Size(400, 25);
            this.cmbVendedor.TabIndex = 2;
            
            // lblPercentual
            this.lblPercentual.AutoSize = true;
            this.lblPercentual.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPercentual.Location = new System.Drawing.Point(450, 70);
            this.lblPercentual.Name = "lblPercentual";
            this.lblPercentual.Size = new System.Drawing.Size(150, 19);
            this.lblPercentual.TabIndex = 3;
            this.lblPercentual.Text = "Percentual de Comissão:";
            
            // txtPercentual
            this.txtPercentual.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPercentual.Location = new System.Drawing.Point(450, 95);
            this.txtPercentual.MaxLength = 6;
            this.txtPercentual.Name = "txtPercentual";
            this.txtPercentual.Size = new System.Drawing.Size(100, 25);
            this.txtPercentual.TabIndex = 4;
            this.txtPercentual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            
            // lblPercentualSimbolo
            this.lblPercentualSimbolo.AutoSize = true;
            this.lblPercentualSimbolo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPercentualSimbolo.Location = new System.Drawing.Point(555, 98);
            this.lblPercentualSimbolo.Name = "lblPercentualSimbolo";
            this.lblPercentualSimbolo.Size = new System.Drawing.Size(20, 19);
            this.lblPercentualSimbolo.TabIndex = 5;
            this.lblPercentualSimbolo.Text = "%";
            
            // btnSalvar
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(590, 85);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 35);
            this.btnSalvar.TabIndex = 6;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            
            // btnNovo
            this.btnNovo.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnNovo.FlatAppearance.BorderSize = 0;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNovo.ForeColor = System.Drawing.Color.White;
            this.btnNovo.Location = new System.Drawing.Point(700, 85);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(100, 35);
            this.btnNovo.TabIndex = 7;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            
            // btnExcluir
            this.btnExcluir.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnExcluir.FlatAppearance.BorderSize = 0;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExcluir.ForeColor = System.Drawing.Color.White;
            this.btnExcluir.Location = new System.Drawing.Point(30, 460);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(100, 35);
            this.btnExcluir.TabIndex = 8;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            
            // dgvComissoes
            this.dgvComissoes.AllowUserToAddRows = false;
            this.dgvComissoes.AllowUserToDeleteRows = false;
            this.dgvComissoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComissoes.BackgroundColor = System.Drawing.Color.White;
            this.dgvComissoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComissoes.Location = new System.Drawing.Point(30, 140);
            this.dgvComissoes.MultiSelect = false;
            this.dgvComissoes.Name = "dgvComissoes";
            this.dgvComissoes.ReadOnly = true;
            this.dgvComissoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComissoes.Size = new System.Drawing.Size(770, 300);
            this.dgvComissoes.TabIndex = 9;
            this.dgvComissoes.SelectionChanged += new System.EventHandler(this.dgvComissoes_SelectionChanged);
            
            // btnVoltar
            this.btnVoltar.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVoltar.ForeColor = System.Drawing.Color.White;
            this.btnVoltar.Location = new System.Drawing.Point(700, 460);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(100, 35);
            this.btnVoltar.TabIndex = 10;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            
            // FormCadastroComissaoVendedor
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.ClientSize = new System.Drawing.Size(830, 520);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.dgvComissoes);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.lblPercentualSimbolo);
            this.Controls.Add(this.txtPercentual);
            this.Controls.Add(this.lblPercentual);
            this.Controls.Add(this.cmbVendedor);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCadastroComissaoVendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Comissão de Vendedores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvComissoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.ComboBox cmbVendedor;
        private System.Windows.Forms.Label lblPercentual;
        private System.Windows.Forms.TextBox txtPercentual;
        private System.Windows.Forms.Label lblPercentualSimbolo;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.DataGridView dgvComissoes;
        private System.Windows.Forms.Button btnVoltar;
    }
}
