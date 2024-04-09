using Edu_Station.Models;
using Edu_Station.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Edu_Station.Controllers
{
    public class DiretorController : Controller
    {
        private readonly ICRUDService<Diretor> _service;
        private readonly ICRUDService<Docente> _docenteService;
        private readonly ICRUDService<Turma> _turmaService;
        private readonly ICRUDService<Disciplina> _disciplinaService;

        public DiretorController(ICRUDService<Diretor> service, ICRUDService<Docente> docenteService, ICRUDService<Turma> turmaService, ICRUDService<Disciplina> disciplinaService)
        {
            _service = service;
            _docenteService = docenteService;
            _turmaService = turmaService;
            _disciplinaService = disciplinaService;
        }

        public async Task<ActionResult> Index()
        {
            var Diretors = await _service.GetAll();
            return View(Diretors);
        }

        public async Task<ActionResult> Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Criar(Diretor CriarDiretor)
        {
            try
            {
                await _service.Adicionar(CriarDiretor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(CriarDiretor);
            }
        }

        public async Task<ActionResult> Editar(Guid id)
        {
            Diretor DiretorDb = await _service.Buscar(id);

            return View(DiretorDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Diretor editarDiretor)
        {
            try
            {
                Diretor DiretorDb = await _service.Editar(editarDiretor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(editarDiretor);
            }
        }

        public async Task<ActionResult> Deletar(Guid id)
        {
            Diretor DiretorDb = await _service.Buscar(id);
            return View(DiretorDb);
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
