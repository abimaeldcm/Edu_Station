using Edu_Station.Helpers;
using Edu_Station.Models;
using Edu_Station.Models.Enum;
using Edu_Station.Service.Interfaces;
using Edu_Station.SessaoUsuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace Edu_Station.Controllers
{
    public class LoginController : Controller
    {
        // Declaração de serviços e dependências necessárias
        private readonly ICRUDService<Login> _service;
        private readonly ILoginService<Diretor, Login> _LoginDiretorService;
        private readonly ILoginService<Docente, Login> _LoginDocenteService;
        private readonly ILoginService<Aluno, Login> _LoginAlunoService;
        private readonly ICRUDService<Diretor> _diretorService;
        private readonly ICRUDService<Docente> _docenteService;
        private readonly ICRUDService<Aluno> _alunoService;
        private readonly IEmailService _emailService;
        private readonly IVerficadorCodigo _VerificadorDeCodigoService;
        private readonly ISessao _sessao;

        // Construtor que injeta as dependências necessárias
        public LoginController(ICRUDService<Login> service, ILoginService<Diretor, Login> loginDiretorService, ILoginService<Docente, Login> loginDocenteService, ILoginService<Aluno, Login> loginAlunoService, ICRUDService<Diretor> diretorService, ICRUDService<Docente> docenteService, ICRUDService<Aluno> alunoService, IEmailService emailService, IVerficadorCodigo verificadorDeCodigoService, ISessao sessao)
        {
            _service = service;
            _LoginDiretorService = loginDiretorService;
            _LoginDocenteService = loginDocenteService;
            _LoginAlunoService = loginAlunoService;
            _diretorService = diretorService;
            _docenteService = docenteService;
            _alunoService = alunoService;
            _emailService = emailService;
            _VerificadorDeCodigoService = verificadorDeCodigoService;
            _sessao = sessao;
        }

        // GET: LoginController/Index
        public ActionResult Index()
        {
            // Prepara a lista de perfis para exibição no formulário de login
            ViewBag.PerfilId = new SelectList(Enum.GetValues(typeof(EPerfil)));
            return View();
        }

        // POST: LoginController/Logar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Logar(Login logar)
        {
            try
            {
                // Verifica o perfil do usuário e redireciona para a página inicial apropriada
                switch (logar.Perfil)
                {
                    case EPerfil.Diretor:
                        await _LoginDiretorService.Logar(logar);
                        break;
                    case EPerfil.Docente:
                        await _LoginDocenteService.Logar(logar);
                        break;
                    case EPerfil.Aluno:
                        await _LoginAlunoService.Logar(logar);
                        break;
                    default:
                        throw new Exception("Perfil de usuário inválida");
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception erro)
            {
                // Em caso de erro, exibe a mensagem de erro e recarrega a página de login
                TempData["MensagemErro"] = erro.Message;
                ViewBag.PerfilId = new SelectList(Enum.GetValues(typeof(EPerfil)));
                return View("Index", logar);
            }
        }

        // GET: LoginController/AlterarSenha
        [HttpGet]
        public IActionResult AlterarSenha()
        {
            // Retorna a visualização para alterar a senha do usuário logado
            return View("AlterarSenhaLogado");
        }

        // POST: LoginController/AlterarSenhaLogado
        [HttpPost]
        public async Task<IActionResult> AlterarSenhaLogado(string AntigaSenha, string confirmarSenha, string novaSenha)
        {
            try
            {
                // Obtém os detalhes do usuário da sessão
                Pessoa pessoaSessao = await _sessao.BuscarSessaoDoUsuario();

                // Verifica se a senha antiga fornecida corresponde à senha atual do usuário
                bool senhaValida = BCrypt.Net.BCrypt.Verify(AntigaSenha, pessoaSessao.Senha);
                if (!senhaValida)
                {
                    throw new Exception("A senha do usuário está incorreta.");
                }

                // Altera a senha do usuário logado com base no perfil
                switch (pessoaSessao.Perfil)
                {
                    case EPerfil.Diretor:
                        await _LoginDiretorService.AlterarSenha((Diretor)pessoaSessao, novaSenha);
                        return RedirectToAction("Index", "Diretor");
                    case EPerfil.Docente:
                        await _LoginDocenteService.AlterarSenha((Docente)pessoaSessao, novaSenha);
                        return RedirectToAction("Index", "Docente");
                    case EPerfil.Aluno:
                        await _LoginAlunoService.AlterarSenha((Aluno)pessoaSessao, novaSenha);
                        return RedirectToAction("Index", "Aluno");
                    default:
                        throw new Exception("Perfil de usuário inválido");
                }
            }
            catch (Exception erro)
            {
                // Em caso de erro, exibe a mensagem de erro e recarrega a página de alteração de senha
                TempData["MensagemErro"] = erro.Message;
                ViewBag.PerfilId = new SelectList(Enum.GetValues(typeof(EPerfil)));
                return View("AlterarSenha", (AntigaSenha, novaSenha, confirmarSenha));
            }
        }

        // GET: LoginController/EsqueciSenha
        public IActionResult EsqueciSenha()
        {
            // Retorna a visualização para redefinir a senha esquecida
            ViewBag.PerfilId = new SelectList(Enum.GetValues(typeof(EPerfil)));
            return View("PrimeiroLogin");
        }

        // POST: LoginController/PrimeiroLogin
        [HttpPost]
        public async Task<IActionResult> PrimeiroLogin(int perfil, string email)
        {
            try
            {
                // Verifica o perfil do usuário e envia um código de recuperação para o e-mail
                EPerfil perfilUsuario = (EPerfil)perfil;
                switch (perfilUsuario)
                {
                    case EPerfil.Diretor:
                        await _LoginDiretorService.BuscarPorEmail(email);
                        break;
                    case EPerfil.Docente:
                        await _LoginDocenteService.BuscarPorEmail(email);
                        break;
                    case EPerfil.Aluno:
                        await _LoginAlunoService.BuscarPorEmail(email);
                        break;
                    default:
                        throw new Exception("E-mail do usuário inválido");
                }
                int codigo = await _VerificadorDeCodigoService.GerarCodigo();

                await _emailService.SendEmailAsync(email,
                    "Código de Recuperação",
                    $"Seu código de recuperação é: {codigo} \n Código válido por 10 minutos.");

                await _VerificadorDeCodigoService.GuardarEmailCache(email);

                TempData["MensagemSucessoEnvio"] = "Encaminhamos um código de recuperação para o seu e-mail";
                return RedirectToAction("ConfirmacaoCodigo");
            }
            catch (Exception)
            {
                // Em caso de erro, exibe a mensagem de erro e recarrega a página de redefinição de senha
                TempData["MensagemEmailNaoEncontrado"] = "Não encontramos o e-mail informado. Verifique as informações ou entre em contato com o seu administrador.";
                return View("PrimeiroLogin");
            }
        }

        // GET: LoginController/ConfirmacaoCodigo
        public IActionResult ConfirmacaoCodigo()
        {
            // Retorna a visualização para confirmar o código de recuperação
            return View();
        }

        // POST: LoginController/ConfirmacaoCodigoAsync
        [HttpPost]
        public async Task<IActionResult> ConfirmacaoCodigoAsync(string codigo)
        {
            // Valida o código de recuperação e redireciona para a página de alteração de senha
            var codigoIgual = await _VerificadorDeCodigoService.ValidarCodigoEnviado(codigo);

            if (codigoIgual)
            {
                return RedirectToAction("AlterarSenha");
            }

            TempData["CodigoIncorreto"] = "O código informado não corresponde ao enviado para o seu e-mail. Tente novamente.";

            return View();
        }

        // POST: LoginController/AlterarSenha
        [HttpPost]
        public async Task<IActionResult> AlterarSenha(string NovaSenha, string ConfirmarNovaSenha)
        {
            try
            {
                // Verifica se as senhas fornecidas correspondem
                if (NovaSenha != ConfirmarNovaSenha)
                {
                    ModelState.AddModelError("ConfirmarNovaSenha", "As senhas não correspondem.");
                    return View();
                }

                // Recupera o e-mail e o perfil do usuário da sessão
                var email = await _VerificadorDeCodigoService.RecuperarEmailCache();
                var perfilUsuario = await _VerificadorDeCodigoService.RecuperarPerfilCache();

                if (email == null || perfilUsuario == 0)
                {
                    throw new Exception("Falha ao recuperar o e-mail ou perfil do usuário.");
                }

                // Altera a senha do usuário com base no perfil
                switch ((EPerfil)perfilUsuario)
                {
                    case EPerfil.Diretor:
                        var diretorService = await _LoginDiretorService.BuscarPorEmail(email);
                        diretorService.Senha = BCrypt.Net.BCrypt.HashPassword(NovaSenha);
                        await _diretorService.Editar(diretorService);
                        break;
                    case EPerfil.Docente:
                        var docenteService = await _LoginDocenteService.BuscarPorEmail(email);
                        docenteService.Senha = BCrypt.Net.BCrypt.HashPassword(NovaSenha);
                        await _docenteService.Editar(docenteService);
                        break;
                    case EPerfil.Aluno:
                        var alunoService = await _LoginAlunoService.BuscarPorEmail(email);
                        alunoService.Senha = BCrypt.Net.BCrypt.HashPassword(NovaSenha);
                        await _alunoService.Editar(alunoService);
                        break;
                    default:
                        throw new Exception("E-mail do usuário inválido");
                }

                TempData["SenhaAlterada"] = "Sua senha foi alterada com sucesso!";
                return RedirectToAction("Index", "Login");
            }
            catch (Exception msg)
            {
                throw new Exception(msg.Message);
            }
        }

    }
}
