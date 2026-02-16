using System;
using BrechoApp.Enums;

namespace BrechoApp.Models
{
    /// <summary>
    /// Representa um Parceiro de Negócio (PN).
    /// 
    /// Este modelo substitui completamente o antigo "Fornecedor".
    /// 
    /// Um PN pode atuar como:
    /// - Fornecedor (compra de produtos)
    /// - Cliente (venda de produtos)
    /// - Parceiro de Marketing
    /// - Ou qualquer outro papel futuro
    /// 
    /// O código segue o padrão:
    ///     PN1, PN2, PN3...
    /// 
    /// </summary>
    public class ParceiroNegocio
    {
        // ============================================================
        // IDENTIFICAÇÃO
        // ============================================================

        /// <summary>
        /// Código único do Parceiro de Negócio.
        /// Exemplo: PN1, PN2, PN3...
        /// </summary>
        public string CodigoParceiro { get; set; } = string.Empty;

        /// <summary>
        /// Nome completo do parceiro.
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de parceiro de negócio.
        /// Define o papel do parceiro (Socio, Vendedor, Fornecedor, Cliente, Outro).
        /// Valor padrão: Outro
        /// </summary>
        public TipoParceiro TipoParceiro { get; set; } = TipoParceiro.Outro;

        /// <summary>
        /// CPF ou CNPJ do parceiro (opcional).
        /// Aceita CPF (11 dígitos) ou CNPJ (14 dígitos).
        /// Pode ser formatado ou não.
        /// </summary>
        public string CPF { get; set; } = string.Empty;

        /// <summary>
        /// Apelido ou nome social.
        /// </summary>
        public string Apelido { get; set; } = string.Empty;


        // ============================================================
        // CONTATO
        // ============================================================

        public string Telefone { get; set; } = string.Empty;
        public string? Endereco { get; set; }
        public string? Email { get; set; }


        // ============================================================
        // DADOS BANCÁRIOS
        // ============================================================

        public string? Banco { get; set; }
        public string? Agencia { get; set; }
        public string? Conta { get; set; }
        public string? Pix { get; set; }


        // ============================================================
        // CONFIGURAÇÕES DO PARCEIRO
        // ============================================================

        /// <summary>
        /// Percentual de comissão aplicado em vendas.
        /// </summary>
        public double PercentualComissao { get; set; }

        /// <summary>
        /// Indica se o parceiro autoriza doação de itens não vendidos.
        /// </summary>
        public bool AutorizaDoacao { get; set; }


        // ============================================================
        // OBSERVAÇÕES E DADOS COMPLEMENTARES
        // ============================================================

        public string? Observacao { get; set; }

        /// <summary>
        /// Data de aniversário (string yyyy-MM-dd).
        /// </summary>
        public string? Aniversario { get; set; }


        // ============================================================
        // FINANCEIRO
        // ============================================================

        /// <summary>
        /// Saldo de crédito acumulado do parceiro.
        /// </summary>
        public double SaldoCredito { get; set; }


        // ============================================================
        // AUDITORIA
        // ============================================================

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime UltimaAtualizacao { get; set; } = DateTime.Now;
    }
}
