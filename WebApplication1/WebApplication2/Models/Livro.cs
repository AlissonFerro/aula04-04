using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public decimal Preco { get; set; }
        public int QtdPag { get; set; }
        public bool Ativo { get; set; }
    }
}
