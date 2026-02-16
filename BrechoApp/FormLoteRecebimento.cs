#pragma warning disable CA1416
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using BrechoApp.Data;
using BrechoApp.Models;
using ClosedXML.Excel;

namespace BrechoApp
{
    /// <summary>
    /// Tela responsável por gerenciar o fluxo completo de:
    /// Parceiro → Lote → Itens → Aprovação → Produtos
    /// </summary>
    public partial class FormLoteRecebimento : Form
    {
        // ============================================================
        // REPOSITÓRIOS
        // ============================================================
        private readonly LoteRecebimentoRepository _repoLote;
        private readonly ItemLoteRepository _repoItem;
        private readonly ProdutoRepository _repoProduto;
        private readonly ParceiroNegocioRepository _repoParceiro;

        // ============================================================
        // OBJETOS EM MEMÓRIA
        // ============================================================
        private LoteRecebimento _loteAtual;
        private ParceiroNegocio _parceiroAtual;

        // ============================================================
        // NORMALIZAÇÃO DE CÓDIGOS
        // ============================================================
        private string NormalizarCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return "";

            return codigo
                .Trim()
                .Replace("–", "-")
                .Replace("—", "-")
                .Replace("‑", "-")
                .Replace("\r", "")
                .Replace("\n", "");
        }

