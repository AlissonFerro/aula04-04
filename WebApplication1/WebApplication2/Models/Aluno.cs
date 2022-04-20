namespace WebApplication2.Models
{
    public class Aluno
    {
        
        public int Id { get; set; }

        public string Name { get; set; }
 
        public string Curso { get; set; }

        public string Email { get; set; }

        public int Idade { get; set; }

        public bool Ativo { get; set; }

        public static List<Aluno> listagem = new List<Aluno>();

        public static List<Aluno> excluido = new List<Aluno>();
        static Aluno()
        {
            Aluno.listagem.Add(new Aluno { Id = 1, Name = "Edjalma", Curso = "TDS", Ativo = true, Email = "edjalma@senai.com", Idade = 30 });
            Aluno.listagem.Add(new Aluno { Id = 2, Name = "Vinícius", Curso = "Mecatronica", Ativo=true, Email = "vinicius@senai.com", Idade = 30 });
            Aluno.listagem.Add(new Aluno { Id = 3, Name = "Andre", Curso = "Elétrica", Ativo=true, Email = "andre@senai.com", Idade = 30 }) ;
        }

        public void AdicionaAluno(Aluno aluno)
        {
            aluno.Id = listagem.Count;
            listagem.Add(aluno);
        }

    }
}
