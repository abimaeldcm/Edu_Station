using Edu_Station.Models;
using Edu_Station.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Edu_Station.Controllers
{
    // Controlador responsável por lidar com as ações relacionadas aos alunos.
    public class AlunoController : Controller
    {
        // Serviços necessários para interagir com os alunos, diretores, docentes, turmas e disciplinas.
        private readonly ICRUDService<Aluno> _service;
        private readonly ICRUDService<Diretor> _diretorService;
        private readonly ICRUDService<Docente> _docenteService;
        private readonly ICRUDService<Turma> _turmaService;
        private readonly ICRUDService<Disciplina> _disciplinaService;

        // Construtor que injeta os serviços necessários.
        public AlunoController(ICRUDService<Aluno> service, ICRUDService<Diretor> diretorService, ICRUDService<Docente> docenteService, ICRUDService<Turma> turmaService, ICRUDService<Disciplina> disciplinaService)
        {
            _service = service;
            _diretorService = diretorService;
            _docenteService = docenteService;
            _turmaService = turmaService;
            _disciplinaService = disciplinaService;
        }

        // Ação para exibir a lista de alunos.
        public async Task<ActionResult> Index()
        {
            var alunos = await _service.GetAll();
            return View(alunos);
        }

        // Ação para exibir o formulário de criação de aluno.
        public async Task<ActionResult> Criar()
        {
            // Carrega as turmas disponíveis para selecionar no formulário.
            ViewBag.TurmaId = new SelectList((await _turmaService.GetAll()).OrderBy(s => s.Nome), "Id", "Nome");
            return View();
        }

        // Ação para processar o formulário de criação de aluno.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Criar(Aluno CriarAluno)
        {
            try
            {
                // Adiciona o aluno ao banco de dados.
                await _service.Adicionar(CriarAluno);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(CriarAluno);
            }
        }

        // Ação para exibir o formulário de edição de aluno.
        public async Task<ActionResult> Editar(Guid id)
        {
            // Busca o aluno pelo ID e carrega as turmas disponíveis para selecionar no formulário.
            Aluno alunoDb = await _service.Buscar(id);
            ViewBag.TurmaId = new SelectList((await _turmaService.GetAll()).OrderBy(s => s.Nome), "Id", "Nome");

            return View(alunoDb);
        }

        // Ação para processar o formulário de edição de aluno.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Aluno editarAluno)
        {
            try
            {
                // Edita o aluno no banco de dados.
                Aluno alunoDb = await _service.Editar(editarAluno);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.TurmaId = new SelectList((await _turmaService.GetAll()).OrderBy(s => s.Nome), "Id", "Nome");
                return View(editarAluno);
            }
        }

        // Ação para exibir o formulário de exclusão de aluno.
        public async Task<ActionResult> Deletar(Guid id)
        {
            // Busca o aluno pelo ID.
            Aluno alunoDb = await _service.Buscar(id);
            return View(alunoDb);
        }

        // Ação para processar a exclusão de aluno.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                // Exclui o aluno do banco de dados.
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
