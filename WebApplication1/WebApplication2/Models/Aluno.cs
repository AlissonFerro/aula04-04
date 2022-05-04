//using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome precisa ser preenchido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O Curso precisa ser preenchido")]
        public string Curso { get; set; }


        [Required(ErrorMessage = "O E-mail precisa ser preenchido")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        [Range(14, 100, ErrorMessage = "A idade deve ser maior do que 14")]
        [Required(ErrorMessage = "Idade precisa ser preenchido")]
        public int Idade { get; set; }

        public bool Ativo { get; set; }

        public static List<Aluno> listagem = new List<Aluno>();

        static Aluno()
        {
            Aluno.listagem.Add(new Aluno { Id = 1, Name = "Edjalma", Curso = "TDS", Ativo = true, Email = "edjalma@senai.com", Idade = 30 });
            Aluno.listagem.Add(new Aluno { Id = 2, Name = "Vinícius", Curso = "Mecatronica", Ativo = true, Email = "vinicius@senai.com", Idade = 30 });
            Aluno.listagem.Add(new Aluno { Id = 3, Name = "Andre", Curso = "Elétrica", Ativo = true, Email = "andre@senai.com", Idade = 30 });
        }

        public void AdicionaAluno(Aluno aluno)
        {
            aluno.Id = listagem.Count;
            listagem.Add(aluno);
        }

    }
}
