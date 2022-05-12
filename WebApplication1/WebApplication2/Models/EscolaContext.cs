using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class EscolaContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Ligacao> Ligacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SERVIDOR\SQLEXPRESS01;Database=escola;Trusted_Connection=True;");
        }
    }
}
