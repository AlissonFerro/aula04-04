using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class LigacaoController : Controller
    {
        private readonly EscolaContext _context;

        public LigacaoController(EscolaContext context)
        {
            _context = context;
        }
        public IActionResult ListarLigacoes()
        {
            return View("Listagem", _context.Ligacao.ToList());
        }

        public IActionResult Adicionar(Ligacao ligacao)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {
                return View("Formulario");
            }

            Ligacao ligacaoEncontrada = new Ligacao();
            ligacaoEncontrada = _context.Ligacao.FirstOrDefault(a => a.Id == ligacao.Id);
            if(ligacaoEncontrada == null)
            {
                _context.Ligacao.Add(ligacao);
                _context.SaveChanges();
                TempData["Alterado"] = 1;
                TempData["Mensagem"] = "Ligação cadastrado com sucesso";
                return View("Listagem", _context.Ligacao.ToList());
            }
            else
            {
                ligacao.Ativo = true;
                _context.Entry(ligacaoEncontrada).CurrentValues.SetValues(ligacao);
                _context.SaveChanges();
                TempData["Alterado"] = 2;
                TempData["Mensagem"] = "Ligação alterada com sucesso";
                return View("Listagem", _context.Ligacao.ToList());
            }

        }

        public IActionResult Formulario()
        {
            ViewBag.Botao = "Adicionar";
            return View();
        }
        
        public IActionResult FormularioEditar(int id)
        {
            Ligacao ligacaoEncontrada = new Ligacao();
            ligacaoEncontrada = _context.Ligacao.FirstOrDefault(a => a.Id == id);
            if(ligacaoEncontrada == null || ligacaoEncontrada.Ativo == false)
            {
                return View("Erro", "Ligação não encontrada");
            }
            ViewBag.Botao = "Editar";
            ViewBag.Name = "Editar Ligação";
            return View("Formulario", ligacaoEncontrada);
        }
        
        public IActionResult FormularioExcluir(int id)
        {
            Ligacao ligacaoEncontrada = new Ligacao();
            ligacaoEncontrada = _context.Ligacao.FirstOrDefault(a => a.Id == id);
            if(ligacaoEncontrada == null || ligacaoEncontrada.Ativo == false)
            {
                return View("Erro", "Ligação não encontrada");
            }
            ViewBag.Name = "Excluir Ligação";
            return View("FormularioExcluir", ligacaoEncontrada);
        }

        public IActionResult Excluir(int id)
        {
            TempData["Alterado"] = 3;
            TempData["Mensagem"] = "Ligação excluida com sucesso";

            Ligacao ligacaoEncontrada = new Ligacao();
            ligacaoEncontrada = _context.Ligacao.FirstOrDefault(a => a.Id == id);

            Ligacao ligacao = new Ligacao();
            ligacao = ligacaoEncontrada;
            ligacao.Ativo = false;

            _context.Entry(ligacaoEncontrada).CurrentValues.SetValues(ligacao);
            _context.SaveChanges();
            return RedirectToAction("ListarLigacoes");
        }
    }
}
