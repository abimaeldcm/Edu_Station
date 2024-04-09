using Edu_Station.Helpers;
using Edu_Station.Models;
using Edu_Station.Models.Enum;
using Edu_Station.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace Edu_Station.Controllers
{
    public class LoginController : Controller
    {
        private readonly ICRUDService<Login> _service;
        private readonly ILoginService<Diretor, Login> _LoginDiretorService;
        private readonly ILoginService<Docente, Login> _LoginDocenteService;
        private readonly ILoginService<Aluno, Login> _LoginAlunoService;
        private readonly ICRUDService<Diretor> _diretorService;
        private readonly ICRUDService<Docente> _docenteService;
        private readonly ICRUDService<Aluno> _alunoService;

        private readonly IEmailService _emailService;
        private readonly IVerficadorCodigo _VerificadorDeCodigoService;

        public LoginController(ICRUDService<Login> service,
                                ILoginService<Diretor, Login> loginDiretorService,
                                ILoginService<Docente, Login> loginDocenteService,
                                ILoginService<Aluno, Login> loginAlunoService,
                                ICRUDService<Diretor> diretorAlunoService,
                                ICRUDService<Docente> docenteService,
                                ICRUDService<Aluno> alunoService,
                                IEmailService emailService,
                                IVerficadorCodigo verificadorDeCodigoService)
        {
            _service = service;
            _LoginDiretorService = loginDiretorService;
            _LoginDocenteService = loginDocenteService;
            _LoginAlunoService = loginAlunoService;
            _diretorService = diretorAlunoService;
            _docenteService = docenteService;
            _alunoService = alunoService;
            _emailService = emailService;
            _VerificadorDeCodigoService = verificadorDeCodigoService;
        }




        // GET: LoginController
        public ActionResult Index()
        {
            ViewBag.PerfilId = new SelectList(Enum.GetValues(typeof(EPerfil)));
            return View();
        }
        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Logar(Login logar)
        {
            try
            {
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
                TempData["MensagemErro"] = erro.Message;
                ViewBag.PerfilId = new SelectList(Enum.GetValues(typeof(EPerfil)));

                return View("Index", logar);
            }
        }
        public IActionResult EsqueciSenha()
        {
            ViewBag.PerfilId = new SelectList(Enum.GetValues(typeof(EPerfil)));
            return View("PrimeiroLogin");
        }

        public IActionResult PrimeiroLogin()
        {
            ViewBag.PerfilId = new SelectList(Enum.GetValues(typeof(EPerfil)));
            return View("PrimeiroLogin");

        }
        [HttpPost]
        public async Task<IActionResult> PrimeiroLogin(int perfil, string email)
        {
            try
            {
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
                TempData["MensagemEmailNaoEncontrado"] = "Não encontramos o e-mail informado. Verifique as informações ou entre em contato com o seu administrador.";
                return View("PrimeiroLogin");
            }

        }


        public IActionResult ConfirmacaoCodigo()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmacaoCodigoAsync(string codigo)
        {
            var codigoIgual = await _VerificadorDeCodigoService.ValidarCodigoEnviado(codigo);

            if (codigoIgual)
            {
                return RedirectToAction("AlterarSenha");
            }

            TempData["CodigoIncorreto"] = "O código informado não corresponde ao enviado para o seu e-mail. Tente novamente.";

            return View();
        }

        public IActionResult AlterarSenha()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AlterarSenha(string NovaSenha, string ConfirmarNovaSenha)
        {
            try
            {
                if (NovaSenha != ConfirmarNovaSenha)
                {
                    ModelState.AddModelError("ConfirmarNovaSenha", "As senhas não correspondem.");
                    return View();
                }

                var email = await _VerificadorDeCodigoService.RecuperarEmailCache();
                var perfilUsuario = await _VerificadorDeCodigoService.RecuperarPerfilCache();

                if (email is null || perfilUsuario is 0)
                {
                    //colocar a excessão aqui
                    return View();
                }

                switch ((EPerfil)perfilUsuario)
                {
                    case EPerfil.Diretor:
                        var diretorService = await _LoginDiretorService.BuscarPorEmail(email);
                        diretorService.Senha = BCrypt.Net.BCrypt.HashPassword(NovaSenha);
                        _diretorService.Editar(diretorService);
                        break;
                    case EPerfil.Docente:
                        var docenteService = await _LoginDocenteService.BuscarPorEmail(email);
                        docenteService.Senha = BCrypt.Net.BCrypt.HashPassword(NovaSenha);
                        _docenteService.Editar(docenteService);
                        break;
                    case EPerfil.Aluno:
                        var alunoService = await _LoginAlunoService.BuscarPorEmail(email);
                        alunoService.Senha = BCrypt.Net.BCrypt.HashPassword(NovaSenha);
                        _alunoService.Editar(alunoService);
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

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Login login)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Login login)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Login login)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
