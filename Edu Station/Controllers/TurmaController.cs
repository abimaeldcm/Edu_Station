using Edu_Station.Models;
using Edu_Station.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Edu_Station.Controllers
{
    // Controller para lidar com as ações relacionadas às turmas
    public class TurmaController : Controller
    {
        private readonly ICRUDService<Turma> _service; // Serviço CRUD para operações em Turmas

        // Construtor que injeta o serviço CRUD de Turma
        public TurmaController(ICRUDService<Turma> service)
        {
            _service = service;
        }

        // Ação para exibir todas as turmas
        public async Task<ActionResult> Index()
        {
            var Turmas = await _service.GetAll(); // Obtém todas as turmas do serviço
            return View(Turmas); // Retorna a view com as turmas
        }

        // Ação para exibir o formulário de criação de turma
        public async Task<ActionResult> Criar()
        {
            return View(); // Retorna a view de criação de turma
        }

        // Ação para lidar com o POST do formulário de criação de turma
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Criar(Turma CriarTurma)
        {
            try
            {
                await _service.Adicionar(CriarTurma); // Adiciona a nova turma usando o serviço
                return RedirectToAction(nameof(Index)); // Redireciona para a página Index após a criação bem-sucedida
            }
            catch
            {
                return View(CriarTurma); // Se houver erros, retorna a view de criação com os dados inseridos
            }
        }

        // Ação para exibir o formulário de edição de turma
        public async Task<ActionResult> Editar(Guid id)
        {
            Turma TurmaDb = await _service.Buscar(id); // Busca a turma pelo ID
            return View(TurmaDb); // Retorna a view de edição com os dados da turma
        }

        // Ação para lidar com o POST do formulário de edição de turma
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Turma editarTurma)
        {
            try
            {
                Turma TurmaDb = await _service.Editar(editarTurma); // Edita a turma usando o serviço
                return RedirectToAction(nameof(Index)); // Redireciona para a página Index após a edição bem-sucedida
            }
            catch
            {
                return View(editarTurma); // Se houver erros, retorna a view de edição com os dados inseridos
            }
        }

        // Ação para exibir a página de confirmação de exclusão de turma
        public async Task<ActionResult> Deletar(Guid id)
        {
            Turma TurmaDb = await _service.Buscar(id); // Busca a turma pelo ID
            return View(TurmaDb); // Retorna a view de exclusão com os dados da turma
        }

        // Ação para lidar com a exclusão de turma
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _service.Delete(id); // Exclui a turma usando o serviço
                return RedirectToAction(nameof(Index)); // Redireciona para a página Index após a exclusão bem-sucedida
            }
            catch
            {
                return View(); // Se houver erros, retorna a view atual
            }
        }
    }
}
