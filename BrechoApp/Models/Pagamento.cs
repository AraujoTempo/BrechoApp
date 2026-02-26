using BrechoApp.Enums;

namespace BrechoApp.Models
{
    public class Pagamento
    {
        public TipoPagamento Tipo { get; set; }
        public double Valor { get; set; }
    }
}