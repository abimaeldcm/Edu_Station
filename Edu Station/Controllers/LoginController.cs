using Edu_Station.Models;
using Edu_Station.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Edu_Station.Controllers
{
    public class LoginController : Controller
    {
        private readonly ICRUDService<Login> _service;
        private readonly ILoginService _LoginService;

        public LoginController(ICRUDService<Login> service, ILoginService loginService)
        {
            _service = service;
            _LoginService = loginService;
        }

        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }
        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Logar(Login logar)
        {
            try
            {
                Login loginService = await _LoginService.Logar(logar);
                return RedirectToAction("Index", "Home");
            }
            catch(Exception erro)
            {
                TempData["MensagemErro"] = erro.Message;

                return View(logar);
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
        public ActionResult Create(IFormCollection collection)
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
        public ActionResult Edit(int id, IFormCollection collection)
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
        public ActionResult Delete(int id, IFormCollection collection)
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
