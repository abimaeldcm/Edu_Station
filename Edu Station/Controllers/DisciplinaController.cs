using Edu_Station.Models;
using Edu_Station.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Edu_Station.Controllers
{
    public class DisciplinaController : Controller
    {
        private readonly ICRUDService<Disciplina> _service;
        private readonly ICRUDService<Turma> _turmaService;
        private readonly ICRUDService<Disciplina> _disciplinaService;
        private readonly ICRUDService<Docente> _docenteService;

        public DisciplinaController(ICRUDService<Disciplina> service, ICRUDService<Turma> turmaService, ICRUDService<Disciplina> disciplinaService, ICRUDService<Docente> docenteService)
        {
            _service = service;
            _turmaService = turmaService;
            _disciplinaService = disciplinaService;
            _docenteService = docenteService;
        }

        public async Task<ActionResult> Index()
        {
            var Disciplinas = await _service.GetAll();
            return View(Disciplinas);
        }

        public async Task<ActionResult> Criar()
        {
            ViewBag.DocenteId = new SelectList((await _docenteService.GetAll()).OrderBy(s => s.NomeCompleto), "Id", "NomeCompleto");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Criar(Disciplina CriarDisciplina)
        {
            try
            {
                await _service.Adicionar(CriarDisciplina);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.DocenteId = new SelectList((await _docenteService.GetAll()).OrderBy(s => s.NomeCompleto), "Id", "NomeCompleto");
                return View(CriarDisciplina);
            }
        }

        public async Task<ActionResult> Editar(Guid id)
        {
            Disciplina DisciplinaDb = await _service.Buscar(id);
            ViewBag.DocenteId = new SelectList((await _docenteService.GetAll()).OrderBy(s => s.NomeCompleto), "Id", "NomeCompleto");

            return View(DisciplinaDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Disciplina editarDisciplina)
        {
            try
            {
                Disciplina DisciplinaDb = await _service.Editar(editarDisciplina);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.DocenteId = new SelectList((await _docenteService.GetAll()).OrderBy(s => s.NomeCompleto), "Id", "NomeCompleto");
                return View(editarDisciplina);
            }
        }

        public async Task<ActionResult> Deletar(Guid id)
        {
            Disciplina DisciplinaDb = await _service.Buscar(id);
            return View(DisciplinaDb);
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

