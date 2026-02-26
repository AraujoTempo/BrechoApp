namespace BrechoApp.Models
{
    public class CentroFinanceiro
    {
        public int IdCentroFinanceiro { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; } // Caixa, Banco, CartaoAReceber, CartaoLoja, Pix, Outro
        public decimal SaldoAtual { get; set; }
        public decimal SaldoPrevisto { get; set; }
        public bool Ativo { get; set; }
    }
}
