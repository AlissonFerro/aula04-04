namespace WebApplication2.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Curso { get; set; }
        public static List<Aluno> listagem = new List<Aluno>();
        static Aluno()
        {
            Aluno.listagem.Add(new Aluno { Id = 1, Name = "Edjalma", Curso = "TDS" });
            Aluno.listagem.Add(new Aluno { Id = 2, Name = "Vinícius", Curso = "Mecatronica" });
            Aluno.listagem.Add(new Aluno { Id = 3, Name = "Andre", Curso = "Elétrica" });
        }

        public void AdicionaAluno(Aluno aluno)
        {
            aluno.Id = listagem.Count;
            listagem.Add(aluno);
        }

    }
}
