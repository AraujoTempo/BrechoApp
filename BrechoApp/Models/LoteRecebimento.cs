using System;
using System.Collections.Generic;

namespace BrechoApp.Models
{
    public class LoteRecebimento
    {
        // Código completo do lote (ex.: PN12-L3)
        public string CodigoLoteRecebimento { get; set; }

        // Novo campo oficial — substitui CodigoFornecedor
        public string CodigoParceiro { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime? DataRecebimento { get; set; }
        public DateTime? DataAprovacao { get; set; }

        // Status possíveis: Aberto, Aprovado, Reaberto, Cancelado
        public string StatusLote { get; set; }

        // Nunca deve ser null
        public string Observacoes { get; set; } = "";

        public DateTime UltimaAtualizacao { get; set; }

        // Lista de itens (não é campo do banco)
        public List<ItemLote> Itens { get; set; } = new List<ItemLote>();

        // ============================
        //  Propriedades auxiliares
        // ============================
        public bool EstaAberto => StatusLote == "Aberto";
        public bool EstaAprovado => StatusLote == "Aprovado";
        public bool EstaReaberto => StatusLote == "Reaberto";
        public bool EstaCancelado => StatusLote == "Cancelado";

        // ============================
        //  Regras de negócio
        // ============================
        public bool PodeReabrir => StatusLote == "Aprovado";
    }
}


