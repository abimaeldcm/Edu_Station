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

        // GET: Docente/Index
        public async Task<ActionResult> Index()
        {
            // Obtém todos os docentes do serviço
            var Docentes = await _service.GetAll();
            // Retorna a visualização dos docentes
            return View(Docentes);
        }

        // GET: Docente/Criar
        public async Task<ActionResult> Criar()
        {
            // Retorna a visualização para criar um novo docente
            return View();
        }

        // POST: Docente/Criar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Criar(Docente CriarDocente)
        {
            try
            {
                // Adiciona o novo docente usando o serviço
                await _service.Adicionar(CriarDocente);
                // Redireciona para a página Index após a criação bem-sucedida
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // Se houver erros, recarrega a visualização com os dados fornecidos e exibe os erros
                return View(CriarDocente);
            }
        }

        // GET: Docente/Editar/5
        public async Task<ActionResult> Editar(Guid id)
        {
            // Obtém o docente com o ID especificado
            Docente DocenteDb = await _service.Buscar(id);
            // Retorna a visualização para editar o docente
            return View(DocenteDb);
        }

        // POST: Docente/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Docente editarDocente)
        {
            try
            {
                // Atualiza o docente usando o serviço
                Docente DocenteDb = await _service.Editar(editarDocente);
                // Redireciona para a página Index após a edição bem-sucedida
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // Se houver erros, recarrega a visualização com os dados fornecidos e exibe os erros
                return View(editarDocente);
            }
        }

        // GET: Docente/Deletar/5
        public async Task<ActionResult> Deletar(Guid id)
        {
            // Obtém o docente com o ID especificado para confirmar a exclusão
            Docente DocenteDb = await _service.Buscar(id);
            // Retorna a visualização para confirmar a exclusão do docente
            return View(DocenteDb);
        }

        // POST: Docente/Deletar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                // Exclui o docente com o ID especificado usando o serviço
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
