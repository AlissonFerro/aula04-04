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

    }
}
