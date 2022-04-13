namespace WebApplication2.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Curso { get; set; }
        public bool Ativo { get; set; }
        public static List<Aluno> listagem = new List<Aluno>();
        public static List<Aluno> excluido = new List<Aluno>();
        static Aluno()
        {
            Aluno.listagem.Add(new Aluno { Id = 1, Name = "Edjalma", Curso = "TDS", Ativo = true });
            Aluno.listagem.Add(new Aluno { Id = 2, Name = "Vinícius", Curso = "Mecatronica", Ativo=true });
            Aluno.listagem.Add(new Aluno { Id = 3, Name = "Andre", Curso = "Elétrica", Ativo=true });
        }

        public void AdicionaAluno(Aluno aluno)
        {
            aluno.Id = listagem.Count;
            listagem.Add(aluno);
        }

    }
}
