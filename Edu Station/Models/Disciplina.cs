namespace Edu_Station.Models
{
    public class Disciplina
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }

        public List<Aluno> Alunos { get; set; }
    }
}
