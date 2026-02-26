namespace BrechoApp.Models
{
    /// <summary>
    /// Representa uma linha de pagamento associada a uma venda.
    /// Uma venda pode ter um ou mais pagamentos (modo Combinado).
    /// </summary>
    public class VendaPagamento
    {
        public int IdVendaPagamento { get; set; }

        public int IdVenda { get; set; }

        /// <summary>
        /// Forma de pagamento: Dinheiro, PIX, Débito, Crédito,
        /// Transferencia cc Brecho, Transferencia cc Socio1,
        /// Transferencia cc Socio2, Futuro
        /// </summary>
        public string FormaPagamento { get; set; } = string.Empty;

        public decimal Valor { get; set; }

        /// <summary>
        /// Id do centro financeiro correspondente à forma de pagamento.
        /// </summary>
        public int? IdCentroFinanceiro { get; set; }
    }
}
