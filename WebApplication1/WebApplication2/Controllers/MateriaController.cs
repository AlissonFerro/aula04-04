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

        public IActionResult Descricao(int Id)
        {
            bool resultado = false;
            for(int i = 0; i < Materia.listagemMaterias.Count; i++)
            {
                if(Id == Materia.listagemMaterias[i].Id && Materia.listagemMaterias[i].Ativo == true)
                {
                    resultado = true;
                }
            }
            if (!resultado)
            {
                return View("Erro", "Materia não encontrada");
            }
            Materia materiaEncontrada = Materia.listagemMaterias[Id-1];
            return View("Descricao", materiaEncontrada);
        }

        public IActionResult Formulario()
        {
            return View();
        }

        public IActionResult Adicionar(Materia materia)
        {
            //if (!ModelState.IsValid)
            if(materia.CargaHorario<5)
            {
                return View("Formulario");
            }
            for (int i = 0; i < Materia.listagemMaterias.Count; i++)
            {
                if(Materia.listagemMaterias[i].Name == materia.Name)
                {
                    return Content("Disciplina já cadastrada");
                }
            }
            if(materia.Id == 0)
            {
                materia.Id = Materia.listagemMaterias.Count + 1;
                materia.Ativo = true;
                Materia.listagemMaterias.Add(materia);
                return View("Listagem", Materia.listagemMaterias);
            }
            else
            {
                Materia materiaAtualizada = Materia.listagemMaterias[materia.Id-1];
                materiaAtualizada.Ativo = true;
                materiaAtualizada.Descricao = materia.Descricao;
                materiaAtualizada.Professor = materia.Professor;
                materiaAtualizada.CargaHorario = materia.CargaHorario;
                materiaAtualizada.Name = materia.Name;
                Materia.listagemMaterias[materia.Id-1] = materiaAtualizada;
                return View("Listagem", Materia.listagemMaterias);
            }
            
        } 
    }
}
