using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MateriaController : Controller
    {
        private readonly EscolaContext _context;
        public MateriaController(EscolaContext context)
        {
            _context = context;
        }
        public IActionResult ListarMaterias()
        {
            return View("Listagem", _context.Materias.ToList());
        }
        
        
        public IActionResult Descricao(int Id)
        {
            Materia materiaEncontrada = new Materia();
            materiaEncontrada = _context.Materias.FirstOrDefault(a => a.Id == Id);
            if(materiaEncontrada == null)
            {
                return View("Erro", "Disciplina não encontrada");
            }
            return View("Descricao", materiaEncontrada);
        }
              
        public IActionResult Formulario()
        {
            ViewBag.Botao = "Adicionar";
            return View();
        }
        

        
        public IActionResult Adicionar(Materia materia)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {
                return View("Formulario");
            }
            Materia materiaEncontrada = new Materia();
            materiaEncontrada = _context.Materias.FirstOrDefault(a => a.Id == materia.Id);
            if(materiaEncontrada == null)
            {
                _context.Materias.Add(materia);
                _context.SaveChanges();
                TempData["Alterado"] = 1;
                TempData["Mensagem"] = "Disciplina cadastrado com sucesso";
                return View("Listagem", _context.Materias.ToList());
            }
            else
            {
                materia.Ativo = true;
                _context.Entry(materiaEncontrada).CurrentValues.SetValues(materia);
                _context.SaveChanges();
                TempData["Alterado"] = 2;
                TempData["Mensagem"] = "Disciplina alterada com sucesso";
                return View("Listagem", _context.Materias.ToList());
            }
        }

        public IActionResult AtualizarInativo(int id)
        {
            Materia materiaEncontrado = new Materia();
            materiaEncontrado = _context.Materias.FirstOrDefault(a => a.Id == id);

            Materia materia = new Materia();
            materia = materiaEncontrado;
            materia.Ativo = true;

            _context.Entry(materiaEncontrado).CurrentValues.SetValues(materia);
            _context.SaveChanges();
            return RedirectToAction("ListarMaterias");
        }

        public IActionResult FormularioEditar(int id)
        {
            Materia materiaEncontrada = new Materia();
            materiaEncontrada = _context.Materias.FirstOrDefault(a => a.Id == id);
            if (materiaEncontrada.Ativo == false)
            {
                return View("AtualizarInativo", materiaEncontrada);
            }
            if (materiaEncontrada == null || materiaEncontrada.Ativo == false)
            {
                return View("Erro", "Disciplina não encontrada");
            }
            ViewBag.Name = "Editar Disciplina";
            ViewBag.Botao = "Editar";
            return View("Formulario", materiaEncontrada);
        }        

        
        public IActionResult FormularioExcluir(int id)
        {
            Materia materiaEncontrada = new Materia();
            materiaEncontrada = _context.Materias.FirstOrDefault(a => a.Id == id);
            if(materiaEncontrada == null || materiaEncontrada.Ativo == false)
            {
                string resposta = "Disciplina não encontrada";
                return View("Erro", resposta);
            }

            ViewBag.Name = "Excluir Disciplina";
            return View("FormularioExcluir", materiaEncontrada);
        }
        

        
        public IActionResult Excluir(int id)
        {
            TempData["Alterado"] = 3;
            TempData["Mensagem"] = "Matéria excluida com sucesso";

            Materia materiaEncontrada = new Materia();
            materiaEncontrada = _context.Materias.FirstOrDefault(a => a.Id == id);

            Materia materia = new Materia();
            materia = materiaEncontrada;
            materia.Ativo = false;

            _context.Entry(materiaEncontrada).CurrentValues.SetValues(materia);
            _context.SaveChanges();
            return RedirectToAction("ListarMaterias");
        }
        
    }
}
