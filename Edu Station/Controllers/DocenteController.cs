using Edu_Station.Models;
using Edu_Station.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edu_Station.Controllers
{
    public class DocenteController : Controller
    {
        private readonly ICRUDService<Docente> _service;
        private readonly ICRUDService<Docente> _docenteService;
        private readonly ICRUDService<Turma> _turmaService;
        private readonly ICRUDService<Disciplina> _disciplinaService;

        public DocenteController(ICRUDService<Docente> service, ICRUDService<Docente> docenteService, ICRUDService<Turma> turmaService, ICRUDService<Disciplina> disciplinaService)
        {
            _service = service;
            _docenteService = docenteService;
            _turmaService = turmaService;
            _disciplinaService = disciplinaService;
        }

        public async Task<ActionResult> Index()
        {
            var Docentes = await _service.GetAll();
            return View(Docentes);
        }

        public async Task<ActionResult> Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Criar(Docente CriarDocente)
        {
            try
            {
                await _service.Adicionar(CriarDocente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(CriarDocente);
            }
        }

        public async Task<ActionResult> Editar(Guid id)
        {
            Docente DocenteDb = await _service.Buscar(id);

            return View(DocenteDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Docente editarDocente)
        {
            try
            {
                Docente DocenteDb = await _service.Editar(editarDocente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(editarDocente);
            }
        }

        public async Task<ActionResult> Deletar(Guid id)
        {
            Docente DocenteDb = await _service.Buscar(id);
            return View(DocenteDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _service.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
