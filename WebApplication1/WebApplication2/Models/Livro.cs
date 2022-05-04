using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Preco { get; set; }
        public int QtdPag { get; set; }
        public bool Ativo { get; set; }
        public static List<Livro> ListaLivros = new List<Livro>();

        static Livro()
        {
            Livro.ListaLivros.Add(new Livro { Id = 1, Nome = "Algoritmos e Estruturas de Dados", Preco = "109.90" , QtdPag = 298, Ativo = true });
            Livro.ListaLivros.Add(new Livro { Id = 2, Nome = "Use a Cabeça! C#", Preco = "89.92", QtdPag = 283, Ativo = true });
            Livro.ListaLivros.Add(new Livro { Id = 3, Nome = "C# Para Iniciantes", Preco = "112.00", QtdPag = 305, Ativo = true });
        }
    }
}
