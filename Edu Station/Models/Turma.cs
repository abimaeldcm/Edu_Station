namespace Edu_Station.Models
{
    public class Turma
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Ano { get; set; }
        public DateTime DataCriacao { get; set; }

        public List<Docente> Docentes { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}
