using Edu_Station.Data;
using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edu_Station.Repositorio
{
    public class DocenteRepostory : ICRUDRepository<Docente>, ILoginRepository<Docente>
    {
        private readonly BancoContext _bancoContext;

        public DocenteRepostory(BancoContext bancoContext)
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
                return DocenteBanco is null ? DocenteBanco : throw new ArgumentNullException("Docente não existe no Banco de Dados");
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar o Docente no banco");
            }
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

        public async Task<Docente> Logar(Docente login)
        {
            try
            {
                Docente loginDb = await _bancoContext.Docentes.FirstOrDefaultAsync(x => x.CPF == login.CPF && x.Senha == login.Senha);
                return loginDb is null ? throw new ArgumentNullException("Usuário não localizado") : loginDb;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao localizar o login");
            }
        }
    }
}
