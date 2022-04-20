using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Materia
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "A disciplina precisa de um nome")]
        public string Name { get; set; }


        [Required(ErrorMessage = "A disciplina precisa de um professor")]
        public string Professor { get; set; }

        [Required(ErrorMessage = "A disciplina precisa de uma carga horária")]
        [Range(5,1000, ErrorMessage ="A carga horária precisa ser maior do que 4")]
        public int CargaHorario { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public static List<Materia> listagemMaterias = new List<Materia>();

        static Materia()
        {
            Materia.listagemMaterias.Add(new Materia() { Id = 1, Name = "Desenvolvimento de Sistemas", Professor = "Algeu", CargaHorario = 100, Descricao = "Nam lobortis lectus ac ex eleifend malesuada.", Ativo = true });
            Materia.listagemMaterias.Add(new Materia() { Id = 2, Name = "Banco de Dados", Professor = "Edjalma", CargaHorario = 120, Descricao = "Nam lobortis lectus ac ex eleifend malesuada.", Ativo = true });
            Materia.listagemMaterias.Add(new Materia() { Id = 3, Name = "Manutenção de Sistemas", Professor = "Vinicius", CargaHorario = 80, Descricao = "Nam lobortis lectus ac ex eleifend malesuada.", Ativo = true }) ;
        }
    }
}
