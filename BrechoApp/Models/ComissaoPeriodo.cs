namespace BrechoApp.Models
{
    public class ComissaoPeriodo
    {
        public int IdPeriodo { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public string DataAbertura { get; set; }
        public string DataFechamento { get; set; }
        public string Status { get; set; }
    }
}