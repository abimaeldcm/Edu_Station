using Edu_Station.Data;
using Edu_Station.Models;
using Edu_Station.Models.Enum;
using Edu_Station.Repositorio;
using Edu_Station.Repositorio.Interfaces;
using Edu_Station.Service.Interfaces;
using Edu_Station.SessaoUsuario;

namespace Edu_Station.Service.DiretorService
{
    public class DiretorService : ICRUDService<Diretor>, ILoginService<Diretor, Login>
    {
        private readonly ICRUDRepository<Diretor> _repository;
        private readonly ILoginRepository<Diretor, Login> _loginRepository;
        private readonly ISessao _sessao;

        public DiretorService(ICRUDRepository<Diretor> repository, ILoginRepository<Diretor, Login> loginRepository, ISessao sessao)
        {
            _repository = repository;
            _loginRepository = loginRepository;
            _sessao = sessao;
        }

        public async Task<Diretor> Adicionar(Diretor adicionar)
        {
            adicionar.Senha = BCrypt.Net.BCrypt.HashPassword(adicionar.Senha);
            return await _repository.Adicionar(adicionar);
        }

        public async Task<Diretor> Buscar(Guid id)
        {
            return await _repository.Buscar(id);
        }

        public async Task<Diretor> BuscarPorEmail(string email)
        {
            return await _loginRepository.BuscarPorEmail(email);
        }

        public Task<bool> Delete(Guid id)
        {
            return _repository.Delete(id);
        }

        public async Task<Diretor> Editar(Diretor editar)
        {

            editar.Senha = BCrypt.Net.BCrypt.HashPassword(editar.Senha);
            return await _repository.Editar(editar);
        }

        public async Task<List<Diretor>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Diretor> Logar(Login login)
        {
            Diretor DiretorRepository = await _loginRepository.Logar(login);
            bool senhaValida = BCrypt.Net.BCrypt.Verify(login.Senha, DiretorRepository.Senha);
            if (!senhaValida)
            {
                throw new Exception("Senha ou login incorretos");
            }
            _sessao.CriarSessaoDoUsuario(EPerfil.Docente);

            return DiretorRepository;
        }
    }
}
