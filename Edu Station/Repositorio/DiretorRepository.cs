using Edu_Station.Data;
using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edu_Station.Repositorio
{
    public class DiretorRepository : ICRUDRepository<Diretor>, ILoginRepository<Diretor, Login>
    {
        private readonly BancoContext _bancoContext;

        public DiretorRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<Diretor> Adicionar(Diretor adicionar)
        {
            try
            {
                await _bancoContext.Diretores.AddAsync(adicionar);
                await _bancoContext.SaveChangesAsync();

                return adicionar;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao adicionar o Diretor no banco");
            }

        }

        public async Task<Diretor> Buscar(Guid id)
        {
            try
            {
                Diretor DiretorBanco = await _bancoContext.Diretores.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
                return DiretorBanco is null ? throw new ArgumentNullException("Diretor não existe no Banco de Dados") : DiretorBanco;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar o Diretor no banco");
            }
        }

        public async Task<Diretor> BuscarPorEmail(string email)
        {
            try
            {
                Diretor alunoBanco = await _bancoContext.Diretores.FirstOrDefaultAsync(x => x.Email == email);
                return alunoBanco is null ?  throw new ArgumentNullException("Diretor não existe no Banco de Dados") : alunoBanco;
            }
            catch (Exception msg)
            {
                throw new Exception(msg.Message);
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                Diretor DiretorBanco = await Buscar(id);
                _bancoContext.Diretores.Remove(DiretorBanco);
                await _bancoContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar o Diretor no banco");
            }
        }

        public async Task<Diretor> Editar(Diretor editar)
        {
            try
            {
                Diretor DiretorBanco = await Buscar(editar.Id);
                _bancoContext.Diretores.Update(editar);
                await _bancoContext.SaveChangesAsync();
                return editar;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar o Diretor no banco");
            }
        }

        public async Task<List<Diretor>> GetAll()
        {
            try
            {
                return await _bancoContext.Diretores.ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar os Diretors no banco");
            }
        }

        public async Task<Diretor> Logar(Login login)
        {
            try
            {
                Diretor loginDb = await _bancoContext.Diretores.FirstOrDefaultAsync(x => x.CPF == login.User);
                return loginDb is null ? throw new ArgumentNullException("Diretor não existe no Banco de Dados") : loginDb;
            }
            catch (Exception mensagem)
            {
                throw new Exception(mensagem.Message);
            }
        }
    }
}
