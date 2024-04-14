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

        // GET: Disciplina/Index
        public async Task<ActionResult> Index()
        {
            // Obtém todas as disciplinas do serviço
            var Disciplinas = await _service.GetAll();
            // Retorna a visualização das disciplinas
            return View(Disciplinas);
        }

        // GET: Disciplina/Criar
        public async Task<ActionResult> Criar()
        {
            // Obtém todos os docentes e os ordena por nome para exibir na lista suspensa
            ViewBag.DocenteId = new SelectList((await _docenteService.GetAll()).OrderBy(s => s.NomeCompleto), "Id", "NomeCompleto");
            // Retorna a visualização para criar uma nova disciplina
            return View();
        }

        // POST: Disciplina/Criar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Criar(Disciplina CriarDisciplina)
        {
            try
            {
                // Adiciona a nova disciplina usando o serviço
                await _service.Adicionar(CriarDisciplina);
                // Redireciona para a página Index após a criação bem-sucedida
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // Se houver erros, recarrega a visualização com os dados fornecidos e exibe os erros
                ViewBag.DocenteId = new SelectList((await _docenteService.GetAll()).OrderBy(s => s.NomeCompleto), "Id", "NomeCompleto");
                return View(CriarDisciplina);
            }
        }

        // GET: Disciplina/Editar/5
        public async Task<ActionResult> Editar(Guid id)
        {
            // Obtém a disciplina com o ID especificado
            Disciplina DisciplinaDb = await _service.Buscar(id);
            // Obtém todos os docentes para exibição na lista suspensa
            ViewBag.DocenteId = new SelectList((await _docenteService.GetAll()).OrderBy(s => s.NomeCompleto), "Id", "NomeCompleto");
            // Retorna a visualização para editar a disciplina
            return View(DisciplinaDb);
        }

        // POST: Disciplina/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Disciplina editarDisciplina)
        {
            try
            {
                // Atualiza a disciplina usando o serviço
                Disciplina DisciplinaDb = await _service.Editar(editarDisciplina);
                // Redireciona para a página Index após a edição bem-sucedida
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // Se houver erros, recarrega a visualização com os dados fornecidos e exibe os erros
                ViewBag.DocenteId = new SelectList((await _docenteService.GetAll()).OrderBy(s => s.NomeCompleto), "Id", "NomeCompleto");
                return View(editarDisciplina);
            }
        }

        // GET: Disciplina/Deletar/5
        public async Task<ActionResult> Deletar(Guid id)
        {
            // Obtém a disciplina com o ID especificado para confirmar a exclusão
            Disciplina DisciplinaDb = await _service.Buscar(id);
            // Retorna a visualização para confirmar a exclusão da disciplina
            return View(DisciplinaDb);
        }

        // POST: Disciplina/Deletar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                // Exclui a disciplina com o ID especificado usando o serviço
                await _service.Delete(id);
                // Redireciona para a página Index após a exclusão bem-sucedida
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // Se houver erros, retorna a visualização atual
                return View();
            }
        }
    }
}
