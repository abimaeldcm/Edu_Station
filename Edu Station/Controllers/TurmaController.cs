using Edu_Station.Models;
using Edu_Station.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Edu_Station.Controllers
{
    public class TurmaController : Controller
    {
        private readonly ICRUDService<Turma> _service;

        public TurmaController(ICRUDService<Turma> service)
        {
            _service = service;
        }

        public async Task<ActionResult> Index()
        {
            var Turmas = await _service.GetAll();
            return View(Turmas);
        }

        public async Task<ActionResult> Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Criar(Turma CriarTurma)
        {
            try
            {
                await _service.Adicionar(CriarTurma);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(CriarTurma);
            }
        }

        public async Task<ActionResult> Editar(Guid id)
        {
            Turma TurmaDb = await _service.Buscar(id);

            return View(TurmaDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Turma editarTurma)
        {
            try
            {
                Turma TurmaDb = await _service.Editar(editarTurma);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(editarTurma);
            }
        }

        public async Task<ActionResult> Deletar(Guid id)
        {
            Turma TurmaDb = await _service.Buscar(id);
            return View(TurmaDb);
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
