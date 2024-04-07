namespace Edu_Station.Models
{
    public class Aluno : Pessoa
    {
        public Guid IdTurma { get; set; }
        public Turma Turma { get; set; }

        public List<Disciplina> Discipinas { get; set; }
    }
}
