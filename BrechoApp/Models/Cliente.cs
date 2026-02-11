namespace BrechoApp.Models
{
    public class Cliente
    {
        public string CodigoCliente { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Observacao { get; set; }
        public string Aniversario { get; set; }
        // Sem SaldoCredito aqui
    }
}
