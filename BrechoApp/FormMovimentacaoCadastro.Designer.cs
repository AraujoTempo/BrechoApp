namespace BrechoApp
{
    partial class FormMovimentacaoCadastro
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
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.dtData = new System.Windows.Forms.DateTimePicker();

            this.lblValor = new System.Windows.Forms.Label();
            this.numValor = new System.Windows.Forms.NumericUpDown();

            this.lblOrigem = new System.Windows.Forms.Label();
            this.cmbOrigem = new System.Windows.Forms.ComboBox();

            this.lblDestino = new System.Windows.Forms.Label();
            this.cmbDestino = new System.Windows.Forms.ComboBox();

            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtCategoria = new System.Windows.Forms.TextBox();

            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();

            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numValor)).BeginInit();
            this.SuspendLayout();

            // ============================================================
            // LABEL TIPO
            // ============================================================
            this.lblTipo.Text = "Tipo:";
            this.lblTipo.Location = new System.Drawing.Point(10, 10);
            this.lblTipo.Size = new System.Drawing.Size(300, 20);

            // ============================================================
            // DATA
            // ============================================================
            this.lblData.Text = "Data:";
            this.lblData.Location = new System.Drawing.Point(10, 45);

            this.dtData.Location = new System.Drawing.Point(120, 42);
            this.dtData.Size = new System.Drawing.Size(200, 23);

            // ============================================================
            // VALOR
            // ============================================================
            this.lblValor.Text = "Valor:";
            this.lblValor.Location = new System.Drawing.Point(10, 80);

            this.numValor.Location = new System.Drawing.Point(120, 77);
            this.numValor.DecimalPlaces = 2;
            this.numValor.Maximum = 9999999;
            this.numValor.Size = new System.Drawing.Size(120, 23);

            // ============================================================
            // ORIGEM
            // ============================================================
            this.lblOrigem.Text = "Centro Origem:";
            this.lblOrigem.Location = new System.Drawing.Point(10, 115);

            this.cmbOrigem.Location = new System.Drawing.Point(120, 112);
            this.cmbOrigem.Size = new System.Drawing.Size(250, 23);
            this.cmbOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // ============================================================
            // DESTINO
            // ============================================================
            this.lblDestino.Text = "Centro Destino:";
            this.lblDestino.Location = new System.Drawing.Point(10, 150);

            this.cmbDestino.Location = new System.Drawing.Point(120, 147);
            this.cmbDestino.Size = new System.Drawing.Size(250, 23);
            this.cmbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // ============================================================
            // CATEGORIA
            // ============================================================
            this.lblCategoria.Text = "Categoria:";
            this.lblCategoria.Location = new System.Drawing.Point(10, 185);

            this.txtCategoria.Location = new System.Drawing.Point(120, 182);
            this.txtCategoria.Size = new System.Drawing.Size(250, 23);

            // ============================================================
            // DESCRIÇÃO
            // ============================================================
            this.lblDescricao.Text = "Descrição:";
            this.lblDescricao.Location = new System.Drawing.Point(10, 220);

            this.txtDescricao.Location = new System.Drawing.Point(120, 217);
            this.txtDescricao.Size = new System.Drawing.Size(250, 23);

            // ============================================================
            // BOTÕES
            // ============================================================
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Location = new System.Drawing.Point(120, 260);
            this.btnSalvar.Size = new System.Drawing.Size(100, 30);
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(230, 260);
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // ============================================================
            // FORM
            // ============================================================
            this.ClientSize = new System.Drawing.Size(400, 310);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.dtData);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.numValor);
            this.Controls.Add(this.lblOrigem);
            this.Controls.Add(this.cmbOrigem);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.cmbDestino);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Movimentação Financeira";

            ((System.ComponentModel.ISupportInitialize)(this.numValor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.DateTimePicker dtData;

        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.NumericUpDown numValor;

        private System.Windows.Forms.Label lblOrigem;
        private System.Windows.Forms.ComboBox cmbOrigem;

        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.ComboBox cmbDestino;

        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtCategoria;

        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
    }
}