using System;
using System.Collections.Generic;

namespace BrechoApp.Models
{
    /// <summary>
    /// Representa uma venda realizada no sistema.
    /// 
    /// O código da venda segue o padrão:
    ///     V-1, V-2, V-3...
    /// 
    /// Cada venda contém informações do vendedor, cliente, itens vendidos,
    /// descontos aplicados e forma de pagamento.
    /// </summary>
    public class Venda
    {
        // ============================================================
        // IDENTIFICAÇÃO
        // ============================================================

        /// <summary>
        /// ID interno da venda (autoincremento).
        /// </summary>
        public int IdVenda { get; set; }

        /// <summary>
        /// Código único da venda (V-1, V-2, V-3...).
        /// </summary>
        public string CodigoVenda { get; set; } = string.Empty;

        /// <summary>
        /// Código do vendedor (Parceiro de Negócio).
        /// Deve ser um PN com TipoParceiro = Socio ou Vendedor.
        /// </summary>
        public string IdVendedor { get; set; } = string.Empty;

        /// <summary>
        /// Código do cliente (Parceiro de Negócio).
        /// Pode ser qualquer tipo de PN.
        /// </summary>
        public string IdCliente { get; set; } = string.Empty;

        /// <summary>
        /// Data e hora da venda.
        /// </summary>
        public DateTime DataVenda { get; set; } = DateTime.Now;

        // ============================================================
        // VALORES
        // ============================================================

        /// <summary>
        /// Valor total original (soma dos preços originais dos produtos).
        /// </summary>
        public double ValorTotalOriginal { get; set; }

        /// <summary>
        /// Desconto aplicado em percentual (0 a 100).
        /// </summary>
        public double DescontoPercentual { get; set; }

        /// <summary>
        /// Desconto aplicado em valor monetário.
        /// </summary>
        public double DescontoValor { get; set; }

        /// <summary>
        /// Valor total final após desconto.
        /// </summary>
        public double ValorTotalFinal { get; set; }

        // ============================================================
        // PAGAMENTO E OBSERVAÇÕES
        // ============================================================

        /// <summary>
        /// Forma de pagamento utilizada.
        /// Ex: Dinheiro, PIX, Débito, Crédito, Transferência, Outros
        /// </summary>
        public string FormaPagamento { get; set; } = string.Empty;

        /// <summary>
        /// Observações opcionais sobre a venda.
        /// </summary>
        public string? Observacoes { get; set; }

        // ============================================================
        // AUDITORIA
        // ============================================================

        /// <summary>
        /// Data de criação do registro.
        /// </summary>
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        // ============================================================
        // ITENS DA VENDA
        // ============================================================

        /// <summary>
        /// Lista de itens incluídos na venda.
        /// Não é persistida diretamente, mas carregada da tabela VendasItens.
        /// </summary>
        public List<VendaItem> Itens { get; set; } = new List<VendaItem>();
    }
}
