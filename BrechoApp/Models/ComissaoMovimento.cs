namespace BrechoApp.Models
{
    public class ComissaoMovimento
    {
        public int IdMovimento { get; set; }
        public int IdSaldo { get; set; }

        public string Tipo { get; set; }  // PagamentoPN ou RecebimentoPN
        public double Valor { get; set; }
        public string FormaPagamento { get; set; }

        public string DataMovimento { get; set; }
        public string Observacao { get; set; }
    }
}
