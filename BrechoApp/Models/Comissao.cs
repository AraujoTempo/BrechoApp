namespace BrechoApp.Models
{
    public class Comissao
    {
        public string CodigoComissao { get; set; } = "";
        public string CodigoVenda { get; set; } = "";
        public string CodigoFornecedor { get; set; } = "";
        public double ValorComissao { get; set; }
        public string DataComissao { get; set; } = "";
        public bool ComissaoPaga { get; set; }
    }
}
