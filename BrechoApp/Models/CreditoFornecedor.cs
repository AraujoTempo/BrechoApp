namespace BrechoApp.Models
{
    public class CreditoFornecedor
    {
        public string CodigoCredito { get; set; }
        public string CodigoFornecedor { get; set; }
        public double ValorCredito { get; set; }
        public string DataCredito { get; set; }
        public string OrigemCredito { get; set; }   // Ex.: Venda, Estorno, Ajuste Manual
    }
}