        // ============================================================
        // LOGGING
        // ============================================================
        private void Log(string mensagem)
        {
            try
            {
                string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
                if (!Directory.Exists(logPath))
                    Directory.CreateDirectory(logPath);

                string logFile = Path.Combine(logPath, $"aprovacao_lote_{DateTime.Now:yyyy-MM-dd}.log");
                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] {mensagem}{Environment.NewLine}";

                File.AppendAllText(logFile, logEntry);
            }
            catch
            {
                // Silently ignore logging errors to avoid breaking the application
            }
        }

        // ============================================================
        // CONSTRUTOR PRINCIPAL
        // ============================================================
        public FormLoteRecebimento(ParceiroNegocio parceiro)
        {
            InitializeComponent();

            _repoLote = new LoteRecebimentoRepository();
            _repoItem = new ItemLoteRepository();
            _repoProduto = new ProdutoRepository();
            _repoParceiro = new ParceiroNegocioRepository();

            _parceiroAtual = parceiro;
            _parceiroAtual.CodigoParceiro = NormalizarCodigo(_parceiroAtual.CodigoParceiro);

            dgvItens.AutoGenerateColumns = false;

            CarregarParceiroNaTela();
            AtualizarBotoes();
        }

        // ============================================================
        // EXIBE DADOS DO PARCEIRO
        // ============================================================
        private void CarregarParceiroNaTela()
        {
            if (_parceiroAtual == null)
                return;

            txtCodigoParceiro.Text = _parceiroAtual.CodigoParceiro;
            txtParceiro.Text = _parceiroAtual.Nome;
        }

        // ============================================================
        // CARREGA LOTE PELO CÓDIGO
        // ============================================================
        private void CarregarLote(string codigoLote)
        {
            codigoLote = NormalizarCodigo(codigoLote);

            _loteAtual = _repoLote.BuscarPorCodigo(codigoLote);

            if (_loteAtual == null)
            {
                MessageBox.Show("Lote não encontrado.");
                LimparCamposLote();
                return;
            }

            txtCodigoLote.Text = _loteAtual.CodigoLoteRecebimento;
            txtStatus.Text = _loteAtual.StatusLote;
            txtDataRecebimento.Text = _loteAtual.DataRecebimento?.ToString("dd/MM/yyyy HH:mm") ?? "";
            txtDataAprovacao.Text = _loteAtual.DataAprovacao?.ToString("dd/MM/yyyy HH:mm") ?? "";
            txtObservacoes.Text = _loteAtual.Observacoes ?? "";

            CarregarItens();
            AtualizarTotais();
            AtualizarBotoes();
        }

        // ============================================================
        // LIMPA A TELA
        // ============================================================
        private void LimparCamposLote()
        {
            _loteAtual = null;

            txtCodigoLote.Text = "";
            txtStatus.Text = "";
            txtDataRecebimento.Text = "";
            txtDataAprovacao.Text = "";
            txtObservacoes.Text = "";

            dgvItens.DataSource = null;

            txtTotalVenda.Text = "0,00";
            txtTotalSugerido.Text = "0,00";

            AtualizarBotoes();
        }

        // ============================================================
        // CARREGA ITENS DO LOTE
        // ============================================================
        private void CarregarItens()
        {
            if (_loteAtual == null)
            {
                dgvItens.DataSource = null;
                return;
            }

            var itens = _repoItem.ListarItensPorLote(_loteAtual.CodigoLoteRecebimento);

            dgvItens.AutoGenerateColumns = false;
            dgvItens.DataSource = itens;

            AtualizarEstadoBotaoEditarItem();
        }

        // ============================================================
        // ATUALIZA TOTAIS
        // ============================================================
        private void AtualizarTotais()
        {
            if (_loteAtual == null)
                return;

            var itens = _repoItem.ListarItensPorLote(_loteAtual.CodigoLoteRecebimento);

            double totalSugerido = 0;
            double totalVenda = 0;

            foreach (var item in itens)
            {
                totalSugerido += item.PrecoSugeridoDoItem;
                totalVenda += item.PrecoVendaDoItem;
            }

            txtTotalSugerido.Text = totalSugerido.ToString("N2");
            txtTotalVenda.Text = totalVenda.ToString("N2");
        }

        // ============================================================
        // ATUALIZA BOTÕES
        // ============================================================
        private void AtualizarBotoes()
        {
            if (_loteAtual == null)
            {
                btnAprovar.Enabled = false;
                btnReabrir.Enabled = false;
                btnExcluirLote.Enabled = false;
                btnAdicionarItem.Enabled = false;
                btnEditarItem.Enabled = false;
                btnExcluirItem.Enabled = false;
                btnExportarExcel.Enabled = false;
                btnSalvar.Enabled = false;
                return;
            }

            if (_loteAtual.EstaAberto)
            {
                btnAprovar.Enabled = true;
                btnReabrir.Enabled = false;
                btnExcluirLote.Enabled = true;

                btnAdicionarItem.Enabled = true;
                btnExcluirItem.Enabled = dgvItens.Rows.Count > 0;
                btnExportarExcel.Enabled = dgvItens.Rows.Count > 0;
                btnSalvar.Enabled = true;

                btnEditarItem.Enabled = dgvItens.SelectedRows.Count > 0;
            }
            else if (_loteAtual.EstaAprovado)
            {
                btnAprovar.Enabled = false;
                btnReabrir.Enabled = true;
                btnExcluirLote.Enabled = false;

                btnAdicionarItem.Enabled = false;
                btnEditarItem.Enabled = false;
                btnExcluirItem.Enabled = false;
                btnExportarExcel.Enabled = dgvItens.Rows.Count > 0;
                btnSalvar.Enabled = false;
            }
            else if (_loteAtual.EstaReaberto)
            {
                btnAprovar.Enabled = true;
                btnReabrir.Enabled = false;
                btnExcluirLote.Enabled = false;

                btnAdicionarItem.Enabled = false;
                btnExcluirItem.Enabled = false;
                btnExportarExcel.Enabled = dgvItens.Rows.Count > 0;
                btnSalvar.Enabled = true;

                AtualizarEstadoBotaoEditarItem();
            }
        }
        // ============================================================
        // ATUALIZA O BOTÃO EDITAR ITEM
        // ============================================================
        private void AtualizarEstadoBotaoEditarItem()
        {
            if (_loteAtual == null || dgvItens.SelectedRows.Count == 0)
            {
                btnEditarItem.Enabled = false;
                return;
            }

            if (_loteAtual.EstaAberto)
            {
                btnEditarItem.Enabled = true;
                return;
            }

            if (_loteAtual.EstaAprovado)
            {
                btnEditarItem.Enabled = false;
                return;
            }

            if (_loteAtual.EstaReaberto)
            {
                int idItem = Convert.ToInt32(dgvItens.SelectedRows[0].Cells["colId"].Value);
                var item = _repoItem.BuscarPorId(idItem);

                if (item == null || string.IsNullOrWhiteSpace(item.CodigoProdutoGerado))
                {
                    btnEditarItem.Enabled = false;
                    return;
                }

                var produto = _repoProduto.BuscarPorCodigo(item.CodigoProdutoGerado);

                btnEditarItem.Enabled =
                    produto != null &&
                    produto.StatusDoProduto == "Disponível";
            }
        }

        // ============================================================
        // BOTÃO NOVO LOTE
        // ============================================================
        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (_parceiroAtual == null)
            {
                MessageBox.Show("Nenhum parceiro selecionado.");
                return;
            }

            var novoLote = _repoLote.CriarNovoLote(
                NormalizarCodigo(_parceiroAtual.CodigoParceiro)
            );

            CarregarLote(novoLote.CodigoLoteRecebimento);
        }

        // ============================================================
        // BOTÃO BUSCAR LOTE
        // ============================================================
        private void btnBuscarLote_Click(object sender, EventArgs e)
        {
            string codigo = NormalizarCodigo(txtCodigoLote.Text);

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Informe um código de lote válido.");
                return;
            }

            CarregarLote(codigo);
        }

        // ============================================================
        // BOTÃO LISTAR LOTES
        // ============================================================
        private void btnListarLotes_Click(object sender, EventArgs e)
        {
            if (_parceiroAtual == null)
            {
                MessageBox.Show("Nenhum parceiro selecionado.");
                return;
            }

            using var frm = new FormSelecionarLote(
                NormalizarCodigo(_parceiroAtual.CodigoParceiro)
            );

            if (frm.ShowDialog() == DialogResult.OK && frm.LoteSelecionado != null)
            {
                CarregarLote(frm.LoteSelecionado);
            }
        }

        // ============================================================
        // BOTÃO APROVAR LOTE
        // ============================================================
        private void btnAprovar_Click(object sender, EventArgs e)
        {
            if (_loteAtual == null)
                return;

            if (_loteAtual.EstaAprovado)
            {
                MessageBox.Show("Lote já aprovado.");
                return;
            }

            if (MessageBox.Show("Confirmar aprovação do lote?", "Aprovar",
                MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            Log($"=== INICIANDO APROVAÇÃO DO LOTE: {_loteAtual.CodigoLoteRecebimento} ===");
            Log($"Status do lote: {_loteAtual.StatusLote}");
            Log($"EstaAberto: {_loteAtual.EstaAberto}, EstaReaberto: {_loteAtual.EstaReaberto}");

            var itens = _repoItem.ListarItensPorLote(_loteAtual.CodigoLoteRecebimento);

            if (itens.Count == 0)
            {
                MessageBox.Show("Lote vazio. Adicione itens antes de aprovar.");
                return;
            }

            Log($"Total de itens no lote: {itens.Count}");

            if (_loteAtual.EstaReaberto)
            {
                bool existeItemSemProduto =
                    itens.Exists(i => string.IsNullOrWhiteSpace(i.CodigoProdutoGerado));

                if (existeItemSemProduto)
                {
                    MessageBox.Show("Lote reaberto contém itens sem produto gerado anteriormente.");
                    return;
                }
            }

            int sequencia = 1;

            foreach (var item in itens)
            {
                string codigoProduto;

                if (!string.IsNullOrWhiteSpace(item.CodigoProdutoGerado))
                {
                    codigoProduto = item.CodigoProdutoGerado;
                }
                else
                {
                    codigoProduto = $"{_loteAtual.CodigoLoteRecebimento}-P{sequencia}";
                }

                Log($"--- Processando item ID {item.Id} ---");
                Log($"  Nome: {item.NomeDoItem}");
                Log($"  Código produto: {codigoProduto}");
                Log($"  PrecoSugerido do ItemLote: {item.PrecoSugeridoDoItem:F2}");
                Log($"  PrecoVenda do ItemLote: {item.PrecoVendaDoItem:F2}");

                var produtoExistente = _repoProduto.BuscarPorCodigo(codigoProduto);

                if (_loteAtual.EstaAberto)
                {
                    if (produtoExistente == null)
                    {
                        var novoProduto = new Produto
                        {
                            CodigoProduto = codigoProduto,
                            CodigoLoteRecebimento = _loteAtual.CodigoLoteRecebimento,
                            CodigoParceiro = _loteAtual.CodigoParceiro,

                            NomeDoItem = item.NomeDoItem,
                            MarcaDoItem = item.MarcaDoItem,
                            CategoriaDoItem = item.CategoriaDoItem,
                            TamanhoCorDoItem = item.TamanhoCorDoItem,
                            ObservacaoDoItem = item.ObservacaoDoItem,
                            PrecoSugeridoDoItem = item.PrecoSugeridoDoItem,
                            PrecoVendaDoItem = item.PrecoVendaDoItem,

                            StatusDoProduto = "Disponível",
                            DataCriacao = DateTime.Now,
                            UltimaAtualizacao = DateTime.Now
                        };

                        Log($"  Ação: CRIAR novo produto");
                        Log($"  PrecoSugerido para criar: {novoProduto.PrecoSugeridoDoItem:F2}");
                        Log($"  PrecoVenda para criar: {novoProduto.PrecoVendaDoItem:F2}");

                        _repoProduto.CriarProduto(novoProduto);

                        item.CodigoProdutoGerado = codigoProduto;
                        item.UltimaAtualizacao = DateTime.Now;
                        _repoItem.AtualizarItem(item);

                        Log($"  Produto criado com sucesso");
                    }
                    else
                    {
                        if (produtoExistente.StatusDoProduto == "Disponível")
                        {
                            Log($"  Produto já existe - Status: {produtoExistente.StatusDoProduto}");
                            Log($"  PrecoSugerido ANTES da atualização: {produtoExistente.PrecoSugeridoDoItem:F2}");
                            Log($"  PrecoVenda ANTES da atualização: {produtoExistente.PrecoVendaDoItem:F2}");

                            produtoExistente.NomeDoItem = item.NomeDoItem;
                            produtoExistente.MarcaDoItem = item.MarcaDoItem;
                            produtoExistente.CategoriaDoItem = item.CategoriaDoItem;
                            produtoExistente.TamanhoCorDoItem = item.TamanhoCorDoItem;
                            produtoExistente.ObservacaoDoItem = item.ObservacaoDoItem;
                            produtoExistente.PrecoSugeridoDoItem = item.PrecoSugeridoDoItem;
                            produtoExistente.PrecoVendaDoItem = item.PrecoVendaDoItem;
                            produtoExistente.UltimaAtualizacao = DateTime.Now;

                            Log($"  Ação: ATUALIZAR produto existente (lote aberto)");
                            Log($"  PrecoSugerido para atualizar: {produtoExistente.PrecoSugeridoDoItem:F2}");
                            Log($"  PrecoVenda para atualizar: {produtoExistente.PrecoVendaDoItem:F2}");

                            _repoProduto.AtualizarProduto(produtoExistente);

                            item.CodigoProdutoGerado = codigoProduto;
                            item.UltimaAtualizacao = DateTime.Now;
                            _repoItem.AtualizarItem(item);

                            Log($"  Produto atualizado com sucesso");

                            // Validação: buscar o produto novamente para confirmar a atualização
                            var produtoValidacao = _repoProduto.BuscarPorCodigo(codigoProduto);
                            Log($"  VALIDAÇÃO - PrecoSugerido após UPDATE: {produtoValidacao.PrecoSugeridoDoItem:F2}");
                            Log($"  VALIDAÇÃO - PrecoVenda após UPDATE: {produtoValidacao.PrecoVendaDoItem:F2}");

                            if (Math.Abs(produtoValidacao.PrecoSugeridoDoItem - item.PrecoSugeridoDoItem) > 0.01 ||
                                Math.Abs(produtoValidacao.PrecoVendaDoItem - item.PrecoVendaDoItem) > 0.01)
                            {
                                Log($"  ALERTA: Valores não foram atualizados corretamente!");
                            }
                        }
                        else
                        {
                            Log($"  IGNORADO: Produto não está Disponível (Status: {produtoExistente.StatusDoProduto})");
                        }
                    }
                }
                else if (_loteAtual.EstaReaberto)
                {
                    if (produtoExistente == null)
                    {
                        Log($"  ERRO: Produto deveria existir mas não foi encontrado");
                        sequencia++;
                        continue;
                    }

                    if (produtoExistente.StatusDoProduto == "Disponível")
                    {
                        Log($"  Produto existe - Status: {produtoExistente.StatusDoProduto}");
                        Log($"  PrecoSugerido ANTES da atualização: {produtoExistente.PrecoSugeridoDoItem:F2}");
                        Log($"  PrecoVenda ANTES da atualização: {produtoExistente.PrecoVendaDoItem:F2}");

                        produtoExistente.NomeDoItem = item.NomeDoItem;
                        produtoExistente.MarcaDoItem = item.MarcaDoItem;
                        produtoExistente.CategoriaDoItem = item.CategoriaDoItem;
                        produtoExistente.TamanhoCorDoItem = item.TamanhoCorDoItem;
                        produtoExistente.ObservacaoDoItem = item.ObservacaoDoItem;
                        produtoExistente.PrecoSugeridoDoItem = item.PrecoSugeridoDoItem;
                        produtoExistente.PrecoVendaDoItem = item.PrecoVendaDoItem;
                        produtoExistente.UltimaAtualizacao = DateTime.Now;

                        Log($"  Ação: ATUALIZAR produto (lote reaberto)");
                        Log($"  PrecoSugerido para atualizar: {produtoExistente.PrecoSugeridoDoItem:F2}");
                        Log($"  PrecoVenda para atualizar: {produtoExistente.PrecoVendaDoItem:F2}");

                        _repoProduto.AtualizarProduto(produtoExistente);

                        item.UltimaAtualizacao = DateTime.Now;
                        _repoItem.AtualizarItem(item);

                        Log($"  Produto atualizado com sucesso");

                        // Validação: buscar o produto novamente para confirmar a atualização
                        var produtoValidacao = _repoProduto.BuscarPorCodigo(codigoProduto);
                        Log($"  VALIDAÇÃO - PrecoSugerido após UPDATE: {produtoValidacao.PrecoSugeridoDoItem:F2}");
                        Log($"  VALIDAÇÃO - PrecoVenda após UPDATE: {produtoValidacao.PrecoVendaDoItem:F2}");

                        if (Math.Abs(produtoValidacao.PrecoSugeridoDoItem - item.PrecoSugeridoDoItem) > 0.01 ||
                            Math.Abs(produtoValidacao.PrecoVendaDoItem - item.PrecoVendaDoItem) > 0.01)
                        {
                            Log($"  ALERTA: Valores não foram atualizados corretamente!");
                            MessageBox.Show($"ATENÇÃO: Os preços do produto {codigoProduto} não foram atualizados corretamente.\n\n" +
                                          $"Esperado:\n" +
                                          $"  PrecoSugerido: {item.PrecoSugeridoDoItem:F2}\n" +
                                          $"  PrecoVenda: {item.PrecoVendaDoItem:F2}\n\n" +
                                          $"Obtido:\n" +
                                          $"  PrecoSugerido: {produtoValidacao.PrecoSugeridoDoItem:F2}\n" +
                                          $"  PrecoVenda: {produtoValidacao.PrecoVendaDoItem:F2}\n\n" +
                                          $"Verifique os logs em {Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs")}",
                                          "Alerta de Atualização",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        Log($"  IGNORADO: Produto não está Disponível (Status: {produtoExistente.StatusDoProduto})");
                    }
                }

                sequencia++;
            }

            _repoLote.AprovarLote(_loteAtual.CodigoLoteRecebimento);

            Log($"=== APROVAÇÃO CONCLUÍDA: {_loteAtual.CodigoLoteRecebimento} ===");

            MessageBox.Show("Lote aprovado com sucesso.");
            CarregarLote(_loteAtual.CodigoLoteRecebimento);
        }

        // ============================================================
        // BOTÃO REABRIR LOTE
        // ============================================================
        private void btnReabrir_Click(object sender, EventArgs e)
        {
            if (_loteAtual == null)
                return;

            if (!_loteAtual.PodeReabrir)
            {
                MessageBox.Show("Somente lotes aprovados podem ser reabertos.");
                return;
            }

            if (MessageBox.Show("Reabrir lote para ajustes?", "Reabrir",
                MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            _repoLote.ReabrirLote(_loteAtual.CodigoLoteRecebimento);

            MessageBox.Show("Lote reaberto com sucesso.");
            CarregarLote(_loteAtual.CodigoLoteRecebimento);
        }

        // ============================================================
        // BOTÃO EXCLUIR LOTE
        // ============================================================
        private void btnExcluirLote_Click(object sender, EventArgs e)
        {
            if (_loteAtual == null)
            {
                MessageBox.Show("Nenhum lote carregado.");
                return;
            }

            if (!_loteAtual.EstaAberto)
            {
                MessageBox.Show("Somente lotes em aberto podem ser excluídos.");
                return;
            }

            if (MessageBox.Show("Excluir este lote? Esta ação não pode ser desfeita.",
                                "Excluir", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            _repoLote.ExcluirLote(_loteAtual.CodigoLoteRecebimento);

            MessageBox.Show("Lote excluído com sucesso.");
            LimparCamposLote();
        }
        // ============================================================
        // BOTÃO ADICIONAR ITEM
        // ============================================================
        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            if (_loteAtual == null)
            {
                MessageBox.Show("Nenhum lote carregado.");
                return;
            }

            if (!_loteAtual.EstaAberto)
            {
                MessageBox.Show("Somente lotes em aberto permitem adicionar itens.");
                return;
            }

            using var frm = new FormItemLote(
                NormalizarCodigo(_loteAtual.CodigoLoteRecebimento),
                NormalizarCodigo(_loteAtual.CodigoParceiro),
                _loteAtual.StatusLote
            );

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CarregarItens();
                AtualizarTotais();
                AtualizarBotoes();
            }
        }

        // ============================================================
        // BOTÃO EDITAR ITEM
        // ============================================================
        private void btnEditarItem_Click(object sender, EventArgs e)
        {
            if (_loteAtual == null)
                return;

            if (dgvItens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item.");
                return;
            }

            int idItem = Convert.ToInt32(dgvItens.SelectedRows[0].Cells["colId"].Value);
            var item = _repoItem.BuscarPorId(idItem);

            if (item == null)
            {
                MessageBox.Show("Item não encontrado.");
                return;
            }

            if (_loteAtual.EstaAprovado)
            {
                MessageBox.Show("Itens não podem ser editados em lotes aprovados.");
                return;
            }

            if (_loteAtual.EstaReaberto)
            {
                if (string.IsNullOrWhiteSpace(item.CodigoProdutoGerado))
                {
                    MessageBox.Show("Este item não possui produto vinculado.");
                    return;
                }

                var produto = _repoProduto.BuscarPorCodigo(item.CodigoProdutoGerado);

                if (produto == null)
                {
                    MessageBox.Show("Produto vinculado não encontrado.");
                    return;
                }

                if (produto.StatusDoProduto != "Disponível")
                {
                    MessageBox.Show("Este item não pode ser editado porque o produto não está Disponível.");
                    return;
                }
            }

            using var frm = new FormItemLote(
                NormalizarCodigo(_loteAtual.CodigoLoteRecebimento),
                NormalizarCodigo(_loteAtual.CodigoParceiro),
                _loteAtual.StatusLote,
                item
            );

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CarregarItens();
                AtualizarTotais();
                AtualizarBotoes();
            }
        }

        // ============================================================
        // BOTÃO EXCLUIR ITEM
        // ============================================================
        private void btnExcluirItem_Click(object sender, EventArgs e)
        {
            if (_loteAtual == null)
                return;

            if (!_loteAtual.EstaAberto)
            {
                MessageBox.Show("Somente lotes em aberto permitem excluir itens.");
                return;
            }

            if (dgvItens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item.");
                return;
            }

            int idItem = Convert.ToInt32(dgvItens.SelectedRows[0].Cells["colId"].Value);

            if (MessageBox.Show("Excluir este item?", "Excluir", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            _repoItem.ExcluirItem(idItem);

            CarregarItens();
            AtualizarTotais();
            AtualizarBotoes();
        }

        // ============================================================
        // EVENTO: SELEÇÃO DE LINHA NO GRID
        // ============================================================
        private void dgvItens_SelectionChanged(object sender, EventArgs e)
        {
            AtualizarEstadoBotaoEditarItem();
        }

        // ============================================================
        // EVENTO: DUPLO CLIQUE NO GRID
        // ============================================================
        private void dgvItens_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            btnEditarItem.PerformClick();
        }

        // ============================================================
        // SALVAR OBSERVAÇÕES AO SAIR DO CAMPO
        // ============================================================
        private void txtObservacoes_Leave(object sender, EventArgs e)
        {
            if (_loteAtual == null)
                return;

            if (_loteAtual.EstaAprovado)
                return;

            _loteAtual.Observacoes = txtObservacoes.Text;
            _loteAtual.UltimaAtualizacao = DateTime.Now;

            _repoLote.AtualizarObservacoes(_loteAtual);
        }

        // ============================================================
        // EXPORTAR ITENS PARA EXCEL
        // ============================================================
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (_loteAtual == null)
            {
                MessageBox.Show("Nenhum lote carregado.");
                return;
            }

            var itens = _repoItem.ListarItensPorLote(_loteAtual.CodigoLoteRecebimento);

            if (itens == null || itens.Count == 0)
            {
                MessageBox.Show("Não há itens para exportar.");
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "Arquivo Excel (*.xlsx)|*.xlsx",
                FileName = $"Lote_{_loteAtual.CodigoLoteRecebimento}.xlsx"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                // Buscar o nome do parceiro do banco
                var parceiro = _repoParceiro.BuscarPorCodigo(_loteAtual.CodigoParceiro);
                string nomeParceiro = parceiro?.Nome ?? "Parceiro não encontrado";

                var workbook = new XLWorkbook();
                var ws = workbook.Worksheets.Add("Itens do Lote");

                // Linha 1: Código do Lote e Parceiro de Negócio
                ws.Cell(1, 1).Value = "Código do Lote:";
                ws.Cell(1, 1).Style.Font.Bold = true;
                ws.Cell(1, 2).Value = _loteAtual.CodigoLoteRecebimento;
                ws.Cell(1, 4).Value = "Parceiro de Negócio:";
                ws.Cell(1, 4).Style.Font.Bold = true;
                ws.Cell(1, 5).Value = nomeParceiro;

                // Linha 2: Status do Lote
                ws.Cell(2, 1).Value = "Status do Lote:";
                ws.Cell(2, 1).Style.Font.Bold = true;
                ws.Cell(2, 2).Value = _loteAtual.StatusLote;

                // Linha 3: Vazia (separação)

                // Linha 4: Cabeçalhos das colunas
                ws.Cell(4, 1).Value = "ID";
                ws.Cell(4, 2).Value = "Nome";
                ws.Cell(4, 3).Value = "Marca";
                ws.Cell(4, 4).Value = "Categoria";
                ws.Cell(4, 5).Value = "Preço Sugerido";
                ws.Cell(4, 6).Value = "Preço Venda";
                ws.Cell(4, 7).Value = "Status";
                ws.Cell(4, 8).Value = "Observação";

                ws.Range("A4:H4").Style.Font.Bold = true;

                int row = 5;
                foreach (var item in itens)
                {
                    ws.Cell(row, 1).Value = item.Id;
                    ws.Cell(row, 2).Value = item.NomeDoItem;
                    ws.Cell(row, 3).Value = item.MarcaDoItem;
                    ws.Cell(row, 4).Value = item.CategoriaDoItem;
                    ws.Cell(row, 5).Value = item.PrecoSugeridoDoItem;
                    ws.Cell(row, 6).Value = item.PrecoVendaDoItem;
                    ws.Cell(row, 7).Value = item.StatusItem;
                    ws.Cell(row, 8).Value = item.ObservacaoDoItem;

                    row++;
                }

                ws.Columns().AdjustToContents();
                workbook.SaveAs(sfd.FileName);

                MessageBox.Show("Arquivo Excel exportado com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exportar: " + ex.Message);
            }
        }

        // ============================================================
        // BOTÃO FECHAR
        // ============================================================
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ============================================================
        // BOTÃO SALVAR (OBSERVAÇÕES E REFRESH)
        // ============================================================
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (_loteAtual == null)
            {
                MessageBox.Show("Nenhum lote carregado.");
                return;
            }

            if (_loteAtual.EstaAprovado)
            {
                MessageBox.Show("Lotes aprovados não podem ser alterados.");
                return;
            }

            _loteAtual.Observacoes = txtObservacoes.Text;
            _loteAtual.UltimaAtualizacao = DateTime.Now;
            _repoLote.AtualizarObservacoes(_loteAtual);

            CarregarItens();
            AtualizarTotais();
            AtualizarBotoes();

            MessageBox.Show("Dados do lote salvos com sucesso.");
        }
    }
}
