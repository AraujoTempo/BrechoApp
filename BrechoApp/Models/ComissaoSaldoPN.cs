namespace BrechoApp.Models
{
    public class ComissaoSaldoPN
    {
        public int IdSaldo { get; set; }
        public int IdPeriodo { get; set; }
        public string CodigoPN { get; set; }

        public double ComissoesAPagar { get; set; }
        public double ContasAReceber { get; set; }

        public double SaldoFinal { get; set; }
        public double SaldoCompensado { get; set; }

        public string Status { get; set; }
    }
}