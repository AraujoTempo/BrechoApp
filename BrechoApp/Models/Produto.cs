using System;

namespace BrechoApp.Models
{
    /// <summary>
    /// Representa um produto gerado a partir de um item de lote.
    /// 
    /// O código do produto segue o padrão:
    ///     PNx-Ly-Pz
    /// Exemplo:
    ///     PN1-L3-P2
    /// 
    /// Onde:
    /// - PNx  = Código do Parceiro de Negócio
    /// - Ly   = Número sequencial do lote do parceiro
    /// - Pz   = Número sequencial do item dentro do lote
    /// </summary>
    public class Produto
    {
        // ============================================================
        // IDENTIFICAÇÃO
        // ============================================================

        /// <summary>
        /// Código único do produto (PNx-Ly-Pz).
        /// </summary>
        public string CodigoProduto { get; set; } = string.Empty;

        /// <summary>
        /// Código do Parceiro de Negócio (PNx).
        /// Substitui completamente o antigo CodigoFornecedor.
        /// </summary>
        public string CodigoParceiro { get; set; } = string.Empty;

        /// <summary>
        /// Código do lote ao qual o produto pertence (PNx-Ly).
        /// </summary>
        public string CodigoLoteRecebimento { get; set; } = string.Empty;


        // ============================================================
        // DADOS DO ITEM (herdados do ItemLote)
        // ============================================================

        public string NomeDoItem { get; set; } = string.Empty;
        public string MarcaDoItem { get; set; } = string.Empty;
        public string CategoriaDoItem { get; set; } = string.Empty;
        public string TamanhoCorDoItem { get; set; } = string.Empty;

        /// <summary>
        /// Observação opcional do item.
        /// </summary>
        public string? ObservacaoDoItem { get; set; }


        // ============================================================
        // PREÇO E STATUS
        // ============================================================

        /// <summary>
        /// Preço sugerido inicialmente para o item.
        /// </summary>
        public double PrecoSugeridoDoItem { get; set; }

        /// <summary>
        /// Preço final aprovado para venda.
        /// </summary>
        public double PrecoVendaDoItem { get; set; }

        /// <summary>
        /// Status atual do produto.
        /// Ex.: "Disponível", "Vendido", "Perdido", "Doado", "Devolvido"
        /// </summary>
        public string StatusDoProduto { get; set; } = "Disponível";


        // ============================================================
        // AUDITORIA
        // ============================================================

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime UltimaAtualizacao { get; set; } = DateTime.Now;
    }
}
