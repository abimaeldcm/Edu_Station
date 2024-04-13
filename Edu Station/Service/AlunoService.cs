using Edu_Station.Models;
using Edu_Station.Models.Enum;
using Edu_Station.Repositorio;
using Edu_Station.Repositorio.Interfaces;
using Edu_Station.Service.Interfaces;
using Edu_Station.SessaoUsuario;
using Microsoft.Extensions.Logging;

namespace Edu_Station.Service.AlunoService
{
    public class AlunoService : ICRUDService<Aluno>, ILoginService<Aluno, Login>
    {
        private readonly ICRUDRepository<Aluno> _repository;
        private readonly ILoginRepository<Aluno, Login> _loginRepository;
        private readonly ISessao _sessao;

        public AlunoService(ICRUDRepository<Aluno> repository, ILoginRepository<Aluno, Login> loginRepository, ISessao sessao)
        {
            _repository = repository;
            _loginRepository = loginRepository;
            _sessao = sessao;
        }

        public async Task<Aluno> Adicionar(Aluno adicionar)
        {
            adicionar.Senha = BCrypt.Net.BCrypt.HashPassword(adicionar.Senha);
            return await _repository.Adicionar(adicionar);
        }

        public async Task AlterarSenha(Aluno pessoa, string novaSenha)
        {
            pessoa.Senha = novaSenha;
            await _repository.Editar(pessoa);
        }

        public async Task<Aluno> Buscar(Guid id)
        {
            return await _repository.Buscar(id);
        }

        public async Task<Aluno> BuscarPorEmail(string email)
        {
            return await _loginRepository.BuscarPorEmail(email);
        }

        public Task<bool> Delete(Guid id)
        {
            return _repository.Delete(id);
        }

        public async Task<Aluno> Editar(Aluno editar)
        {
            editar.Senha = BCrypt.Net.BCrypt.HashPassword(editar.Senha);
            return await _repository.Editar(editar);
        }

        public async Task<List<Aluno>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Aluno> Logar(Login login)
        {
            Aluno alunoRepository = await _loginRepository.Logar(login);
            bool senhaValida = BCrypt.Net.BCrypt.Verify(login.Senha, login.Senha);
            if (!senhaValida)
            {
                throw new Exception("Senha ou login incorretos");
            }
            await _sessao.CriarSessaoDoUsuario((Pessoa)alunoRepository);


            return alunoRepository;
        }
    }
}
