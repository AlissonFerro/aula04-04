using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Ligacao
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome precisa ser preenchido")]
        public string NomeAluno { get; set; }

        [Required(ErrorMessage = "O Telefone precisa ser preenchido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O Assunto precisa ser preenchido")]
        public string Assunto { get; set; }
        public bool Ativo { get; set; }

        public static List<Ligacao> listagem = new List<Ligacao>();

        static Ligacao()
        {
            Ligacao.listagem.Add(new Ligacao { Id = 1, NomeAluno = "Edjalma", Telefone = "1234-5678", Ativo = true, Assunto = "Financeiro" });
            Ligacao.listagem.Add(new Ligacao { Id = 2, NomeAluno = "Vinícius", Telefone = "9999-8888", Ativo = true, Assunto = "Matricula"});
            Ligacao.listagem.Add(new Ligacao { Id = 3, NomeAluno = "Andre", Telefone = "9876-5432", Ativo=true, Assunto = "Outro"});
        }
    }
}
