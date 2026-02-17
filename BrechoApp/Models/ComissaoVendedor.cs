using System;

namespace BrechoApp.Models
{
    /// <summary>
    /// Representa uma comissão cadastrada para um vendedor.
    /// Um vendedor (Parceiro de Negócio do tipo "Vendedor") pode ter apenas uma comissão cadastrada.
    /// </summary>
    public class ComissaoVendedor
    {
        /// <summary>
        /// Identificador único da comissão (auto incremento).
        /// </summary>
        public int IdComissao { get; set; }

        /// <summary>
        /// Código do Parceiro de Negócio (FK para ParceirosNegocio.CodigoParceiro).
        /// Deve ser um PN do tipo "Vendedor".
        /// </summary>
        public string CodigoPN { get; set; } = string.Empty;

        /// <summary>
        /// Nome do Parceiro de Negócio (para exibição).
        /// Campo desnormalizado para facilitar a exibição.
        /// </summary>
        public string NomeVendedor { get; set; } = string.Empty;

        /// <summary>
        /// Percentual de comissão (0 a 100).
        /// Exemplos: 5.0, 7.5, 10.0
        /// </summary>
        public decimal PercentualComissao { get; set; }

        /// <summary>
        /// Data em que a comissão foi cadastrada.
        /// </summary>
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Data da última alteração da comissão (nullable).
        /// </summary>
        public DateTime? DataUltimaAlteracao { get; set; }
    }
}
