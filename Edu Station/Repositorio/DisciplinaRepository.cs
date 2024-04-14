using Edu_Station.Data;
using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edu_Station.Repositorio
{
    // Repositório responsável por lidar com as operações CRUD para a entidade Disciplina.
    public class DisciplinaRepository : ICRUDRepository<Disciplina>
    {
        private readonly BancoContext _bancoContext;

        // Construtor que injeta o contexto do banco de dados.
        public DisciplinaRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        // Método para adicionar uma nova disciplina ao banco de dados.
        public async Task<Disciplina> Adicionar(Disciplina adicionar)
        {
            try
            {
                await _bancoContext.Disciplinas.AddAsync(adicionar);
                await _bancoContext.SaveChangesAsync();

                return adicionar;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao adicionar o Disciplina no banco");
            }

        }

        // Método para buscar uma disciplina pelo seu ID.
        public async Task<Disciplina> Buscar(Guid id)
        {
            try
            {
                Disciplina DisciplinaBanco = await _bancoContext.Disciplinas.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
                return DisciplinaBanco is null ? throw new ArgumentNullException("Disciplina não existe no Banco de Dados") : DisciplinaBanco;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar o Disciplina no banco");
            }
        }

        // Método para excluir uma disciplina pelo seu ID.
        public async Task<bool> Delete(Guid id)
        {
            try
            {
                Disciplina DisciplinaBanco = await Buscar(id);
                _bancoContext.Disciplinas.Remove(DisciplinaBanco);
                await _bancoContext.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar o Disciplina no banco");
            }
        }

        // Método para editar uma disciplina.
        public async Task<Disciplina> Editar(Disciplina editar)
        {
            try
            {
                Disciplina DisciplinaBanco = await Buscar(editar.Id);
                _bancoContext.Disciplinas.Update(editar);
                await _bancoContext.SaveChangesAsync();
                return editar;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar o Disciplina no banco");
            }
        }

        // Método para obter todas as disciplinas do banco de dados.
        public async Task<List<Disciplina>> GetAll()
        {
            try
            {
                return await _bancoContext.Disciplinas.ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar os Disciplinas no banco");
            }
        }
    }
}
