using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class LivroController : Controller
    {
        private readonly EscolaContext _context;

        public LivroController(EscolaContext context)
        {
            _context = context;
        }

        public IActionResult ListarLivros()
        {
            return View("Listagem", _context.Livros.ToList());
        }
        
        public IActionResult Adicionar(Livro livro)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {
                return View("Formulario");
            }

            Livro livroEncontrado = new Livro();
            livroEncontrado = _context.Livros.FirstOrDefault(a => a.Id == livro.Id);
            if(livroEncontrado == null)
            {
                _context.Livros.Add(livro);
                _context.SaveChanges();
                TempData["Alterado"] = 1;
                TempData["Mensagem"] = "Livro cadastrado com sucesso";
                return View("Listagem", _context.Livros.ToList());
            }
            else
            {
                livro.Ativo = true;
                _context.Entry(livroEncontrado).CurrentValues.SetValues(livro);
                _context.SaveChanges();
                TempData["Alterado"] = 2;
                TempData["Mensagem"] = "Livro alterada com sucesso";
                return View("Listagem", _context.Livros.ToList());
            }
        }

        public IActionResult AtualizarInativo(int id)
        {
            Livro livroEncontrado = new Livro();
            livroEncontrado = _context.Livros.FirstOrDefault(a => a.Id == id);

            Livro livro = new Livro();
            livro = livroEncontrado;
            livro.Ativo = true;

            _context.Entry(livroEncontrado).CurrentValues.SetValues(livro);
            _context.SaveChanges();
            return RedirectToAction("ListarLivros");
        }

        public IActionResult Formulario()
        {
            ViewBag.Botao = "Adicionar";
            return View();
        }

        public IActionResult FormularioEditar(int id)
        {
            Livro livroEncontrado = new Livro();
            livroEncontrado = _context.Livros.FirstOrDefault(a => a.Id == id);
            if (livroEncontrado == null || livroEncontrado.Ativo == false)
            {
                return View("Erro", "Livro não encontrado");
            }
            if (livroEncontrado.Ativo == false)
            {
                return View("AtualizarInativo", livroEncontrado);
            }
            ViewBag.Botao = "Editar";
            ViewBag.Name = "Editar Livro";
            return View("Formulario", livroEncontrado);
        }
        
        public IActionResult FormularioExcluir(int id)
        {
            Livro livroEncontrado = new Livro();
            livroEncontrado = _context.Livros.FirstOrDefault(a => a.Id == id);
            if(livroEncontrado == null || livroEncontrado.Ativo == false)
            {
                return View("Erro", "Livro não encontrado");
            }
            ViewBag.Name = "Excluir Livro";
            return View("FormularioExcluir", livroEncontrado);
        }

        public IActionResult Excluir(int id)
        {
            TempData["Alterado"] = 3;
            TempData["Mensagem"] = "Livro excluido com sucesso";

            Livro livroEncontrado = new Livro();
            livroEncontrado = _context.Livros.FirstOrDefault(a => a.Id == id);

            Livro livro = new Livro();
            livro = livroEncontrado;
            livro.Ativo = false;

            _context.Entry(livroEncontrado).CurrentValues.SetValues(livro);
            _context.SaveChanges();
            return RedirectToAction("ListarLivros");
        }
    }
}
