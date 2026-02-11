namespace BrechoApp
{
    partial class FormLoteRecebimento
    {
        private System.ComponentModel.IContainer components = null;

        // ============================================================
        // DECLARAÇÃO DE CONTROLES
        // ============================================================
        private System.Windows.Forms.Label lblCodigoLote;
        private System.Windows.Forms.TextBox txtCodigoLote;

        private System.Windows.Forms.Label lblParceiro;
        private System.Windows.Forms.TextBox txtParceiro;
        private System.Windows.Forms.TextBox txtCodigoParceiro;

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;

        private System.Windows.Forms.Label lblDataRecebimento;
        private System.Windows.Forms.TextBox txtDataRecebimento;

        private System.Windows.Forms.Label lblDataAprovacao;
        private System.Windows.Forms.TextBox txtDataAprovacao;

        private System.Windows.Forms.Label lblObservacoes;
        private System.Windows.Forms.TextBox txtObservacoes;

        private System.Windows.Forms.Label lblTotalItens;
        private System.Windows.Forms.TextBox txtTotalItens;

        private System.Windows.Forms.Label lblTotalSugerido;
        private System.Windows.Forms.TextBox txtTotalSugerido;

        private System.Windows.Forms.Label lblTotalVenda;
        private System.Windows.Forms.TextBox txtTotalVenda;

        private System.Windows.Forms.Label lblTotalValor;
        private System.Windows.Forms.TextBox txtTotalValor;

        private System.Windows.Forms.DataGridView dgvItens;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecoSugerido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecoVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservacao;

        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnBuscarLote;
        private System.Windows.Forms.Button btnListarLotes;
        private System.Windows.Forms.Button btnAprovar;
        private System.Windows.Forms.Button btnReabrir;
        private System.Windows.Forms.Button btnExcluirLote;
        private System.Windows.Forms.Button btnComprarLote;
        private System.Windows.Forms.Button btnAdicionarItem;
        private System.Windows.Forms.Button btnEditarItem;
        private System.Windows.Forms.Button btnExcluirItem;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnFechar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblCodigoLote = new System.Windows.Forms.Label();
            this.txtCodigoLote = new System.Windows.Forms.TextBox();

            this.lblParceiro = new System.Windows.Forms.Label();
            this.txtParceiro = new System.Windows.Forms.TextBox();
            this.txtCodigoParceiro = new System.Windows.Forms.TextBox();

            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();

            this.lblDataRecebimento = new System.Windows.Forms.Label();
            this.txtDataRecebimento = new System.Windows.Forms.TextBox();

            this.lblDataAprovacao = new System.Windows.Forms.Label();
            this.txtDataAprovacao = new System.Windows.Forms.TextBox();

            this.lblObservacoes = new System.Windows.Forms.Label();
            this.txtObservacoes = new System.Windows.Forms.TextBox();

            this.lblTotalItens = new System.Windows.Forms.Label();
            this.txtTotalItens = new System.Windows.Forms.TextBox();

            this.lblTotalSugerido = new System.Windows.Forms.Label();
            this.txtTotalSugerido = new System.Windows.Forms.TextBox();

            this.lblTotalVenda = new System.Windows.Forms.Label();
            this.txtTotalVenda = new System.Windows.Forms.TextBox();

            this.lblTotalValor = new System.Windows.Forms.Label();
            this.txtTotalValor = new System.Windows.Forms.TextBox();

            this.dgvItens = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecoSugerido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecoVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservacao = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.btnNovo = new System.Windows.Forms.Button();
            this.btnBuscarLote = new System.Windows.Forms.Button();
            this.btnListarLotes = new System.Windows.Forms.Button();
            this.btnAprovar = new System.Windows.Forms.Button();
            this.btnReabrir = new System.Windows.Forms.Button();
            this.btnExcluirLote = new System.Windows.Forms.Button();
            this.btnComprarLote = new System.Windows.Forms.Button();
            this.btnAdicionarItem = new System.Windows.Forms.Button();
            this.btnEditarItem = new System.Windows.Forms.Button();
            this.btnExcluirItem = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).BeginInit();
            this.SuspendLayout();

            // ============================================================
            // CÓDIGO DO LOTE
            // ============================================================
            this.lblCodigoLote.AutoSize = true;
            this.lblCodigoLote.Location = new System.Drawing.Point(20, 20);
            this.lblCodigoLote.Text = "Código do Lote:";

            this.txtCodigoLote.Location = new System.Drawing.Point(140, 17);
            this.txtCodigoLote.Size = new System.Drawing.Size(120, 23);

            // ============================================================
            // PARCEIRO
            // ============================================================
            this.lblParceiro.AutoSize = true;
            this.lblParceiro.Location = new System.Drawing.Point(20, 55);
            this.lblParceiro.Text = "Parceiro:";

            this.txtParceiro.Location = new System.Drawing.Point(140, 52);
            this.txtParceiro.ReadOnly = true;
            this.txtParceiro.Size = new System.Drawing.Size(300, 23);

            this.txtCodigoParceiro.Location = new System.Drawing.Point(460, 52);
            this.txtCodigoParceiro.ReadOnly = true;
            this.txtCodigoParceiro.Size = new System.Drawing.Size(80, 23);

            // ============================================================
            // STATUS DO LOTE
            // ============================================================
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 90);
            this.lblStatus.Text = "Status do Lote:";

            this.txtStatus.Location = new System.Drawing.Point(140, 87);
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(150, 23);

            // ============================================================
            // DATAS
            // ============================================================
            this.lblDataRecebimento.AutoSize = true;
            this.lblDataRecebimento.Location = new System.Drawing.Point(20, 130);
            this.lblDataRecebimento.Text = "Data de Recebimento:";

            this.txtDataRecebimento.Location = new System.Drawing.Point(140, 155);
            this.txtDataRecebimento.ReadOnly = true;
            this.txtDataRecebimento.Size = new System.Drawing.Size(120, 23);

            this.lblDataAprovacao.AutoSize = true;
            this.lblDataAprovacao.Location = new System.Drawing.Point(280, 130);
            this.lblDataAprovacao.Text = "Data de Aprovação:";

            this.txtDataAprovacao.Location = new System.Drawing.Point(390, 155);
            this.txtDataAprovacao.ReadOnly = true;
            this.txtDataAprovacao.Size = new System.Drawing.Size(120, 23);

            // ============================================================
            // OBSERVAÇÕES
            // ============================================================
            this.lblObservacoes.AutoSize = true;
            this.lblObservacoes.Location = new System.Drawing.Point(20, 190);
            this.lblObservacoes.Text = "Observações do Lote:";

            this.txtObservacoes.Location = new System.Drawing.Point(140, 215);
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Size = new System.Drawing.Size(370, 70);
            this.txtObservacoes.Leave += new System.EventHandler(this.txtObservacoes_Leave);

            // ============================================================
            // TOTAIS
            // ============================================================
            this.lblTotalItens.AutoSize = true;
            this.lblTotalItens.Location = new System.Drawing.Point(20, 300);
            this.lblTotalItens.Text = "Total Itens:";

            this.txtTotalItens.Location = new System.Drawing.Point(100, 297);
            this.txtTotalItens.ReadOnly = true;
            this.txtTotalItens.Size = new System.Drawing.Size(60, 23);

            this.lblTotalSugerido.AutoSize = true;
            this.lblTotalSugerido.Location = new System.Drawing.Point(180, 300);
            this.lblTotalSugerido.Text = "Total Sugerido:";

            this.txtTotalSugerido.Location = new System.Drawing.Point(280, 297);
            this.txtTotalSugerido.ReadOnly = true;
            this.txtTotalSugerido.Size = new System.Drawing.Size(80, 23);

            this.lblTotalVenda.AutoSize = true;
            this.lblTotalVenda.Location = new System.Drawing.Point(380, 300);
            this.lblTotalVenda.Text = "Total Venda:";

            this.txtTotalVenda.Location = new System.Drawing.Point(470, 297);
            this.txtTotalVenda.ReadOnly = true;
            this.txtTotalVenda.Size = new System.Drawing.Size(80, 23);

            this.lblTotalValor.AutoSize = true;
            this.lblTotalValor.Location = new System.Drawing.Point(570, 300);
            this.lblTotalValor.Text = "Total Geral:";

            this.txtTotalValor.Location = new System.Drawing.Point(650, 297);
            this.txtTotalValor.ReadOnly = true;
            this.txtTotalValor.Size = new System.Drawing.Size(80, 23);

            // ============================================================
            // GRID DE ITENS
            // ============================================================
            this.dgvItens.AllowUserToAddRows = false;
            this.dgvItens.AllowUserToDeleteRows = false;
            this.dgvItens.AutoGenerateColumns = false;
            this.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId,
                this.colNome,
                this.colMarca,
                this.colCategoria,
                this.colPrecoSugerido,
                this.colPrecoVenda,
                this.colStatus,
                this.colObservacao
            });

            this.dgvItens.Location = new System.Drawing.Point(20, 340);
            this.dgvItens.MultiSelect = false;
            this.dgvItens.ReadOnly = true;
            this.dgvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItens.Size = new System.Drawing.Size(710, 240);

            this.dgvItens.SelectionChanged += new System.EventHandler(this.dgvItens_SelectionChanged);
            this.dgvItens.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItens_CellDoubleClick);

            // ============================================================
            // COLUNAS DO GRID
            // ============================================================
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.DataPropertyName = "Id";
            this.colId.Width = 50;

            this.colNome.HeaderText = "Nome do Item";
            this.colNome.Name = "colNome";
            this.colNome.DataPropertyName = "NomeDoItem";
            this.colNome.Width = 150;

            this.colMarca.HeaderText = "Marca";
            this.colMarca.Name = "colMarca";
            this.colMarca.DataPropertyName = "MarcaDoItem";
            this.colMarca.Width = 120;

            this.colCategoria.HeaderText = "Categoria";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.DataPropertyName = "CategoriaDoItem";
            this.colCategoria.Width = 120;

            this.colPrecoSugerido.HeaderText = "Preço Sugerido";
            this.colPrecoSugerido.Name = "colPrecoSugerido";
            this.colPrecoSugerido.DataPropertyName = "PrecoSugeridoDoItem";
            this.colPrecoSugerido.Width = 120;

            this.colPrecoVenda.HeaderText = "Preço Venda";
            this.colPrecoVenda.Name = "colPrecoVenda";
            this.colPrecoVenda.DataPropertyName = "PrecoVendaDoItem";
            this.colPrecoVenda.Width = 120;

            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.DataPropertyName = "StatusItem";
            this.colStatus.Width = 120;

            this.colObservacao.HeaderText = "Observação";
            this.colObservacao.Name = "colObservacao";
            this.colObservacao.DataPropertyName = "ObservacaoDoItem";
            this.colObservacao.Width = 250;

            // ============================================================
            // BOTÕES
            // ============================================================
            this.btnNovo.Text = "Novo Lote";
            this.btnNovo.Location = new System.Drawing.Point(600, 15);
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);

            this.btnBuscarLote.Text = "Buscar";
            this.btnBuscarLote.Location = new System.Drawing.Point(270, 15);
            this.btnBuscarLote.Click += new System.EventHandler(this.btnBuscarLote_Click);

            this.btnListarLotes.Text = "Listar Lotes";
            this.btnListarLotes.Location = new System.Drawing.Point(360, 15);
            this.btnListarLotes.Click += new System.EventHandler(this.btnListarLotes_Click);

            this.btnAprovar.Text = "Aprovar";
            this.btnAprovar.Location = new System.Drawing.Point(600, 50);
            this.btnAprovar.Click += new System.EventHandler(this.btnAprovar_Click);

            this.btnReabrir.Text = "Reabrir";
            this.btnReabrir.Location = new System.Drawing.Point(600, 85);
            this.btnReabrir.Click += new System.EventHandler(this.btnReabrir_Click);

            this.btnExcluirLote.Text = "Excluir Lote";
            this.btnExcluirLote.Location = new System.Drawing.Point(600, 120);
            this.btnExcluirLote.Click += new System.EventHandler(this.btnExcluirLote_Click);

            this.btnComprarLote.Text = "Comprar Lote";
            this.btnComprarLote.Location = new System.Drawing.Point(600, 155);

            this.btnAdicionarItem.Text = "Adicionar Item";
            this.btnAdicionarItem.Location = new System.Drawing.Point(20, 600);
            this.btnAdicionarItem.Click += new System.EventHandler(this.btnAdicionarItem_Click);

            this.btnEditarItem.Text = "Editar Item";
            this.btnEditarItem.Location = new System.Drawing.Point(150, 600);
            this.btnEditarItem.Click += new System.EventHandler(this.btnEditarItem_Click);

            this.btnExcluirItem.Text = "Excluir Item";
            this.btnExcluirItem.Location = new System.Drawing.Point(280, 600);
            this.btnExcluirItem.Click += new System.EventHandler(this.btnExcluirItem_Click);

            this.btnExportarExcel.Text = "Exportar Excel";
            this.btnExportarExcel.Location = new System.Drawing.Point(410, 600);
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);

            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Location = new System.Drawing.Point(540, 600);
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            this.btnFechar.Text = "Fechar";
            this.btnFechar.Location = new System.Drawing.Point(630, 600);
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);

            // ============================================================
            // FORM
            // ============================================================
            this.ClientSize = new System.Drawing.Size(760, 650);

            this.Controls.Add(this.lblCodigoLote);
            this.Controls.Add(this.txtCodigoLote);

            this.Controls.Add(this.lblParceiro);
            this.Controls.Add(this.txtParceiro);
            this.Controls.Add(this.txtCodigoParceiro);

            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtStatus);

            this.Controls.Add(this.lblDataRecebimento);
            this.Controls.Add(this.txtDataRecebimento);

            this.Controls.Add(this.lblDataAprovacao);
            this.Controls.Add(this.txtDataAprovacao);

            this.Controls.Add(this.lblObservacoes);
            this.Controls.Add(this.txtObservacoes);

            this.Controls.Add(this.lblTotalItens);
            this.Controls.Add(this.txtTotalItens);

            this.Controls.Add(this.lblTotalSugerido);
            this.Controls.Add(this.txtTotalSugerido);

            this.Controls.Add(this.lblTotalVenda);
            this.Controls.Add(this.txtTotalVenda);

            this.Controls.Add(this.lblTotalValor);
            this.Controls.Add(this.txtTotalValor);

            this.Controls.Add(this.dgvItens);

            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnBuscarLote);
            this.Controls.Add(this.btnListarLotes);
            this.Controls.Add(this.btnAprovar);
            this.Controls.Add(this.btnReabrir);
            this.Controls.Add(this.btnExcluirLote);
            this.Controls.Add(this.btnComprarLote);
            this.Controls.Add(this.btnAdicionarItem);
            this.Controls.Add(this.btnEditarItem);
            this.Controls.Add(this.btnExcluirItem);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnFechar);

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "FormLoteRecebimento";
            this.Text = "Lote de Recebimento – Parceiro de Negócio";

            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
