namespace Edu_Station.Models
{
    public class Docente : Pessoa
    {
        public List<Aluno> Alunos { get; set; }
        public List<Turma> Turmas { get; set; }
        public List<Disciplina> Disciplinas { get; set; }
    }
}
