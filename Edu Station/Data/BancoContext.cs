using Edu_Station.Models;
using Microsoft.EntityFrameworkCore;

namespace Edu_Station.Data
{
    // Contexto do banco de dados que herda da classe DbContext do Entity Framework Core
    public class BancoContext : DbContext
    {
        // Construtor que recebe as opções de configuração do banco de dados
        public BancoContext(DbContextOptions<BancoContext> options)
            : base(options)
        {

        }

        // Define conjuntos de entidades que serão mapeadas para tabelas do banco de dados
        public DbSet<Aluno> Alunos { get; set; } // Conjunto de entidades de Aluno mapeadas para a tabela Alunos
        public DbSet<Disciplina> Disciplinas { get; set; } // Conjunto de entidades de Disciplina mapeadas para a tabela Disciplinas
        public DbSet<Docente> Docentes { get; set; } // Conjunto de entidades de Docente mapeadas para a tabela Docentes
        public DbSet<Turma> Turmas { get; set; } // Conjunto de entidades de Turma mapeadas para a tabela Turmas
        public DbSet<Diretor> Diretores { get; set; } // Conjunto de entidades de Diretor mapeadas para a tabela Diretores
        public DbSet<Login> Logins { get; set; } // Conjunto de entidades de Login mapeadas para a tabela Logins

        // Método para configurar o modelo de banco de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica as configurações de entidade do assembly atual
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BancoContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
