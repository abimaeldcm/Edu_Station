using Edu_Station.Models;
using Microsoft.EntityFrameworkCore;

namespace Edu_Station.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options)
            : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; } 
        public DbSet<Disciplina> Disciplinas { get; set; } 
        public DbSet<Docente> Docentes { get; set; } 
        public DbSet<Turma> Turmas { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BancoContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
