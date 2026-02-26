namespace BrechoApp
{
    partial class FormCentroFinanceiroCadastro
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
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();

            this.lblTipo = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();

            this.lblSaldoInicial = new System.Windows.Forms.Label();
            this.txtSaldoInicial = new System.Windows.Forms.TextBox();

            this.chkAtivo = new System.Windows.Forms.CheckBox();

            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // lblNome
            this.lblNome.Text = "Nome:";
            this.lblNome.Location = new System.Drawing.Point(20, 20);
            this.lblNome.AutoSize = true;

            // txtNome
            this.txtNome.Location = new System.Drawing.Point(20, 40);
            this.txtNome.Size = new System.Drawing.Size(420, 23); // AUMENTADO

            // lblTipo
            this.lblTipo.Text = "Tipo:";
            this.lblTipo.Location = new System.Drawing.Point(20, 80);
            this.lblTipo.AutoSize = true;

            // cboTipo
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.Items.AddRange(new object[] {
                "Caixa",
                "ContaCorrente",
                "CartaoAReceber",
                "CartaoCredito",
                "CartaoDebito",
                "ContasAReceber",
                "ComissoesAPagar",
                "Outros"
            });
            this.cboTipo.Location = new System.Drawing.Point(20, 100);
            this.cboTipo.Size = new System.Drawing.Size(420, 23); // AUMENTADO

            // lblSaldoInicial
            this.lblSaldoInicial.Text = "Saldo Inicial:";
            this.lblSaldoInicial.Location = new System.Drawing.Point(20, 140);
            this.lblSaldoInicial.AutoSize = true;

            // txtSaldoInicial
            this.txtSaldoInicial.Location = new System.Drawing.Point(20, 160);
            this.txtSaldoInicial.Size = new System.Drawing.Size(200, 23);

            // chkAtivo
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.Location = new System.Drawing.Point(20, 200);
            this.chkAtivo.AutoSize = true;

            // btnSalvar
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Location = new System.Drawing.Point(20, 240);
            this.btnSalvar.Size = new System.Drawing.Size(150, 35);
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            // btnCancelar
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(190, 240);
            this.btnCancelar.Size = new System.Drawing.Size(150, 35);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // FormCentroFinanceiroCadastro
            this.ClientSize = new System.Drawing.Size(470, 300); // JANELA MAIOR
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.lblSaldoInicial);
            this.Controls.Add(this.txtSaldoInicial);
            this.Controls.Add(this.chkAtivo);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Centro Financeiro";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;

        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cboTipo;

        private System.Windows.Forms.Label lblSaldoInicial;
        private System.Windows.Forms.TextBox txtSaldoInicial;

        private System.Windows.Forms.CheckBox chkAtivo;

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
