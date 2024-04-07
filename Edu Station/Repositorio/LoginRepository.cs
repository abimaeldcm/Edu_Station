using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;

namespace Edu_Station.Repositorio
{
    public class LoginRepository : ICRUDRepository<Login>
    {
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
