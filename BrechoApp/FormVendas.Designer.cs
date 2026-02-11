namespace BrechoApp
{
    partial class FormVendasPrincipal
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
            this.btnCadastrarVendedor = new System.Windows.Forms.Button();
            this.btnGerarVenda = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Título
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Size = new System.Drawing.Size(350, 40);
            this.lblTitulo.Text = "Vendas";

            // Botão Cadastrar Vendedor
            this.btnCadastrarVendedor.Location = new System.Drawing.Point(20, 80);
            this.btnCadastrarVendedor.Size = new System.Drawing.Size(200, 50);
            this.btnCadastrarVendedor.Text = "Cadastrar Vendedor";
            this.btnCadastrarVendedor.Click += new System.EventHandler(this.btnCadastrarVendedor_Click);

            // Botão Gerar Venda (no lugar do LoteRecebimento)
            this.btnGerarVenda.Location = new System.Drawing.Point(20, 150);
            this.btnGerarVenda.Size = new System.Drawing.Size(200, 50);
            this.btnGerarVenda.Text = "Gerar Venda";
            this.btnGerarVenda.Click += new System.EventHandler(this.btnGerarVenda_Click);

            // Botão Voltar
            this.btnVoltar.Location = new System.Drawing.Point(20, 220);
            this.btnVoltar.Size = new System.Drawing.Size(200, 50);
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(350, 300);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCadastrarVendedor);
            this.Controls.Add(this.btnGerarVenda);
            this.Controls.Add(this.btnVoltar);
            this.Text = "Vendas";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCadastrarVendedor;
        private System.Windows.Forms.Button btnGerarVenda;
        private System.Windows.Forms.Button btnVoltar;
    }
}