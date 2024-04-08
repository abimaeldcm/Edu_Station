using Edu_Station.Data;
using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;
using Edu_Station.Service.Interface;
using Edu_Station.Service.Interfaces;

namespace Edu_Station.Service.DiretorService
{
    public class TurmaService : ICRUDService<Turma>, ILoginService
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

        public Task<bool> Delete(Guid id)
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

        public Task<Login> Logar(Login login)
        {
            throw new NotImplementedException();
        }
    }
}
