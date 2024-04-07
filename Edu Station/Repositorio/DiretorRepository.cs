using Edu_Station.Data;
using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;

namespace Edu_Station.Repositorio
{
    public class DiretorRepository : ICRUDRepository<Diretor>
    {
        private readonly BancoContext _bancoContext;

        public DiretorRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public Task<Diretor> Adicionar(Diretor adicionar)
        {
            throw new NotImplementedException();
        }

        public Task<Diretor> Buscar(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Diretor> Editar(Diretor editar)
        {
            throw new NotImplementedException();
        }

        public Task<List<Diretor>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
