using Edu_Station.Data;
using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;
using Edu_Station.Service.Interface;

namespace Edu_Station.Service.AlunoService
{
    public class AlunoService : ICRUDService<Aluno>
    {
        private readonly ICRUDRepository<Aluno> _repository;

        public AlunoService(ICRUDRepository<Aluno> repository)
        {
            _repository = repository;
        }

        public Task<Aluno> Adicionar(Aluno adicionar)
        {
            throw new NotImplementedException();
        }

        public Task<Aluno> Buscar(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Aluno> Editar(Aluno editar)
        {
            throw new NotImplementedException();
        }

        public Task<List<Aluno>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
