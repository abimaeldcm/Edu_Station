using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;
using Edu_Station.Service.Interfaces;

namespace Edu_Station.Service.DocenteService
{
    public class DocenteService : ICRUDService<Docente>, ILoginService
    {
        private readonly ICRUDRepository<Docente> _repository;
        private readonly ILoginRepository _LoginRepository;

        public DocenteService(ICRUDRepository<Docente> repository, ILoginRepository loginRepository)
        {
            _repository = repository;
            _LoginRepository = loginRepository;
        }

        public Task<Docente> Adicionar(Docente adicionar)
        {
            throw new NotImplementedException();
        }

        public Task<Docente> Buscar(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
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

        public Task<Login> Logar(Login login)
        {
            throw new NotImplementedException();
        }
    }
}

