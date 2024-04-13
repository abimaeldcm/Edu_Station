using Edu_Station.Models;
using Edu_Station.Models.Enum;
using Edu_Station.Repositorio.Interfaces;
using Edu_Station.Service.Interfaces;
using Edu_Station.SessaoUsuario;
using Microsoft.AspNetCore.Http;

namespace Edu_Station.Service.DocenteService
{
    public class DocenteService : ICRUDService<Docente>, ILoginService<Docente, Login>
    {
        private readonly ICRUDRepository<Docente> _repository;
        private readonly ILoginRepository<Docente, Login> _loginRepository;
        private readonly ISessao _sessao;

        public DocenteService(ICRUDRepository<Docente> repository, ILoginRepository<Docente, Login> loginRepository, ISessao sessao)
        {
            _repository = repository;
            _loginRepository = loginRepository;
            _sessao = sessao;
        }

        public async Task<Docente> Adicionar(Docente adicionar)
        {
            adicionar.Senha = BCrypt.Net.BCrypt.HashPassword(adicionar.Senha);
            return await _repository.Adicionar(adicionar);
        }

        public Task AlterarSenha(Docente pessoa, string novaSenha)
        {
            throw new NotImplementedException();
        }

        public async Task<Docente> Buscar(Guid id)
        {
            return await _repository.Buscar(id);
        }

        public async Task<Docente> BuscarPorEmail(string email)
        {
            return await _loginRepository.BuscarPorEmail(email);
        }

        public Task<bool> Delete(Guid id)
        {
            return _repository.Delete(id);
        }

        public async Task<Docente> Editar(Docente editar)
        {
            editar.Senha = BCrypt.Net.BCrypt.HashPassword(editar.Senha);
            return await _repository.Editar(editar);
        }

        public async Task<List<Docente>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Docente> Logar(Login login)
        {
            Docente DocenteRepository = await _loginRepository.Logar(login);
            bool senhaValida = BCrypt.Net.BCrypt.Verify(login.Senha, login.Senha);
            if (!senhaValida)
            {
                throw new Exception("Senha ou login incorretos");
            }
            await _sessao.CriarSessaoDoUsuario((Pessoa)DocenteRepository);


            return DocenteRepository;
        }
    }
}

