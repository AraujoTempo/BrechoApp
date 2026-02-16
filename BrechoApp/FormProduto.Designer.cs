namespace BrechoApp
{
    partial class FormProduto
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
            this.comboLote = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();

            this.labelNome = new System.Windows.Forms.Label();
            this.labelMarca = new System.Windows.Forms.Label();
            this.labelDescricao = new System.Windows.Forms.Label();
            this.labelCategoria = new System.Windows.Forms.Label();
            this.labelTamanhoCor = new System.Windows.Forms.Label();
            this.labelPrecoSugerido = new System.Windows.Forms.Label();
            this.labelPreco = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelDevolucao = new System.Windows.Forms.Label();

            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.txtTamanhoCor = new System.Windows.Forms.TextBox();
            this.txtPrecoSugerido = new System.Windows.Forms.TextBox();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();

            this.dtpDevolucao = new System.Windows.Forms.DateTimePicker();

            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();

            this.gridProdutos = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.gridProdutos)).BeginInit();
            this.SuspendLayout();

            // comboLote
            this.comboLote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLote.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboLote.Location = new System.Drawing.Point(20, 40);
            this.comboLote.Size = new System.Drawing.Size(450, 25);
            this.comboLote.SelectedIndexChanged += new System.EventHandler(this.comboLote_SelectedIndexChanged);

            // label1
            this.label1.Text = "Lote:";
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(20, 15);

            // Labels
            this.labelNome.Text = "Nome do Item:";
            this.labelNome.Location = new System.Drawing.Point(20, 80);

            this.labelMarca.Text = "Marca:";
            this.labelMarca.Location = new System.Drawing.Point(20, 130);

            this.labelDescricao.Text = "Descrição:";
            this.labelDescricao.Location = new System.Drawing.Point(20, 180);

            this.labelCategoria.Text = "Categoria:";
            this.labelCategoria.Location = new System.Drawing.Point(20, 230);

            this.labelTamanhoCor.Text = "Tamanho/Cor:";
            this.labelTamanhoCor.Location = new System.Drawing.Point(350, 80);

            this.labelPrecoSugerido.Text = "Preço Sugerido:";
            this.labelPrecoSugerido.Location = new System.Drawing.Point(350, 130);

            this.labelPreco.Text = "Preço Venda:";
            this.labelPreco.Location = new System.Drawing.Point(350, 180);

            this.labelStatus.Text = "Status:";
            this.labelStatus.Location = new System.Drawing.Point(350, 230);

            this.labelDevolucao.Text = "Data Limite Devolução:";
            this.labelDevolucao.Location = new System.Drawing.Point(350, 280);

            // TextBoxes esquerda
            this.txtNome.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNome.Location = new System.Drawing.Point(20, 100);
            this.txtNome.Size = new System.Drawing.Size(300, 25);

            this.txtMarca.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMarca.Location = new System.Drawing.Point(20, 150);
            this.txtMarca.Size = new System.Drawing.Size(300, 25);

            this.txtDescricao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescricao.Location = new System.Drawing.Point(20, 200);
            this.txtDescricao.Size = new System.Drawing.Size(300, 25);

            this.txtCategoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCategoria.Location = new System.Drawing.Point(20, 250);
            this.txtCategoria.Size = new System.Drawing.Size(300, 25);

            // TextBoxes direita
            this.txtTamanhoCor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTamanhoCor.Location = new System.Drawing.Point(350, 100);
            this.txtTamanhoCor.Size = new System.Drawing.Size(300, 25);

            this.txtPrecoSugerido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrecoSugerido.Location = new System.Drawing.Point(350, 150);
            this.txtPrecoSugerido.Size = new System.Drawing.Size(300, 25);

            this.txtPreco.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPreco.Location = new System.Drawing.Point(350, 200);
            this.txtPreco.Size = new System.Drawing.Size(300, 25);

            this.txtStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStatus.Location = new System.Drawing.Point(350, 250);
            this.txtStatus.Size = new System.Drawing.Size(300, 25);

            // dtpDevolucao (visual only)
            this.dtpDevolucao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDevolucao.Location = new System.Drawing.Point(350, 300);
            this.dtpDevolucao.Size = new System.Drawing.Size(300, 25);
            this.dtpDevolucao.Enabled = false;

            // Buttons
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSalvar.Location = new System.Drawing.Point(20, 350);
            this.btnSalvar.Size = new System.Drawing.Size(120, 35);
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExcluir.Location = new System.Drawing.Point(160, 350);
            this.btnExcluir.Size = new System.Drawing.Size(120, 35);
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);

            this.btnExcel.Text = "Gerar Excel";
            this.btnExcel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExcel.Location = new System.Drawing.Point(300, 350);
            this.btnExcel.Size = new System.Drawing.Size(120, 35);
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);

            // Grid
            this.gridProdutos.Location = new System.Drawing.Point(20, 400);
            this.gridProdutos.Size = new System.Drawing.Size(630, 250);
            this.gridProdutos.ReadOnly = true;
            this.gridProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProdutos.MultiSelect = false;
            this.gridProdutos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProdutos_CellClick);

            // FormProduto
            this.ClientSize = new System.Drawing.Size(680, 670);
            this.Controls.Add(this.comboLote);
            this.Controls.Add(this.label1);

            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.labelMarca);
            this.Controls.Add(this.labelDescricao);
            this.Controls.Add(this.labelCategoria);
            this.Controls.Add(this.labelTamanhoCor);
            this.Controls.Add(this.labelPrecoSugerido);
            this.Controls.Add(this.labelPreco);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelDevolucao);

            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.txtTamanhoCor);
            this.Controls.Add(this.txtPrecoSugerido);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.dtpDevolucao);

            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnExcel);

            this.Controls.Add(this.gridProdutos);

            this.Name = "FormProduto";
            this.Text = "Cadastro de Produtos por Lote";

            ((System.ComponentModel.ISupportInitialize)(this.gridProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox comboLote;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Label labelMarca;
        private System.Windows.Forms.Label labelDescricao;
        private System.Windows.Forms.Label labelCategoria;
        private System.Windows.Forms.Label labelTamanhoCor;
        private System.Windows.Forms.Label labelPrecoSugerido;
        private System.Windows.Forms.Label labelPreco;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelDevolucao;

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.TextBox txtTamanhoCor;
        private System.Windows.Forms.TextBox txtPrecoSugerido;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.TextBox txtStatus;

        private System.Windows.Forms.DateTimePicker dtpDevolucao;

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnExcel;

        private System.Windows.Forms.DataGridView gridProdutos;
    }
}
