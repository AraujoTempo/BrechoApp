using System;

namespace BrechoApp.Models
{
    /// <summary>
    /// Representa um item dentro de um lote de recebimento.
    /// Cada item pode gerar um produto após aprovação.
    /// </summary>
    public class ItemLote
    {
        public int Id { get; set; }

        /// <summary>
        /// Código do lote ao qual o item pertence (PNx-Ly).
        /// </summary>
        public string CodigoLoteRecebimento { get; set; } = string.Empty;

        /// <summary>
        /// Código do Parceiro de Negócio (PNx).
        /// Adicionado para rastreabilidade direta.
        /// </summary>
        public string CodigoParceiro { get; set; } = string.Empty;

        // ============================================================
        // DADOS DO ITEM
        // ============================================================

        public string NomeDoItem { get; set; } = string.Empty;
        public string MarcaDoItem { get; set; } = string.Empty;
        public string CategoriaDoItem { get; set; } = string.Empty;
        public string TamanhoCorDoItem { get; set; } = string.Empty;

        /// <summary>
        /// Observação nunca deve ser null no uso interno.
        /// </summary>
        public string ObservacaoDoItem { get; set; } = "";

        // ============================================================
        // PREÇOS DEFINIDOS PELO BRECHÓ
        // ============================================================

        public double PrecoSugeridoDoItem { get; set; }
        public double PrecoVendaDoItem { get; set; }

        // ============================================================
        // STATUS E PRODUTO GERADO
        // ============================================================

        /// <summary>
        /// Status do item dentro do lote.
        /// Ex.: "Em análise", "Aprovado", "Rejeitado"
        /// </summary>
        public string StatusItem { get; set; } = "Em análise";

        /// <summary>
        /// Código do produto gerado após aprovação.
        /// Ex.: PN1-L3-P2
        /// </summary>
        public string? CodigoProdutoGerado { get; set; }

        // ============================================================
        // AUDITORIA
        // ============================================================

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime UltimaAtualizacao { get; set; } = DateTime.Now;
    }
}
