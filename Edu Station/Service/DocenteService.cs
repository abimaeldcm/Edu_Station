using Edu_Station.Data;
using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;
using Edu_Station.Service.Interface;

namespace Edu_Station.Service.DocenteService
{
    public class DocenteService : ICRUDService<Docente>
    {
        private readonly ICRUDRepository<Docente> _repository;

        public DocenteService(ICRUDRepository<Docente> repository)
        {
            _repository = repository;
        }

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

