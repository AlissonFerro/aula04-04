using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class LivroController : Controller
    {
        public IActionResult ListarLivros()
        {
            return View("Listagem", Livro.ListaLivros);
        }

        public IActionResult Adicionar(Livro livro)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {
                return View("Formulario");
            }

            for (int i = 0; Livro.ListaLivros.Count > i; i++)
            {
                if (Livro.ListaLivros[i].Nome == livro.Nome && livro.Id != Livro.ListaLivros[i].Id)
                {
                    string resposta = "Aluno já cadastrado";
                    return Content(resposta);
                }
            }
            if (livro.Id == 0)
            {
                livro.Id = Livro.ListaLivros.Count + 1;
                Livro.ListaLivros.Add(livro);
                TempData["Alterado"] = true;
                TempData["Mensagem"] = "Livro cadastrado com sucesso";
                return View("Listagem", Livro.ListaLivros);
            }
            else
            {
                Livro livroAtualizado = Livro.ListaLivros[livro.Id - 1];
                livroAtualizado.Nome = livro.Nome;
                livroAtualizado.Preco = livro.Preco;
                livroAtualizado.QtdPag = livro.QtdPag;
                TempData["Alterado"] = true;
                TempData["Mensagem"] = "Livro alterado com sucesso";
                Livro.ListaLivros[livro.Id - 1] = livroAtualizado;
                return View("Listagem", Livro.ListaLivros);
            }
        }

        public IActionResult Formulario()
        {
            return View();
        }

        public IActionResult FormularioEditar(int id)
        {
            bool resultado = false;
            for (int i = 0; i < Livro.ListaLivros.Count; i++)
            {
                if (Livro.ListaLivros[i].Id == id && Livro.ListaLivros[i].Ativo == true)
                {
                    resultado = true;
                }
            }
            if (!resultado)
            {
                return View("Erro", "Livro não encontrado");
            }

            Livro livroEncontrado = Livro.ListaLivros[id - 1];
            ViewBag.Name = "Editar Livro";
            return View("Formulario", livroEncontrado);
        }

        public IActionResult FormularioExcluir(int id)
        {
            bool resultado = false;
            for (int i = 0; i < Livro.ListaLivros.Count; i++)
            {
                if (Livro.ListaLivros[i].Id == id && Livro.ListaLivros[i].Ativo == true)
                {
                    resultado = true;
                }
            }
            if (!resultado)
            {
                string resposta = "Livro não encontrado";
                return View("Erro", resposta);
            }

            Livro livroEncontrado = Livro.ListaLivros[id - 1];
            ViewBag.Name = "Excluir Aluno";
            return View("FormularioExcluir", livroEncontrado);
        }

        public IActionResult Excluir(int id)
        {
            TempData["Alterado"] = true;
            TempData["Mensagem"] = "Livro excluido com sucesso";
            Livro.ListaLivros[id - 1].Ativo = false;
            return RedirectToAction("ListarLivros");
        }
    }
}
