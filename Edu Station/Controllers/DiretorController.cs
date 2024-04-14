using Edu_Station.Models;
using Edu_Station.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Edu_Station.Controllers
{
    public class DiretorController : Controller
    {
        // Declaração dos serviços e dependências necessárias
        private readonly ICRUDService<Diretor> _service;
        private readonly ICRUDService<Docente> _docenteService;
        private readonly ICRUDService<Turma> _turmaService;
        private readonly ICRUDService<Disciplina> _disciplinaService;

        // Construtor que injeta as dependências necessárias
        public DiretorController(ICRUDService<Diretor> service, ICRUDService<Docente> docenteService, ICRUDService<Turma> turmaService, ICRUDService<Disciplina> disciplinaService)
        {
            _service = service;
            _docenteService = docenteService;
            _turmaService = turmaService;
            _disciplinaService = disciplinaService;
        }

        // GET: DiretorController/Index
        public async Task<ActionResult> Index()
        {
            // Obtém todos os diretores e os retorna para a visualização
            var Diretors = await _service.GetAll();
            return View(Diretors);
        }

        // GET: DiretorController/Criar
        public async Task<ActionResult> Criar()
        {
            // Retorna a visualização para criar um novo diretor
            return View();
        }

        // POST: DiretorController/Criar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Criar(Diretor CriarDiretor)
        {
            try
            {
                // Adiciona um novo diretor e redireciona para a página de índice
                await _service.Adicionar(CriarDiretor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // Em caso de erro, retorna a visualização de criação com os dados fornecidos
                return View(CriarDiretor);
            }
        }

        // GET: DiretorController/Editar
        public async Task<ActionResult> Editar(Guid id)
        {
            // Busca o diretor pelo ID e retorna a visualização para edição
            Diretor DiretorDb = await _service.Buscar(id);
            return View(DiretorDb);
        }

        // POST: DiretorController/Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Diretor editarDiretor)
        {
            try
            {
                // Edita o diretor com os dados fornecidos e redireciona para a página de índice
                Diretor DiretorDb = await _service.Editar(editarDiretor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // Em caso de erro, retorna a visualização de edição com os dados fornecidos
                return View(editarDiretor);
            }
        }

        // GET: DiretorController/Deletar
        public async Task<ActionResult> Deletar(Guid id)
        {
            // Busca o diretor pelo ID e retorna a visualização para confirmação de exclusão
            Diretor DiretorDb = await _service.Buscar(id);
            return View(DiretorDb);
        }

        // POST: DiretorController/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                // Exclui o diretor pelo ID e redireciona para a página de índice
                await _service.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // Em caso de erro, retorna a visualização padrão
                return View();
            }
        }
    }
}
