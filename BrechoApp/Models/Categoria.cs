using System;

namespace BrechoApp.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string NomeCategoria { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }
    }
}
