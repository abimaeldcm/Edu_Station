using Edu_Station.Data;
using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edu_Station.Repositorio
{
    public class TurmaRepository : ICRUDRepository<Turma>
    {
        private readonly BancoContext _bancoContext;

        public TurmaRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public async Task<Turma> Adicionar(Turma adicionar)
        {
            try
            {
                await _bancoContext.Turmas.AddAsync(adicionar);
                await _bancoContext.SaveChangesAsync();

                return adicionar;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao adicionar o Turma no banco");
            }

        }

        public async Task<Turma> Buscar(Guid id)
        {
            try
            {
                Turma TurmaBanco = await _bancoContext.Turmas.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
                return TurmaBanco is null ? throw new ArgumentNullException("Turma não existe no Banco de Dados") : TurmaBanco;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar o Turma no banco");
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                Turma TurmaBanco = await Buscar(id);
                _bancoContext.Turmas.Remove(TurmaBanco);
                await _bancoContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar o Turma no banco");
            }
        }

        public async Task<Turma> Editar(Turma editar)
        {
            try
            {
                Turma TurmaBanco = await Buscar(editar.Id);
                _bancoContext.Turmas.Update(editar);
                await _bancoContext.SaveChangesAsync();
                return editar;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar o Turma no banco");
            }
        }

        public async Task<List<Turma>> GetAll()
        {
            try
            {
                var a = await _bancoContext.Turmas.ToListAsync();
                return a;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar os Turmas no banco");
            }
        }
    }
}
