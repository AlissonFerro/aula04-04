using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly EscolaContext _context;

        public HomeController(EscolaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.QtdAlunos = _context.Alunos.Count();
            return View();
        }

        public IActionResult ListarAlunos()
        {
            return View("Listagem", _context.Alunos.ToList());
        }

        
        public ActionResult Adicionar(Aluno aluno)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {
                return View("Formulario");
            }

            Aluno alunoEncontrado = new Aluno();
            alunoEncontrado = _context.Alunos.FirstOrDefault(a => a.Id == aluno.Id) ;

            if(alunoEncontrado == null)
            {
                _context.Alunos.Add(aluno);
                _context.SaveChanges();
                return View("Listagem", _context.Alunos.ToList());
            }
            else
            {
                aluno.Ativo = true;
                _context.Entry(alunoEncontrado).CurrentValues.SetValues(aluno);
                _context.SaveChanges();
                return View("Listagem", _context.Alunos.ToList());
            }
        }

        public IActionResult Formulario()
        {
            return View();
        }
        

        public IActionResult FormularioEditar(int id)
        {
            Aluno alunoEncontrado = new Aluno();
            alunoEncontrado = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (alunoEncontrado == null)
            {
                return View("Erro", "Usuário não encontrado");
            }

            ViewBag.Name = "Editar Aluno";
            return View("Formulario", alunoEncontrado);
        }

        
        public IActionResult FormularioExcluir(int id)
        {
            Aluno alunoEncontrado = new Aluno();
            alunoEncontrado = _context.Alunos.FirstOrDefault(a => a.Id == id);
            
            if (alunoEncontrado == null)
            {
                string resposta = "Usuário não encontrado";
                return View("Erro", resposta);
            }

            ViewBag.Name = "Excluir Aluno";
            return View("FormularioExcluir", alunoEncontrado);
        }
        
        public IActionResult ExcluirAluno(int id)
        {
            TempData["Alterado"] = 3;
            TempData["Mensagem"] = "Aluno excluído com sucesso";

            Aluno alunoEncontrado = new Aluno();
            alunoEncontrado = _context.Alunos.FirstOrDefault(a => a.Id == id);

            Aluno aluno = new Aluno();
            aluno = alunoEncontrado;
            aluno.Ativo = false;

            _context.Entry(alunoEncontrado).CurrentValues.SetValues(aluno);
            _context.SaveChanges();
            return RedirectToAction("ListarAlunos");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}