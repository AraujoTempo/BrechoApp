namespace BrechoApp.Models
{
    public class MovimentacaoFinanceira
    {
        public int IdMovimentacao { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; } // Entrada, Saida, Transferencia
        public decimal Valor { get; set; }

        public int? IdCentroOrigem { get; set; }   // usado em Saída e Transferência
        public int? IdCentroDestino { get; set; }  // usado em Entrada e Transferência

        public string Categoria { get; set; }      // Venda, Comissão, Despesa, Transferência...
        public string Descricao { get; set; }

        public int? IdVenda { get; set; }          // opcional
        public string IdParceiro { get; set; }     // opcional

        public bool Previsto { get; set; }         // se é futuro (ex: cartão a receber)
    }
}
