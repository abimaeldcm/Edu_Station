using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;

namespace Edu_Station.Repositorio
{
    public class DocenteRepostory : ICRUDRepository<Docente>
    {
        public Task<Docente> Adicionar(Docente adicionar)
        {
            throw new NotImplementedException();
        }

        public Task<Docente> Buscar(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Docente> Editar(Docente editar)
        {
            throw new NotImplementedException();
        }

        public Task<List<Docente>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
