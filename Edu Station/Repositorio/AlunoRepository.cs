﻿using Edu_Station.Data;
using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edu_Station.Repositorio
{
    public class AlunoRepository : ICRUDRepository<Aluno>, ILoginRepository<Aluno>
    {
        private readonly BancoContext _bancoContext;

        public AlunoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<Aluno> Adicionar(Aluno adicionar)
        {
            try
            {
                await _bancoContext.Alunos.AddAsync(adicionar);
                await _bancoContext.SaveChangesAsync();

                return adicionar;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao adicionar o Aluno no banco");
            }

        }

        public async Task<Aluno> Buscar(Guid id)
        {
            try
            {
                Aluno alunoBanco = await _bancoContext.Alunos.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
                return alunoBanco is null ? alunoBanco : throw new ArgumentNullException("Aluno não existe no Banco de Dados");
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar o Aluno no banco");
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                Aluno alunoBanco = await Buscar(id);
                _bancoContext.Alunos.Remove(alunoBanco);
                await _bancoContext.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar o Aluno no banco");
            }
        }

        public async Task<Aluno> Editar(Aluno editar)
        {
            try
            {
                Aluno alunoBanco = await Buscar(editar.Id);
                _bancoContext.Alunos.Update(editar);
                await _bancoContext.SaveChangesAsync();
                return editar;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar o Aluno no banco");
            }
        }

        public async Task<List<Aluno>> GetAll()
        {
            try
            {
                return await _bancoContext.Alunos.ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar os Alunos no banco");
            }
        }

        public async Task<Aluno> Logar(Aluno login)
        {
            try
            {
                Aluno loginDb = await _bancoContext.Alunos.FirstOrDefaultAsync(x => x.CPF == login.CPF && x.Senha == login.Senha);
                return loginDb is null ? throw new ArgumentNullException("Usuário não localizado") : loginDb;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao localizar o login");
            }
        }
    }
}
