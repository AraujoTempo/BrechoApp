namespace BrechoApp
{
    partial class FormCadastroParceiroNegocio
    {
        private System.ComponentModel.IContainer components = null;

        // ============================================================
        //  DECLARAÇÃO DE CONTROLES
        // ============================================================
        private System.Windows.Forms.DataGridView dataGridParceiros;

        private System.Windows.Forms.TextBox txtCodigoParceiro;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.TextBox txtApelido;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.TextBox txtAgencia;
        private System.Windows.Forms.TextBox txtConta;
        private System.Windows.Forms.TextBox txtPix;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.TextBox txtPercentualComissao;
        private System.Windows.Forms.TextBox txtSaldoCredito;
        private System.Windows.Forms.TextBox txtBusca;

        private System.Windows.Forms.CheckBox chkAutorizaDoacao;
        private System.Windows.Forms.DateTimePicker dtpAniversario;

        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnLotes;

        private System.Windows.Forms.Label lblCodigoParceiro;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.Label lblApelido;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.Label lblAgencia;
        private System.Windows.Forms.Label lblConta;
        private System.Windows.Forms.Label lblPix;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.Label lblComissao;
        private System.Windows.Forms.Label lblSaldoCredito;
        private System.Windows.Forms.Label lblBusca;
        private System.Windows.Forms.Label lblAniversario;

        // ============================================================
        //  DISPOSE
        // ============================================================
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        // ============================================================
        //  INITIALIZE COMPONENT
        // ============================================================
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // ============================================================
            //  GRID DE Parceiros
            // ============================================================
            this.dataGridParceiros = new System.Windows.Forms.DataGridView();
            this.dataGridParceiros.Location = new System.Drawing.Point(20, 20);
            this.dataGridParceiros.Size = new System.Drawing.Size(860, 220);
            this.dataGridParceiros.ReadOnly = true;
            this.dataGridParceiros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridParceiros.MultiSelect = false;
            this.dataGridParceiros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridParceiros_CellClick);

            // ============================================================
            //  CAMPOS DO FORMULÁRIO
            // ============================================================
            this.lblCodigoParceiro = new System.Windows.Forms.Label();
            this.lblCodigoParceiro.Text = "Código:";
            this.lblCodigoParceiro.Location = new System.Drawing.Point(20, 260);

            this.txtCodigoParceiro = new System.Windows.Forms.TextBox();
            this.txtCodigoParceiro.Location = new System.Drawing.Point(20, 285);
            this.txtCodigoParceiro.Size = new System.Drawing.Size(150, 27);
            this.txtCodigoParceiro.ReadOnly = true;

            this.lblNome = new System.Windows.Forms.Label();
            this.lblNome.Text = "Nome:";
            this.lblNome.Location = new System.Drawing.Point(20, 325);

            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtNome.Location = new System.Drawing.Point(20, 350);
            this.txtNome.Size = new System.Drawing.Size(250, 27);

            this.lblCPF = new System.Windows.Forms.Label();
            this.lblCPF.Text = "CPF:";
            this.lblCPF.Location = new System.Drawing.Point(20, 390);

            this.txtCPF = new System.Windows.Forms.TextBox();
            this.txtCPF.Location = new System.Drawing.Point(20, 415);
            this.txtCPF.Size = new System.Drawing.Size(250, 27);

            this.lblApelido = new System.Windows.Forms.Label();
            this.lblApelido.Text = "Apelido:";
            this.lblApelido.Location = new System.Drawing.Point(20, 455);

            this.txtApelido = new System.Windows.Forms.TextBox();
            this.txtApelido.Location = new System.Drawing.Point(20, 480);
            this.txtApelido.Size = new System.Drawing.Size(250, 27);

            this.lblTelefone = new System.Windows.Forms.Label();
            this.lblTelefone.Text = "Telefone:";
            this.lblTelefone.Location = new System.Drawing.Point(20, 520);

            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.txtTelefone.Location = new System.Drawing.Point(20, 545);
            this.txtTelefone.Size = new System.Drawing.Size(250, 27);

            // ============================================================
            //  CAMPOS BANCÁRIOS
            // ============================================================
            this.lblBanco = new System.Windows.Forms.Label();
            this.lblBanco.Text = "Banco:";
            this.lblBanco.Location = new System.Drawing.Point(300, 260);

            this.txtBanco = new System.Windows.Forms.TextBox();
            this.txtBanco.Location = new System.Drawing.Point(300, 285);
            this.txtBanco.Size = new System.Drawing.Size(150, 27);

            this.lblAgencia = new System.Windows.Forms.Label();
            this.lblAgencia.Text = "Agência:";
            this.lblAgencia.Location = new System.Drawing.Point(300, 325);

            this.txtAgencia = new System.Windows.Forms.TextBox();
            this.txtAgencia.Location = new System.Drawing.Point(300, 350);
            this.txtAgencia.Size = new System.Drawing.Size(150, 27);

            this.lblConta = new System.Windows.Forms.Label();
            this.lblConta.Text = "Conta:";
            this.lblConta.Location = new System.Drawing.Point(300, 390);

            this.txtConta = new System.Windows.Forms.TextBox();
            this.txtConta.Location = new System.Drawing.Point(300, 415);
            this.txtConta.Size = new System.Drawing.Size(150, 27);

            this.lblPix = new System.Windows.Forms.Label();
            this.lblPix.Text = "Chave Pix:";
            this.lblPix.Location = new System.Drawing.Point(300, 455);

            this.txtPix = new System.Windows.Forms.TextBox();
            this.txtPix.Location = new System.Drawing.Point(300, 480);
            this.txtPix.Size = new System.Drawing.Size(250, 27);

            this.lblSaldoCredito = new System.Windows.Forms.Label();
            this.lblSaldoCredito.Text = "Saldo Crédito:";
            this.lblSaldoCredito.Location = new System.Drawing.Point(300, 520);

            this.txtSaldoCredito = new System.Windows.Forms.TextBox();
            this.txtSaldoCredito.Location = new System.Drawing.Point(300, 545);
            this.txtSaldoCredito.Size = new System.Drawing.Size(150, 27);
            this.txtSaldoCredito.ReadOnly = true;

            // ============================================================
            //  CAMPOS DE CONTATO E OUTROS
            // ============================================================
            this.lblEndereco = new System.Windows.Forms.Label();
            this.lblEndereco.Text = "Endereço:";
            this.lblEndereco.Location = new System.Drawing.Point(580, 260);

            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtEndereco.Location = new System.Drawing.Point(580, 285);
            this.txtEndereco.Size = new System.Drawing.Size(300, 27);

            this.lblEmail = new System.Windows.Forms.Label();
            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new System.Drawing.Point(580, 325);

            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtEmail.Location = new System.Drawing.Point(580, 350);
            this.txtEmail.Size = new System.Drawing.Size(300, 27);

            this.lblObs = new System.Windows.Forms.Label();
            this.lblObs.Text = "Observação:";
            this.lblObs.Location = new System.Drawing.Point(580, 390);

            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.txtObservacao.Location = new System.Drawing.Point(580, 415);
            this.txtObservacao.Size = new System.Drawing.Size(300, 27);

            this.lblComissao = new System.Windows.Forms.Label();
            this.lblComissao.Text = "Comissão (%):";
            this.lblComissao.Location = new System.Drawing.Point(580, 455);

            this.txtPercentualComissao = new System.Windows.Forms.TextBox();
            this.txtPercentualComissao.Location = new System.Drawing.Point(580, 480);
            this.txtPercentualComissao.Size = new System.Drawing.Size(120, 27);

            this.lblAniversario = new System.Windows.Forms.Label();
            this.lblAniversario.Text = "Aniversário:";
            this.lblAniversario.Location = new System.Drawing.Point(720, 455);

            this.dtpAniversario = new System.Windows.Forms.DateTimePicker();
            this.dtpAniversario.Location = new System.Drawing.Point(720, 480);
            this.dtpAniversario.Size = new System.Drawing.Size(160, 27);
            this.dtpAniversario.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.chkAutorizaDoacao = new System.Windows.Forms.CheckBox();
            this.chkAutorizaDoacao.Text = "Autoriza Doação";
            this.chkAutorizaDoacao.Location = new System.Drawing.Point(580, 520);

            // ============================================================
            //  BUSCA
            // ============================================================
            this.lblBusca = new System.Windows.Forms.Label();
            this.lblBusca.Text = "Buscar:";
            this.lblBusca.Location = new System.Drawing.Point(20, 590);

            this.txtBusca = new System.Windows.Forms.TextBox();
            this.txtBusca.Location = new System.Drawing.Point(20, 615);
            this.txtBusca.Size = new System.Drawing.Size(250, 27);
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);

            // ============================================================
            //  BOTÕES (ALINHADOS À DIREITA)
            // ============================================================

            // Botão INCLUIR
            this.btnIncluir = new System.Windows.Forms.Button();
            this.btnIncluir.Text = "Incluir";
            this.btnIncluir.Location = new System.Drawing.Point(500, 610);
            this.btnIncluir.Size = new System.Drawing.Size(100, 35);
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);

            // Botão SALVAR
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Location = new System.Drawing.Point(610, 610);
            this.btnSalvar.Size = new System.Drawing.Size(100, 35);
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            // Botão EDITAR
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEditar.Text = "Editar";
            this.btnEditar.Location = new System.Drawing.Point(720, 610);
            this.btnEditar.Size = new System.Drawing.Size(100, 35);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            // Botão EXPORTAR EXCEL
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnExportarExcel.Text = "Exportar Excel";
            this.btnExportarExcel.Location = new System.Drawing.Point(830, 610);
            this.btnExportarExcel.Size = new System.Drawing.Size(130, 35);
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);

            // Botão LOTES (TEXTO EM DUAS LINHAS)
            this.btnLotes = new System.Windows.Forms.Button();
            this.btnLotes.Text = "Lotes de\nRecebimento";
            this.btnLotes.Location = new System.Drawing.Point(970, 610);
            this.btnLotes.Size = new System.Drawing.Size(120, 35);
            this.btnLotes.UseCompatibleTextRendering = true;
            this.btnLotes.Click += new System.EventHandler(this.btnLotes_Click);

            // ============================================================
            //  ADICIONANDO CONTROLES AO FORMULÁRIO
            // ============================================================
            this.Controls.Add(this.dataGridParceiros);

            this.Controls.Add(this.lblCodigoParceiro);
            this.Controls.Add(this.txtCodigoParceiro);

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);

            this.Controls.Add(this.lblCPF);
            this.Controls.Add(this.txtCPF);

            this.Controls.Add(this.lblApelido);
            this.Controls.Add(this.txtApelido);

            this.Controls.Add(this.lblTelefone);
            this.Controls.Add(this.txtTelefone);

            this.Controls.Add(this.lblBanco);
            this.Controls.Add(this.txtBanco);

            this.Controls.Add(this.lblAgencia);
            this.Controls.Add(this.txtAgencia);

            this.Controls.Add(this.lblConta);
            this.Controls.Add(this.txtConta);

            this.Controls.Add(this.lblPix);
            this.Controls.Add(this.txtPix);

            this.Controls.Add(this.lblSaldoCredito);
            this.Controls.Add(this.txtSaldoCredito);

            this.Controls.Add(this.lblEndereco);
            this.Controls.Add(this.txtEndereco);

            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);

            this.Controls.Add(this.lblObs);
            this.Controls.Add(this.txtObservacao);

            this.Controls.Add(this.lblComissao);
            this.Controls.Add(this.txtPercentualComissao);

            this.Controls.Add(this.lblAniversario);
            this.Controls.Add(this.dtpAniversario);

            this.Controls.Add(this.chkAutorizaDoacao);

            this.Controls.Add(this.lblBusca);
            this.Controls.Add(this.txtBusca);

            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.btnLotes);

            // ============================================================
            //  FORM
            // ============================================================
            this.ClientSize = new System.Drawing.Size(1120, 680);
            this.Name = "FormCadastroParceiro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CURADORIA";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridParceiros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
