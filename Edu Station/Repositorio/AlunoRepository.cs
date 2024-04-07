using Edu_Station.Data;
using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Edu_Station.Repositorio
{
    public class AlunoRepository : ICRUDRepository<Aluno>
    {
        private readonly BancoContext _bancoContext;

        public AlunoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<Aluno> Adicionar(Aluno adicionar)
        {
            adicionar.Senha = BCrypt.Net.BCrypt.HashPassword("123456");

            await _bancoContext.Alunos.AddAsync(adicionar);
            await _bancoContext.SaveChangesAsync();
        }

        public Task<Aluno> Buscar(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Aluno> Editar(Aluno editar)
        {
            throw new NotImplementedException();
        }

        public Task<List<Aluno>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
