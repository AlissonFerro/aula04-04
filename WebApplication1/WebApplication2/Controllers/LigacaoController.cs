using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class LigacaoController : Controller
    {
        public IActionResult ListarLigacoes()
        {
            return View("Listagem", Ligacao.listagem);
        }

        public IActionResult Adicionar(Ligacao ligacao)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {
                return View("Formulario");
            }

            if (ligacao.Id == 0)
            {
                ligacao.Id = Ligacao.listagem.Count + 1;
                ligacao.Ativo = true;
                Ligacao.listagem.Add(ligacao);
                TempData["Alterado"] = 1;
                TempData["Mensagem"] = "Ligação cadastrado com sucesso";
                return View("Listagem", Ligacao.listagem);
            }
            else
            {
                Ligacao ligacaoAtualizado = Ligacao.listagem[ligacao.Id - 1];
                ligacaoAtualizado.NomeAluno = ligacao.NomeAluno;
                ligacaoAtualizado.Assunto = ligacao.Assunto;
                ligacaoAtualizado.Telefone = ligacao.Telefone;
                TempData["Alterado"] = 2;
                TempData["Mensagem"] = "Ligação alterada com sucesso";
                Ligacao.listagem[ligacao.Id - 1] = ligacaoAtualizado;
                return View("Listagem", Ligacao.listagem);
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
                if (Ligacao.listagem[i].Id == id && Ligacao.listagem[i].Ativo == true)
                {
                    resultado = true;
                }
            }
            if (!resultado)
            {
                return View("Erro", "Ligação não encontrada");
            }

            Ligacao ligacoesEncontrado = Ligacao.listagem[id - 1];
            ViewBag.Name = "Editar Livro";
            return View("Formulario", ligacoesEncontrado);
        }

        public IActionResult FormularioExcluir(int id)
        {
            bool resultado = false;
            for (int i = 0; i < Ligacao.listagem.Count; i++)
            {
                if (Ligacao.listagem[i].Id == id && Ligacao.listagem[id].Ativo == true)
                {
                    resultado = true;
                }
            }
            if (!resultado)
            {
                string resposta = "Ligacao não encontrada";
                return View("Erro", resposta);
            }

            Ligacao ligacaoEncontrada = Ligacao.listagem[id - 1];
            ViewBag.Name = "Excluir Ligação";
            return View("FormularioExcluir", ligacaoEncontrada);
        }

        public IActionResult Excluir(int id)
        {
            TempData["Alterado"] = 3;
            TempData["Mensagem"] = "Ligação excluida com sucesso";
            Ligacao.listagem[id - 1].Ativo = false;
            return RedirectToAction("ListarLigacoes");
        }
    }
}
