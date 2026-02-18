using System;
using System.Linq;
using System.Windows.Forms;
using BrechoApp.Data;
using BrechoApp.Models;
using BrechoApp.Enums;

namespace BrechoApp
{
    /// <summary>
    /// Formulário principal para realização de vendas.
    /// 
    /// Permite:
    /// - Seleção de vendedor (PN tipo Socio ou Vendedor)
    /// - Seleção de cliente (qualquer PN)
    /// - Adição de produtos disponíveis
    /// - Aplicação de descontos (% ou R$)
    /// - Finalização da venda com atualização de status dos produtos
    /// </summary>
    public partial class FormVenda : Form
    {
        // Constante para tolerância de arredondamento em cálculos financeiros
        private const double ROUNDING_TOLERANCE = 0.01;

        private Venda _vendaAtual;
        private readonly VendaRepository _vendaRepo;
        private readonly ParceiroNegocioRepository _parceiroRepo;
        private readonly ProdutoRepository _produtoRepo;

        public FormVenda()
        {
            InitializeComponent();

            _vendaRepo = new VendaRepository();
            _parceiroRepo = new ParceiroNegocioRepository();
            _produtoRepo = new ProdutoRepository();

            InicializarNovaVenda();
        }

        // ============================================================
        //  INICIALIZAR NOVA VENDA
        // ============================================================
        private void InicializarNovaVenda()
        {
            _vendaAtual = new Venda
            {
                CodigoVenda = _vendaRepo.GerarProximoCodigoVenda(),
                DataVenda = DateTime.Now,
                DataCriacao = DateTime.Now
            };

            LimparCampos();
            AtualizarInterface();
        }

        // ============================================================
        //  LIMPAR CAMPOS
        // ============================================================
        private void LimparCampos()
        {
            txtCodigoVenda.Text = _vendaAtual.CodigoVenda;
            txtVendedor.Clear();
            txtCliente.Clear();
            txtCodigoProduto.Clear();
            txtDescontoPercentual.Text = "0";
            txtDescontoValor.Text = "0,00";
            txtCampanha.Clear();
            txtDescontoCampanhaPercentual.Text = "0";
            txtDescontoCampanhaValor.Text = "0,00";
            txtValorTotalOriginal.Text = "0,00";
            txtValorTotalFinal.Text = "0,00";
            cboFormaPagamento.SelectedIndex = -1;
            txtObservacoes.Clear();

            _vendaAtual.IdVendedor = string.Empty;
            _vendaAtual.IdCliente = string.Empty;
            _vendaAtual.Itens.Clear();

            dgvProdutos.DataSource = null;
            dgvProdutos.DataSource = _vendaAtual.Itens;

            txtCodigoProduto.Focus();
        }

        // ============================================================
        //  ATUALIZAR INTERFACE
        // ============================================================
        private void AtualizarInterface()
        {
            // Configurar grid de produtos
            if (dgvProdutos.DataSource == null)
            {
                dgvProdutos.DataSource = _vendaAtual.Itens;
            }

            ConfigurarGrid();
            CalcularTotais();
        }

