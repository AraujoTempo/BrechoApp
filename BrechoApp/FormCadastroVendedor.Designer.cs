using System;
using System.Windows.Forms;

namespace BrechoApp
{
    partial class FormCadastroVendedor
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvVendedores = new System.Windows.Forms.DataGridView();

            // Labels
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblCPF = new System.Windows.Forms.Label();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.lblObservacao = new System.Windows.Forms.Label();
            this.lblBanco = new System.Windows.Forms.Label();
            this.lblAgencia = new System.Windows.Forms.Label();
            this.lblConta = new System.Windows.Forms.Label();
            this.lblPix = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.lblComissao = new System.Windows.Forms.Label();
            this.lblAniversario = new System.Windows.Forms.Label();

            // Campos
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.txtAgencia = new System.Windows.Forms.TextBox();
            this.txtConta = new System.Windows.Forms.TextBox();
            this.txtPix = new System.Windows.Forms.TextBox();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.txtComissao = new System.Windows.Forms.TextBox();
            this.dtpAniversario = new System.Windows.Forms.DateTimePicker();

            // Botões
            this.btnIncluir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGerarVenda = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).BeginInit();
            this.SuspendLayout();

            // -------------------------------------------------------------
            // TÍTULO
            // -------------------------------------------------------------
            this.lblTitulo.Text = "Cadastro de Vendedor";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Size = new System.Drawing.Size(500, 40);

            // -------------------------------------------------------------
            // GRID DE VENDEDORES (TOPO)
            // -------------------------------------------------------------
            this.dgvVendedores.Location = new System.Drawing.Point(20, 60);
            this.dgvVendedores.Size = new System.Drawing.Size(1100, 320); // ← altura aumentada
            this.dgvVendedores.ReadOnly = true;
            this.dgvVendedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendedores.MultiSelect = false;
            this.dgvVendedores.ScrollBars = ScrollBars.Vertical; // ← garante rolagem
            this.dgvVendedores.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.dgvVendedores.RowTemplate.Height = 22;
            this.dgvVendedores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVendedores_CellClick);

            // -------------------------------------------------------------
            // CAMPOS EM DUAS COLUNAS
            // -------------------------------------------------------------
            int leftX = 20;
            int topY = 400;
            int spacing = 35;

            // Coluna esquerda
            this.lblCodigo.Text = "Código";
            this.lblCodigo.Location = new System.Drawing.Point(leftX, topY);
            this.txtCodigo.Location = new System.Drawing.Point(leftX + 100, topY);
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Width = 100;

            topY += spacing;
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new System.Drawing.Point(leftX, topY);
            this.txtNome.Location = new System.Drawing.Point(leftX + 100, topY);
            this.txtNome.Width = 250;

            topY += spacing;
            this.lblCPF.Text = "CPF";
            this.lblCPF.Location = new System.Drawing.Point(leftX, topY);
            this.txtCPF.Location = new System.Drawing.Point(leftX + 100, topY);
            this.txtCPF.Width = 150;

            topY += spacing;
            this.lblTelefone.Text = "Telefone";
            this.lblTelefone.Location = new System.Drawing.Point(leftX, topY);
            this.txtTelefone.Location = new System.Drawing.Point(leftX + 100, topY);
            this.txtTelefone.Width = 150;

            topY += spacing;
            this.lblEmail.Text = "Email";
            this.lblEmail.Location = new System.Drawing.Point(leftX, topY);
            this.txtEmail.Location = new System.Drawing.Point(leftX + 100, topY);
            this.txtEmail.Width = 250;

            topY += spacing;
            this.lblEndereco.Text = "Endereço";
            this.lblEndereco.Location = new System.Drawing.Point(leftX, topY);
            this.txtEndereco.Location = new System.Drawing.Point(leftX + 100, topY);
            this.txtEndereco.Width = 350;

            topY += spacing;
            this.lblObservacao.Text = "Observação";
            this.lblObservacao.Location = new System.Drawing.Point(leftX, topY);
            this.txtObservacao.Location = new System.Drawing.Point(leftX + 100, topY);
            this.txtObservacao.Width = 350;
            this.txtObservacao.Height = 60;
            this.txtObservacao.Multiline = true;

            // Coluna direita
            int rightX = 600;
            topY = 400;

            this.lblBanco.Text = "Banco";
            this.lblBanco.Location = new System.Drawing.Point(rightX, topY);
            this.txtBanco.Location = new System.Drawing.Point(rightX + 100, topY);
            this.txtBanco.Width = 200;

            topY += spacing;
            this.lblAgencia.Text = "Agência";
            this.lblAgencia.Location = new System.Drawing.Point(rightX, topY);
            this.txtAgencia.Location = new System.Drawing.Point(rightX + 100, topY);
            this.txtAgencia.Width = 120;

            topY += spacing;
            this.lblConta.Text = "Conta";
            this.lblConta.Location = new System.Drawing.Point(rightX, topY);
            this.txtConta.Location = new System.Drawing.Point(rightX + 100, topY);
            this.txtConta.Width = 150;

            topY += spacing;
            this.lblPix.Text = "Chave Pix";
            this.lblPix.Location = new System.Drawing.Point(rightX, topY);
            this.txtPix.Location = new System.Drawing.Point(rightX + 100, topY);
            this.txtPix.Width = 250;

            topY += spacing;
            this.lblSaldo.Text = "Saldo";
            this.lblSaldo.Location = new System.Drawing.Point(rightX, topY);
            this.txtSaldo.Location = new System.Drawing.Point(rightX + 100, topY);
            this.txtSaldo.Width = 100;

            topY += spacing;
            this.lblComissao.Text = "Comissão";
            this.lblComissao.Location = new System.Drawing.Point(rightX, topY);
            this.txtComissao.Location = new System.Drawing.Point(rightX + 100, topY);
            this.txtComissao.Width = 80;

            topY += spacing;
            this.lblAniversario.Text = "Aniversário";
            this.lblAniversario.Location = new System.Drawing.Point(rightX, topY);
            this.dtpAniversario.Location = new System.Drawing.Point(rightX + 100, topY);
            this.dtpAniversario.Format = DateTimePickerFormat.Short;

            // -------------------------------------------------------------
            // BOTÕES (AGORA MAIS ABAIXO)
            // -------------------------------------------------------------
            int buttonY = topY + spacing + 60;

            this.btnIncluir.Text = "Incluir";
            this.btnIncluir.Location = new System.Drawing.Point(20, buttonY);
            this.btnIncluir.Size = new System.Drawing.Size(80, 30);
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);

            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Location = new System.Drawing.Point(120, buttonY);
            this.btnSalvar.Size = new System.Drawing.Size(80, 30);
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            this.btnEditar.Text = "Editar";
            this.btnEditar.Location = new System.Drawing.Point(220, buttonY);
            this.btnEditar.Size = new System.Drawing.Size(80, 30);

            this.btnGerarVenda.Text = "Gerar Venda";
            this.btnGerarVenda.Location = new System.Drawing.Point(320, buttonY);
            this.btnGerarVenda.Size = new System.Drawing.Size(150, 30); // ← botão maior
            this.btnGerarVenda.Click += new System.EventHandler(this.btnGerarVenda_Click);

            // -------------------------------------------------------------
            // FORM
            // -------------------------------------------------------------
            this.ClientSize = new System.Drawing.Size(1150, buttonY + 80);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvVendedores);

            // Campos esquerda
            this.Controls.Add(this.lblCodigo); this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblNome); this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblCPF); this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.lblTelefone); this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.lblEmail); this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEndereco); this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.lblObservacao); this.Controls.Add(this.txtObservacao);

            // Campos direita
            this.Controls.Add(this.lblBanco); this.Controls.Add(this.txtBanco);
            this.Controls.Add(this.lblAgencia); this.Controls.Add(this.txtAgencia);
            this.Controls.Add(this.lblConta); this.Controls.Add(this.txtConta);
            this.Controls.Add(this.lblPix); this.Controls.Add(this.txtPix);
            this.Controls.Add(this.lblSaldo); this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.lblComissao); this.Controls.Add(this.txtComissao);
            this.Controls.Add(this.lblAniversario); this.Controls.Add(this.dtpAniversario);

            // Botões
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGerarVenda);

            this.Name = "FormCadastroVendedor";
            this.Text = "Cadastro de Vendedor";
            this.StartPosition = FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // -------------------------------------------------------------
        // DECLARAÇÃO DOS CONTROLES
        // -------------------------------------------------------------
        private System.Windows.Forms.Label lblTitulo;

        private System.Windows.Forms.DataGridView dgvVendedores;

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.Label lblObservacao;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.Label lblAgencia;
        private System.Windows.Forms.Label lblConta;
        private System.Windows.Forms.Label lblPix;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label lblComissao;
        private System.Windows.Forms.Label lblAniversario;

        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.TextBox txtAgencia;
        private System.Windows.Forms.TextBox txtConta;
        private System.Windows.Forms.TextBox txtPix;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.TextBox txtComissao;

        private System.Windows.Forms.DateTimePicker dtpAniversario;

        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnGerarVenda;
    }
}


