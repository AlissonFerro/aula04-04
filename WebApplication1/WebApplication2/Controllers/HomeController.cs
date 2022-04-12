using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Listar()
        {
            return View("Listagem",Aluno.listagem);
        }

        public void Adicionar(Aluno aluno)
        { 
            aluno.Id = Aluno.listagem.Count +1;            
            Aluno.listagem.Add(aluno);
            Response.Redirect("Index");
        }

        public IActionResult Formulario()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}