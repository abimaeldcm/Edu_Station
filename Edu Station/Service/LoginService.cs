using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;
using Edu_Station.Service.Interface;

namespace Edu_Station.Service.LoginService
{
    public class LoginService : ICRUDService<Login>
    {
        private readonly ICRUDRepository<Login> _repository;

        public LoginService(ICRUDRepository<Login> repository)
        {
            _repository = repository;
        }

        public Task<Login> Adicionar(Login adicionar)
        {
            throw new NotImplementedException();
        }

        public Task<Login> Buscar(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Login> Editar(Login editar)
        {
            throw new NotImplementedException();
        }

        public Task<List<Login>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
