using Edu_Station.Data;
using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;
using Edu_Station.Service.Interface;

namespace Edu_Station.Service.DiretorService
{
    public class TurmaService : ICRUDService<Turma>
    {
        private readonly ICRUDRepository<Turma> _repository;

        public TurmaService(ICRUDRepository<Turma> repository)
        {
            _repository = repository;
        }
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
