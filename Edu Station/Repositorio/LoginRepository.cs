﻿using Edu_Station.Data;
using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Edu_Station.Repositorio
{
    public class LoginRepository : ICRUDRepository<Login>
    {
        private readonly BancoContext _bancoContext;

        public LoginRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<Login> Adicionar(Login adicionar)
        {
            try
            {
                await _bancoContext.Logins.AddAsync(adicionar);
                await _bancoContext.SaveChangesAsync();

                return adicionar;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao adicionar o Login no banco");
            }

        }

        public async Task<Login> Buscar(Guid id)
        {
            try
            {
                Login LoginBanco = await _bancoContext.Logins.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
                return LoginBanco is null ? throw new ArgumentNullException("Login não existe no Banco de Dados") : LoginBanco;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar o Login no banco");
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                Login LoginBanco = await Buscar(id);
                if (LoginBanco is null)
                {
                    throw new Exception("Login não localizado");
                }
                _bancoContext.Logins.Remove(LoginBanco);
                await _bancoContext.SaveChangesAsync();

                return true;

            }
            catch (Exception)
            {
                throw new Exception("Erro ao deletar o Login no banco");
            }
        }

        public async Task<Login> Editar(Login editar)
        {
            try
            {
                Diretor LoginBanco = await _bancoContext.Diretores.FirstOrDefaultAsync(x => x.CPF == editar.User);
                if (LoginBanco is null)
                {
                    throw new ArgumentNullException("Login não localizado");
                }
                _bancoContext.Logins.Update(editar);
                await _bancoContext.SaveChangesAsync();
                return editar;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar o Login no banco");
            }
        }

        public async Task<List<Login>> GetAll()
        {
            try
            {
                return await _bancoContext.Logins.ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar os Logins no banco");
            }
        }
    }
}

