using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Materia
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "A disciplina precisa de um nome")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "A disciplina precisa de um professor")]
        public string Professor { get; set; }

        [Required(ErrorMessage = "A disciplina precisa de uma carga horária")]
        [Range(5,1000, ErrorMessage ="A carga horária precisa ser maior do que 5")]
        public int CargaHoraria { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

    }
}
