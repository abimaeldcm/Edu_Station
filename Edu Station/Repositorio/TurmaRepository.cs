using Edu_Station.Data;
using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edu_Station.Repositorio
{
    // Repositório responsável por lidar com as operações CRUD para a entidade Turma.
    public class TurmaRepository : ICRUDRepository<Turma>
    {
        private readonly BancoContext _bancoContext;

        // Construtor que injeta o contexto do banco de dados.
        public TurmaRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        // Método para adicionar uma nova turma ao banco de dados.
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
                throw new Exception("Erro ao adicionar a Turma no banco");
            }
        }

        // Método para buscar uma turma pelo seu ID.
        public async Task<Turma> Buscar(Guid id)
        {
            try
            {
                Turma TurmaBanco = await _bancoContext.Turmas.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
                return TurmaBanco is null ? throw new ArgumentNullException("Turma não existe no Banco de Dados") : TurmaBanco;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar a Turma no banco");
            }
        }

        // Método para excluir uma turma pelo seu ID.
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
                throw new Exception("Erro ao excluir a Turma no banco");
            }
        }

        // Método para editar uma turma.
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
                throw new Exception("Erro ao editar a Turma no banco");
            }
        }

        // Método para obter todas as turmas do banco de dados.
        public async Task<List<Turma>> GetAll()
        {
            try
            {
                var turmas = await _bancoContext.Turmas.ToListAsync();
                return turmas;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar as Turmas no banco");
            }
        }
    }
}
