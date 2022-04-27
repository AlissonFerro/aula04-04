using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListarAlunos()
        {
            return View("Listagem", Aluno.listagem);
        }


        public ActionResult Adicionar(Aluno aluno)
        {

            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {

                return View("Formulario");
            }

            for (int i = 0; Aluno.listagem.Count > i; i++)
            {
                if (Aluno.listagem[i].Email == aluno.Email && aluno.Id != Aluno.listagem[i].Id)
                {
                    string resposta = "Aluno já cadastrado";
                    return Content(resposta);
                }
            }
            if (aluno.Id == 0)
            {
                aluno.Id = Aluno.listagem.Count + 1;
                aluno.Ativo = true;
                Aluno.listagem.Add(aluno);
                TempData["Alterado"] = true;
                TempData["Mensagem"] = "Aluno cadastrado com sucesso";
                return View("Listagem", Aluno.listagem);
            }
            else
            {
                Aluno alunoAtualizado = Aluno.listagem[aluno.Id - 1];
                alunoAtualizado.Name = aluno.Name;
                alunoAtualizado.Curso = aluno.Curso;
                alunoAtualizado.Idade = aluno.Idade;
                alunoAtualizado.Email = aluno.Email;
                TempData["Alterado"] = true;
                TempData["Mensagem"] = "Aluno alterado com sucesso";
                Aluno.listagem[aluno.Id - 1] = alunoAtualizado;
                return View("Listagem", Aluno.listagem);
            }
        }

        public IActionResult Formulario()
        {

            return View();
        }

        public IActionResult FormularioEditar(int id)
        {
            bool resultado = false;
            for (int i = 0; i < Aluno.listagem.Count; i++)
            {
                if (Aluno.listagem[i].Id == id && Aluno.listagem[i].Ativo == true)
                {
                    resultado = true;
                }
            }
            if (!resultado)
            {
                return View("Erro", "Usuário não encontrado");
            }

            Aluno alunoEncontrado = Aluno.listagem[id - 1];
            ViewBag.Name = "Editar Aluno";
            return View("Formulario", alunoEncontrado);
        }

        public IActionResult FormularioExcluir(int id)
        {
            bool resultado = false;
            for (int i = 0; i < Aluno.listagem.Count; i++)
            {
                if (Aluno.listagem[i].Id == id && Aluno.listagem[i].Ativo == true)
                {
                    resultado = true;
                }
            }
            if (!resultado)
            {
                string resposta = "Usuário não encontrado";
                return View("Erro", resposta);
            }

            Aluno alunoEncontrado = Aluno.listagem[id - 1];
            ViewBag.Name = "Excluir Aluno";
            return View("FormularioExcluir", alunoEncontrado);
        }

        public IActionResult ExcluirAluno(int id)
        {
            TempData["Alterado"] = true;
            TempData["Mensagem"] = "Aluno excluído com sucesso";
            Aluno.listagem[id - 1].Ativo = false;
            return RedirectToAction("ListarAlunos");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}