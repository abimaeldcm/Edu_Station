using Edu_Station.Models;
using Edu_Station.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Edu_Station.Controllers
{
    public class AlunoController : Controller
    {
        private readonly ICRUDService<Aluno> _service;
        private readonly ICRUDService<Diretor> _diretorService;
        private readonly ICRUDService<Docente> _docenteService;
        private readonly ICRUDService<Turma> _turmaService;
        private readonly ICRUDService<Disciplina> _disciplinaService;

        public AlunoController(ICRUDService<Aluno> service, ICRUDService<Diretor> diretorService, ICRUDService<Docente> docenteService, ICRUDService<Turma> turmaService, ICRUDService<Disciplina> disciplinaService)
        {
            _service = service;
            _diretorService = diretorService;
            _docenteService = docenteService;
            _turmaService = turmaService;
            _disciplinaService = disciplinaService;
        }

        public async Task<ActionResult> Index()
        {
            var alunos = await _service.GetAll();
            return View(alunos);
        }

        public async Task<ActionResult> Criar()
        {
            ViewBag.TurmaId = new SelectList((await _turmaService.GetAll()).OrderBy(s => s.Nome), "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Criar(Aluno CriarAluno)
        {
            try
            {
                await _service.Adicionar(CriarAluno);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(CriarAluno);
            }
        }

        public async Task<ActionResult> Editar(Guid id)
        {
            Aluno alunoDb = await _service.Buscar(id);
            ViewBag.TurmaId = new SelectList((await _turmaService.GetAll()).OrderBy(s => s.Nome), "Id", "Nome");

            return View(alunoDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Aluno editarAluno)
        {
            try
            {
                Aluno alunoDb = await _service.Editar(editarAluno);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.TurmaId = new SelectList((await _turmaService.GetAll()).OrderBy(s => s.Nome), "Id", "Nome");
                return View(editarAluno);
            }
        }

        public async Task<ActionResult> Deletar(Guid id)
        {
            Aluno alunoDb = await _service.Buscar(id);
            return View(alunoDb);
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
