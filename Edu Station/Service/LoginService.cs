using Edu_Station.Models;
using Edu_Station.Repositorio.Interfaces;
using Edu_Station.Service.Interfaces;
using Edu_Station.SessaoUsuario;
using Microsoft.AspNetCore.Http;

namespace Edu_Station.Service.LoginService
{
    public class LoginService : ICRUDService<Login>, ILoginService
    {
        private readonly ICRUDRepository<Login> _repository;
        private readonly ILoginRepository _LoginRepository;
        private readonly ISessao _sessao;

        public LoginService(ICRUDRepository<Login> repository, ILoginRepository loginRepository, ISessao sessao)
        {
            _repository = repository;
            _LoginRepository = loginRepository;
            _sessao = sessao;
        }

        public async Task<Login> Adicionar(Login adicionar)
        {
            return await _repository.Adicionar(adicionar);
        }

        public async Task<Login> Buscar(Guid id)
        {
            return await _repository.Buscar(id);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        public async Task<Login> Editar(Login editar)
        {
            return await _repository.Editar(editar);
        }

        public async Task<List<Login>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Login> Logar(Login login)
        {
            Login alunoRepositorio = await _LoginRepository.Logar(login);
            var SenhaCorresponde = BCrypt.Net.BCrypt.Verify(login.Senha, alunoRepositorio.Senha);
            if (SenhaCorresponde is false)
            {
                throw new Exception("Login ou senha inválidos");
            }
            _sessao.CriarSessaoDoUsuario(login);

            return alunoRepositorio;
        }
    }
}
