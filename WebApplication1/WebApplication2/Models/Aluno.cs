//using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Aluno
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "O Nome precisa ser preenchido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Curso precisa ser preenchido")]
        public string Curso { get; set; }


        [Required(ErrorMessage = "O E-mail precisa ser preenchido")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }


        [Range(14, 100, ErrorMessage = "A idade deve ser maior do que 14")]
        [Required(ErrorMessage = "Idade precisa ser preenchido")]
        public int Idade { get; set; }

        public bool Ativo { get; set; }


    }
}
