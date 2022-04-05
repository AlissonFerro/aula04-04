using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
 
        public IActionResult Index()
        {            
            return View();
        }

        [HttpGet] //Pegar os dados
        public IActionResult Pagina()
        {
            return View("Pagina");
        }

        [HttpPost] //Enviar os dados
        public IActionResult Pagina(Resposta resposta)
        {
            BancoDados.respostas.Add(resposta);
            return View("Resultado", BancoDados.respostas);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}