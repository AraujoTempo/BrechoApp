namespace BrechoApp.Models
{
    /// <summary>
    /// Representa um item individual de uma venda.
    /// 
    /// Cada item contém informações do produto vendido, o fornecedor
    /// (necessário para cálculo de comissões), preço original e
    /// preço final negociado após desconto.
    /// </summary>
    public class VendaItem
    {
        // ============================================================
        // IDENTIFICAÇÃO
        // ============================================================

        /// <summary>
        /// ID interno do item da venda (autoincremento).
        /// </summary>
        public int IdVendaItem { get; set; }

        /// <summary>
        /// ID da venda à qual este item pertence.
        /// </summary>
        public int IdVenda { get; set; }

        /// <summary>
        /// Código do produto vendido.
        /// </summary>
        public string IdProduto { get; set; } = string.Empty;

        /// <summary>
        /// Código do fornecedor (Parceiro de Negócio) do produto.
        /// Necessário para cálculo de comissões.
        /// </summary>
        public string IdFornecedor { get; set; } = string.Empty;

        // ============================================================
        // PREÇOS
        // ============================================================

        /// <summary>
        /// Preço original do produto (antes de qualquer desconto).
        /// </summary>
        public double PrecoOriginal { get; set; }

        /// <summary>
        /// Preço final negociado (após rateio proporcional de desconto).
        /// </summary>
        public double PrecoFinalNegociado { get; set; }

        // ============================================================
        // PROPRIEDADES AUXILIARES (não persistidas)
        // ============================================================

        /// <summary>
        /// Nome do produto (para exibição no grid).
        /// </summary>
        public string NomeProduto { get; set; } = string.Empty;

        /// <summary>
        /// Marca do produto (para exibição no grid).
        /// </summary>
        public string MarcaProduto { get; set; } = string.Empty;

        /// <summary>
        /// Categoria do produto (para exibição no grid).
        /// </summary>
        public string CategoriaProduto { get; set; } = string.Empty;
    }
}
