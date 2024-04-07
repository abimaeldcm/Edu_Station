using Edu_Station.Data;
using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;
using Edu_Station.Service.Interface;

namespace Edu_Station.Service.DisciplinaService

{
    public class DisciplinaService : ICRUDService<Disciplina>
    {
        private readonly ICRUDRepository<Disciplina> _repository;

        public DisciplinaService(ICRUDRepository<Disciplina> repository)
        {
            _repository = repository;
        }

        public Task<Disciplina> Adicionar(Disciplina adicionar)
        {
            throw new NotImplementedException();
        }

        public Task<Disciplina> Buscar(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Disciplina> Editar(Disciplina editar)
        {
            throw new NotImplementedException();
        }

        public Task<List<Disciplina>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
