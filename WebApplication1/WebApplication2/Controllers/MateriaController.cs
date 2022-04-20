using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MateriaController : Controller
    {
        public IActionResult ListarMaterias()
        {
            return View("Listagem", Materia.listagemMaterias);
        }
        /*
        public void Index()
        {
            return RedirectToAction(HomeController.Index());
        }*/
    }
}
