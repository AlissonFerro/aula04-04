namespace WebApplication2.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Professor { get; set; }
        public int CargaHorario { get; set; }
        public static List<Materia> listagemMaterias = new List<Materia>();

        static Materia()
        {
            Materia.listagemMaterias.Add(new Materia() { Id = 1, Name = "Desenvolvimento de Sistemas", Professor = "Algeu", CargaHorario = 100 });
            Materia.listagemMaterias.Add(new Materia() { Id = 2, Name = "Banco de Dados", Professor = "Edjalma", CargaHorario = 120 });
            Materia.listagemMaterias.Add(new Materia() { Id = 3, Name = "Manutenção de Sistemas", Professor = "Vinicius", CargaHorario = 80 });
        }
    }
}
