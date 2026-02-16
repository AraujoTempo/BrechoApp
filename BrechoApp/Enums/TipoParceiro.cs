namespace BrechoApp.Enums
{
    /// <summary>
    /// Define os tipos possíveis de parceiros de negócio.
    /// </summary>
    public enum TipoParceiro
    {
        /// <summary>
        /// Sócio do negócio
        /// </summary>
        Socio,

        /// <summary>
        /// Vendedor
        /// </summary>
        Vendedor,

        /// <summary>
        /// Fornecedor de produtos
        /// </summary>
        FornecedorProduto,

        /// <summary>
        /// Cliente apenas (não fornece produtos)
        /// </summary>
        ClienteApenas,

        /// <summary>
        /// Outro tipo de parceiro (padrão)
        /// </summary>
        Outro
    }
}
