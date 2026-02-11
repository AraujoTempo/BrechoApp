namespace BrechoApp.Models
{
    public class Financeiro
    {
        public string CodigoFinanceiro { get; set; }
        public string CodigoFornecedor { get; set; }
        public string TipoLancamento { get; set; }   // Crédito ou Débito
        public double Valor { get; set; }
        public string DataLancamento { get; set; }
        public string Descricao { get; set; }
    }
}
