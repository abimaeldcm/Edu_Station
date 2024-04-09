using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;
using Edu_Station.Service.Interfaces;

namespace Edu_Station.Service.DisciplinaService

{
    public class DisciplinaService : ICRUDService<Disciplina>
    {
        private readonly ICRUDRepository<Disciplina> _repository;

        public DisciplinaService(ICRUDRepository<Disciplina> repository)
        {
            _repository = repository;
        }

        public async Task<Disciplina> Adicionar(Disciplina adicionar)
        {
            return await _repository.Adicionar(adicionar);
        }

        public async Task<Disciplina> Buscar(Guid id)
        {
            return await _repository.Buscar(id);
        }

        public Task<bool> Delete(Guid id)
        {
            return _repository.Delete(id);
        }

        public async Task<Disciplina> Editar(Disciplina editar)
        {
            return await _repository.Editar(editar);
        }

        public async Task<List<Disciplina>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
