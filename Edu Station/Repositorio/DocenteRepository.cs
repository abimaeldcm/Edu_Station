using Edu_Station.Data;
using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edu_Station.Repositorio
{
    public class DocenteRepository : ICRUDRepository<Docente>, ILoginRepository<Docente, Login>
    {
        private readonly BancoContext _bancoContext;

        public DocenteRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<Docente> Adicionar(Docente adicionar)
        {
            try
            {
                await _bancoContext.Docentes.AddAsync(adicionar);
                await _bancoContext.SaveChangesAsync();

                return adicionar;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao adicionar o Docente no banco");
            }

        }

        public async Task<Docente> Buscar(Guid id)
        {
            try
            {
                Docente DocenteBanco = await _bancoContext.Docentes.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
                return DocenteBanco is null ?  throw new ArgumentNullException("Docente não existe no Banco de Dados") : DocenteBanco;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar o Docente no banco");
            }
        }

        public Task<Docente> BuscarPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                Docente DocenteBanco = await Buscar(id);
                _bancoContext.Docentes.Remove(DocenteBanco);
                await _bancoContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar o Docente no banco");
            }
        }

        public async Task<Docente> Editar(Docente editar)
        {
            try
            {
                Docente DocenteBanco = await Buscar(editar.Id);
                _bancoContext.Docentes.Update(editar);
                await _bancoContext.SaveChangesAsync();
                return editar;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar o Docente no banco");
            }
        }

        public async Task<List<Docente>> GetAll()
        {
            try
            {
                return await _bancoContext.Docentes.ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar os Docentes no banco");
            }
        }

        public async Task<Docente> Logar(Login login)
        {
            try
            {
                Docente loginDb = await _bancoContext.Docentes.FirstOrDefaultAsync(x => x.CPF == login.User && x.Senha == login.Senha);
                return loginDb is null ? throw new ArgumentNullException("Docente não existe no Banco de Dados") : loginDb;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao localizar o login");
            }
        }
    }
}
