﻿using Edu_Station.Data;
using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace Edu_Station.Repositorio
{
    // Repositório responsável por lidar com as operações CRUD para a entidade Aluno e operações de login.
    public class AlunoRepository : ICRUDRepository<Aluno>, ILoginRepository<Aluno, Login>
    {
        private readonly BancoContext _bancoContext;

        // Construtor que injeta o contexto do banco de dados.
        public AlunoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        // Método para adicionar um novo aluno ao banco de dados.
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

        // Método para buscar um aluno pelo seu ID.
        public async Task<Aluno> Buscar(Guid id)
        {
            try
            {
                Aluno alunoBanco = await _bancoContext.Alunos.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
                return alunoBanco is null ? throw new ArgumentNullException("Aluno não existe no Banco de Dados") : alunoBanco;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar o Aluno no banco");
            }
        }

        // Método para buscar um aluno pelo seu email.
        public async Task<Aluno> BuscarPorEmail(string email)
        {
            try
            {
                Aluno alunoBanco = await _bancoContext.Alunos.FirstOrDefaultAsync(x => x.Email == email);
                return alunoBanco is null ? throw new ArgumentNullException("Aluno não existe no Banco de Dados") : alunoBanco;
            }
            catch (Exception msg)
            {
                throw new Exception(msg.Message);
            }
        }

        // Método para excluir um aluno pelo seu ID.
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

        // Método para editar um aluno.
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

        // Método para obter todos os alunos do banco de dados.
        public async Task<List<Aluno>> GetAll()
        {
            try
            {
                return await _bancoContext.Alunos
                    .Include(x => x.Discipinas) // Inclui as disciplinas relacionadas ao aluno.
                    .Include(x => x.Turma) // Inclui a turma relacionada ao aluno.
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar os Alunos no banco");
            }
        }

        // Método para realizar o login de um aluno.
        public async Task<Aluno> Logar(Login login)
        {
            try
            {
                Aluno loginDb = await _bancoContext.Alunos.FirstOrDefaultAsync(x => x.CPF == login.User);
                return loginDb is null ? throw new ArgumentNullException("Aluno não existe no Banco de Dados") : loginDb;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao localizar o login");
            }
        }
    }
}
