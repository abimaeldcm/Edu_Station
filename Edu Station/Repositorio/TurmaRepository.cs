using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;

namespace Edu_Station.Repositorio
{
    public class TurmaRepository : ICRUDRepository<Turma>
    {
        public Task<Turma> Adicionar(Turma adicionar)
        {
            throw new NotImplementedException();
        }

        public Task<Turma> Buscar(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Turma> Editar(Turma editar)
        {
            throw new NotImplementedException();
        }

        public Task<List<Turma>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
