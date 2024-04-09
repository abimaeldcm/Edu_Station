using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;
using Edu_Station.Service.Interfaces;

namespace Edu_Station.Service.TurmaService
{

    public class TurmaService : ICRUDService<Turma>
    {
        private readonly ICRUDRepository<Turma> _repository;

        public TurmaService(ICRUDRepository<Turma> repository)
        {
            _repository = repository;
        }
        public async Task<Turma> Adicionar(Turma adicionar)
        {
            return await _repository.Adicionar(adicionar);
        }

        public async Task<Turma> Buscar(Guid id)
        {
            return await _repository.Buscar(id);
        }

        public Task<bool> Delete(Guid id)
        {
            return _repository.Delete(id);
        }

        public async Task<Turma> Editar(Turma editar)
        {
            return await _repository.Editar(editar);
        }

        public async Task<List<Turma>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}