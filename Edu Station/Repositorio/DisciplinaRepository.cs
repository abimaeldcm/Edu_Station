using Edu_Station.Data;
using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;

namespace Edu_Station.Repositorio
{
    public class DisciplinaRepository : ICRUDRepository<Disciplina>
    {
        private readonly BancoContext _bancoContext;

        public DisciplinaRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
       
    }
}
