using System;
using System.Collections.Generic;

namespace BrechoApp.Models
{
    /// <summary>
    /// Representa uma venda realizada no sistema.
    /// </summary>
    public class Venda
    {

        // ============================================================
        // IDENTIFICAÇÃO
        // ============================================================

        public int IdVenda { get; set; }
        public string CodigoVenda { get; set; } = string.Empty;
        public string IdVendedor { get; set; } = string.Empty;
        public string IdCliente { get; set; } = string.Empty;
        public DateTime DataVenda { get; set; } = DateTime.Now;

        // ============================================================
        // VALORES
        // ============================================================

        public double ValorTotalOriginal { get; set; }
        public double DescontoPercentual { get; set; }
        public double DescontoValor { get; set; }
        public string? Campanha { get; set; }
        public double DescontoCampanhaPercentual { get; set; }
        public double DescontoCampanha { get; set; }

        /// <summary>
        /// Valor total final após descontos.
        /// </summary>
        public double ValorTotalFinal { get; set; }

        // ============================================================
        // PAGAMENTOS E OBSERVAÇÕES
        // ============================================================

        /// <summary>
        /// Lista de pagamentos utilizados na venda.
        /// Substitui a antiga propriedade FormaPagamento (string).
        /// </summary>
        public List<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();

        public string? Observacoes { get; set; }

        // ============================================================
        // AUDITORIA
        // ============================================================

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        // ============================================================
        // ITENS DA VENDA
        // ============================================================

        public List<VendaItem> Itens { get; set; } = new List<VendaItem>();
    }
}
