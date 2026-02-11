namespace BrechoApp.Models
{
    public class Vendedor
    {
        public string CodigoVendedor { get; set; } = "";
        public string Nome { get; set; } = "";
        public string CPF { get; set; } = "";
        public string Telefone { get; set; } = "";
        public string Email { get; set; } = "";
        public string Endereco { get; set; } = "";

        // Dados bancários
        public string Banco { get; set; } = "";
        public string Agencia { get; set; } = "";
        public string Conta { get; set; } = "";

        // Novos campos
        public decimal ComissaoVendedor { get; set; } = 0;
        public string Observacao { get; set; } = "";

        public bool Ativo { get; set; } = true;
    }
}