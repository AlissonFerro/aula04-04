﻿using Microsoft.AspNetCore.Mvc;
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
            return View("Listagem", Aluno.listagem);
        }

        public void Adicionar(Aluno aluno)
        {
            if (aluno.Id == 0)
            {
                aluno.Id = Aluno.listagem.Count + 1;
                aluno.Ativo = true;
                Aluno.listagem.Add(aluno);
                Response.Redirect("Index");
            }
            else
            {
                Aluno alunoAtualizado = Aluno.listagem[aluno.Id-1];
                alunoAtualizado.Name = aluno.Name;
                alunoAtualizado.Curso = aluno.Curso;
                Aluno.listagem[aluno.Id-1] = alunoAtualizado;
                Response.Redirect("Index");
            }
        }

        public IActionResult Formulario()
        {
            return View();
        }

        public IActionResult FormularioEditar(int id)
        {
            Aluno alunoEncontrado = Aluno.listagem[id-1];
            return View("Formulario", alunoEncontrado);
        }

        public IActionResult FormularioExcluir(int id)
        {
            Aluno alunoEncontrado = Aluno.listagem[id - 1];
            return View("FormularioExcluir", alunoEncontrado);
        }

        public IActionResult ExcluirAluno(int id)
        {
            Aluno.listagem[id-1].Ativo = false;
            return RedirectToAction("Listar");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}