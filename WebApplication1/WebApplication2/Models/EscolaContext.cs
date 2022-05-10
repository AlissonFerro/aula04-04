using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class EscolaContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Materia> Materias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SNCCH01LABF116\TEW_SQLEXPRESS;Database=escola;Trusted_Connection=True;");
        }
    }
}
