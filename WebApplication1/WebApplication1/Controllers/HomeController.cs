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

        //Carrega o formulario
        [HttpGet] //Pegar os dados
        public IActionResult Formulario()
        {
            return View();
        }

        [HttpPost] //Enviar os dados
        public void Formulario(Resposta resposta)
        {
            if (resposta.Name == null && resposta.Name == "" || resposta.Email == null)
            {
                Response.Redirect("Formulario");
            }
            else
            {
                if (BancoDados.VerificaContem(resposta.Email))
                {
                    Response.Redirect("Formulario");
                    return;
                }

                BancoDados.respostas.Add(resposta);
                Response.Redirect("Resultado");

            }
        }

        public IActionResult Resultado()
        {
            return View("Resultado", BancoDados.respostas);
        }


        [HttpGet]
        public IActionResult Excluir()
        {
            return View();
        }

        [HttpPost]
        public void Excluir(Resposta resposta)
        {
            int posicao = -1;
            for (int i = 0; i < BancoDados.respostas.Count; i++)
            {
                if (BancoDados.respostas[i].Email == resposta.Email && BancoDados.respostas[i].Name == resposta.Name)
                {
                    posicao = i;
                }
            }
            if (posicao == -1)
            {
                Response.Redirect("Excluir");
            }
            else
            {
                BancoDados.respostas.RemoveAt(posicao);

            }
            Response.Redirect("Resultado");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}