        // ============================================================
        //  CONFIGURAR GRID
        // ============================================================
        private void ConfigurarGrid()
        {
            dgvProdutos.AutoGenerateColumns = false;
            dgvProdutos.AllowUserToAddRows = false;
            dgvProdutos.ReadOnly = true;
            dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvProdutos.Columns.Clear();

            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdProduto",
                HeaderText = "Código",
                Width = 100
            });

            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NomeProduto",
                HeaderText = "Nome",
                Width = 150
            });

            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MarcaProduto",
                HeaderText = "Marca",
                Width = 120
            });

            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CategoriaProduto",
                HeaderText = "Categoria",
                Width = 100
            });

            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecoOriginal",
                HeaderText = "Preço Original",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecoFinalNegociado",
                HeaderText = "Preço Final",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
        }

        // ============================================================
        //  BOTÃO: SELECIONAR VENDEDOR
        // ============================================================
        private void btnSelecionarVendedor_Click(object sender, EventArgs e)
        {
            // Criar formulário em modo de seleção
            // Agora qualquer PN pode ser vendedor, então não precisamos filtrar
            var form = new FormCadastroParceiroNegocio(modoSelecao: true);

            if (form.ShowDialog() == DialogResult.OK)
            {
                var vendedor = _parceiroRepo.BuscarPorCodigo(form.ParceiroSelecionado);
                if (vendedor != null)
                {
                    _vendaAtual.IdVendedor = vendedor.CodigoParceiro;
                    txtVendedor.Text = $"{vendedor.CodigoParceiro} - {vendedor.Nome}";
                }
            }
        }

        // ============================================================
        //  BOTÃO: SELECIONAR CLIENTE
        // ============================================================
        private void btnSelecionarCliente_Click(object sender, EventArgs e)
        {
            var form = new FormCadastroParceiroNegocio(modoSelecao: true);

            if (form.ShowDialog() == DialogResult.OK)
            {
                var cliente = _parceiroRepo.BuscarPorCodigo(form.ParceiroSelecionado);
                if (cliente != null)
                {
                    _vendaAtual.IdCliente = cliente.CodigoParceiro;
                    txtCliente.Text = $"{cliente.CodigoParceiro} - {cliente.Nome}";
                }
            }
        }

        // ============================================================
        //  BOTÃO: ADICIONAR PRODUTO
        // ============================================================
        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            AdicionarProduto();
        }

        // ============================================================
        //  ENTER NO CAMPO DE CÓDIGO DO PRODUTO
        // ============================================================
        private void txtCodigoProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                AdicionarProduto();
            }
        }

        // ============================================================
        //  ADICIONAR PRODUTO À VENDA
        // ============================================================
        private void AdicionarProduto()
        {
            string codigoProduto = txtCodigoProduto.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigoProduto))
            {
                MessageBox.Show("Digite o código do produto.", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoProduto.Focus();
                return;
            }

            // Verificar se produto já foi adicionado
            if (_vendaAtual.Itens.Any(i => i.IdProduto == codigoProduto))
            {
                MessageBox.Show("Este produto já foi adicionado à venda.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoProduto.Clear();
                txtCodigoProduto.Focus();
                return;
            }

            // Buscar produto
            var produto = _produtoRepo.BuscarPorCodigo(codigoProduto);

            if (produto == null)
            {
                MessageBox.Show("Produto não encontrado.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigoProduto.Clear();
                txtCodigoProduto.Focus();
                return;
            }

            // Verificar se produto está disponível
            if (produto.StatusDoProduto != "Disponível")
            {
                MessageBox.Show($"Este produto não está disponível para venda.\nStatus atual: {produto.StatusDoProduto}", 
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoProduto.Clear();
                txtCodigoProduto.Focus();
                return;
            }

            // Adicionar item à venda
            var item = new VendaItem
            {
                IdProduto = produto.CodigoProduto,
                IdFornecedor = produto.CodigoParceiro,
                PrecoOriginal = produto.PrecoVendaDoItem,
                PrecoFinalNegociado = produto.PrecoVendaDoItem,
                NomeProduto = produto.NomeDoItem,
                MarcaProduto = produto.MarcaDoItem,
                CategoriaProduto = produto.CategoriaDoItem
            };

            _vendaAtual.Itens.Add(item);

            // Atualizar grid
            dgvProdutos.DataSource = null;
            dgvProdutos.DataSource = _vendaAtual.Itens;
            ConfigurarGrid();

            // Recalcular totais
            CalcularTotais();

            // Limpar campo e focar
            txtCodigoProduto.Clear();
            txtCodigoProduto.Focus();
        }

        // ============================================================
        //  CALCULAR TOTAIS
        // ============================================================
        private void CalcularTotais()
        {
            _vendaAtual.ValorTotalOriginal = _vendaAtual.Itens.Sum(i => i.PrecoOriginal);
            txtValorTotalOriginal.Text = _vendaAtual.ValorTotalOriginal.ToString("C2");

            // Aplicar desconto se houver
            AplicarDesconto();
        }

        // ============================================================
        //  APLICAR DESCONTO
        // ============================================================
        private void AplicarDesconto()
        {
            if (_vendaAtual.Itens.Count == 0)
            {
                _vendaAtual.ValorTotalFinal = 0;
                txtValorTotalFinal.Text = "0,00";
                return;
            }

            double descontoPercentual = 0;
            double descontoValor = 0;

            // Tentar ler desconto percentual
            if (double.TryParse(txtDescontoPercentual.Text, out descontoPercentual))
            {
                if (descontoPercentual < 0) descontoPercentual = 0;
                if (descontoPercentual > 100) descontoPercentual = 100;

                descontoValor = _vendaAtual.ValorTotalOriginal * (descontoPercentual / 100);
                txtDescontoValor.Text = descontoValor.ToString("F2");
            }
            else
            {
                // Tentar ler desconto em valor
                if (double.TryParse(txtDescontoValor.Text, out descontoValor))
                {
                    if (descontoValor < 0) descontoValor = 0;
                    if (descontoValor > _vendaAtual.ValorTotalOriginal) 
                        descontoValor = _vendaAtual.ValorTotalOriginal;

                    descontoPercentual = _vendaAtual.ValorTotalOriginal > 0
                        ? (descontoValor / _vendaAtual.ValorTotalOriginal) * 100
                        : 0;
                    txtDescontoPercentual.Text = descontoPercentual.ToString("F2");
                }
            }

            // Ler desconto de campanha percentual e calcular valor
            double descontoCampanhaPercentual = 0;
            double descontoCampanhaValor = 0;
            
            if (double.TryParse(txtDescontoCampanhaPercentual.Text, out descontoCampanhaPercentual))
            {
                if (descontoCampanhaPercentual < 0) descontoCampanhaPercentual = 0;
                if (descontoCampanhaPercentual > 100) descontoCampanhaPercentual = 100;
                
                // Calcular o valor do desconto de campanha
                descontoCampanhaValor = _vendaAtual.ValorTotalOriginal * (descontoCampanhaPercentual / 100);
                txtDescontoCampanhaValor.Text = descontoCampanhaValor.ToString("F2");
            }

            _vendaAtual.DescontoPercentual = descontoPercentual;
            _vendaAtual.DescontoValor = descontoValor;
            _vendaAtual.DescontoCampanhaPercentual = descontoCampanhaPercentual;
            _vendaAtual.DescontoCampanha = descontoCampanhaValor;
            _vendaAtual.ValorTotalFinal = _vendaAtual.ValorTotalOriginal - descontoValor - descontoCampanhaValor;

            // Ratear desconto entre os itens
            RatearDesconto();

            txtValorTotalFinal.Text = _vendaAtual.ValorTotalFinal.ToString("C2");

            // Atualizar grid
            dgvProdutos.Refresh();
        }

        // ============================================================
        //  RATEAR DESCONTO PROPORCIONALMENTE ENTRE PRODUTOS
        // ============================================================
        private void RatearDesconto()
        {
            if (_vendaAtual.Itens.Count == 0) return;

            double totalOriginal = _vendaAtual.Itens.Sum(i => i.PrecoOriginal);
            double descontoTotal = _vendaAtual.DescontoValor + _vendaAtual.DescontoCampanha;

            foreach (var item in _vendaAtual.Itens)
            {
                double proporcao = item.PrecoOriginal / totalOriginal;
                double descontoItem = descontoTotal * proporcao;
                item.PrecoFinalNegociado = item.PrecoOriginal - descontoItem;
            }

            // Garantir que soma final bate exatamente
            double somaFinal = _vendaAtual.Itens.Sum(i => i.PrecoFinalNegociado);
            double diferencaArredondamento = _vendaAtual.ValorTotalFinal - somaFinal;
            
            if (Math.Abs(diferencaArredondamento) > ROUNDING_TOLERANCE)
            {
                _vendaAtual.Itens[0].PrecoFinalNegociado += diferencaArredondamento;
            }
        }

        // ============================================================
        //  EVENTOS DE DESCONTO
        // ============================================================
        private void txtDescontoPercentual_TextChanged(object sender, EventArgs e)
        {
            AplicarDesconto();
        }

        private void txtDescontoValor_TextChanged(object sender, EventArgs e)
        {
            AplicarDesconto();
        }

        private void txtDescontoCampanhaPercentual_TextChanged(object sender, EventArgs e)
        {
            AplicarDesconto();
        }

        // ============================================================
        //  BOTÃO: FINALIZAR VENDA
        // ============================================================
        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            // Validações
            if (string.IsNullOrWhiteSpace(_vendaAtual.IdVendedor))
            {
                MessageBox.Show("Selecione um vendedor.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(_vendaAtual.IdCliente))
            {
                MessageBox.Show("Selecione um cliente.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_vendaAtual.Itens.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos um produto à venda.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboFormaPagamento.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione a forma de pagamento.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmar venda
            var confirmacao = MessageBox.Show(
                $"Confirmar venda {_vendaAtual.CodigoVenda}?\n\n" +
                $"Vendedor: {txtVendedor.Text}\n" +
                $"Cliente: {txtCliente.Text}\n" +
                $"Total de produtos: {_vendaAtual.Itens.Count}\n" +
                $"Valor final: {_vendaAtual.ValorTotalFinal:C2}\n" +
                $"Forma de pagamento: {cboFormaPagamento.Text}",
                "Confirmar Venda",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacao != DialogResult.Yes)
                return;

            try
            {
                // Preencher dados finais
                _vendaAtual.FormaPagamento = cboFormaPagamento.Text;
                _vendaAtual.Observacoes = txtObservacoes.Text.Trim();
                _vendaAtual.Campanha = txtCampanha.Text.Trim();
                if (string.IsNullOrWhiteSpace(_vendaAtual.Campanha))
                    _vendaAtual.Campanha = null;

                // Salvar venda (incluindo atualização de status dos produtos)
                _vendaRepo.SalvarVenda(_vendaAtual);

                MessageBox.Show(
                    $"Venda {_vendaAtual.CodigoVenda} finalizada com sucesso!\n\n" +
                    $"Valor total: {_vendaAtual.ValorTotalFinal:C2}",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Inicializar nova venda
                InicializarNovaVenda();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao finalizar venda:\n{ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        //  BOTÃO: CANCELAR
        // ============================================================
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_vendaAtual.Itens.Count > 0)
            {
                var confirmacao = MessageBox.Show(
                    "Existem produtos adicionados à venda.\nDeseja realmente cancelar?",
                    "Confirmar Cancelamento",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacao != DialogResult.Yes)
                    return;
            }

            this.Close();
        }

        // ============================================================
        //  BOTÃO: REMOVER PRODUTO
        // ============================================================
        private void btnRemoverProduto_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto para remover.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var index = dgvProdutos.SelectedRows[0].Index;
            _vendaAtual.Itens.RemoveAt(index);

            dgvProdutos.DataSource = null;
            dgvProdutos.DataSource = _vendaAtual.Itens;
            ConfigurarGrid();

            CalcularTotais();
        }
    }
}
