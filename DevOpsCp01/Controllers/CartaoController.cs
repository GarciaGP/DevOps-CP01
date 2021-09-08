using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevOpsCp01.Data;
using DevOpsCp01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DevOpsCp01.Controllers
{
    public class CartaoController : Controller
    {
        private readonly DevOpsCp01Context _context;
        private IList<Cliente> clientes = new List<Cliente>();

        public CartaoController(DevOpsCp01Context context)
        {
            _context = context;
        }

        public IActionResult IndexEdicao(int id)
        {
            var cartao = _context.Cartoes.Find(id);
            CarregarClientes();
            return RedirectToAction("Index", cartao);
        }

        public IActionResult Index(Cartao cartao)
        {
            if(cartao.Numero != 0 || cartao.Id != default(int))
                ViewBag.edicao = true;

            CarregarClientes();
            return View(cartao);
        }

        public IActionResult Cadastrar(Cartao cartao)
        {
            if(ViewBag.edicao == true)
            {
                return RedirectToAction("Editar", cartao);
            }
               
            try
            {
                _context.Cartoes.Add(cartao);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                TempData["mensagem"] = "Ops! Alguma coisa deu errado.";
            }
            TempData["mensagem"] = "Contrato de cartão cadastrado!";
            return RedirectToAction("Index");
        }

        private void CarregarClientes()
        {
            //Carregar as opções de cores do select
            this.clientes = _context.Clientes.ToList();
            ViewBag.clientes = new SelectList(clientes, nameof(Cliente.Id), nameof(Cliente.Nome));
        }

        public IActionResult Consultar()
        {
            List<Cartao> cartoes = _context.Cartoes.ToList();
             
            foreach (Cartao c in cartoes)
            {
                c.Cliente = _context.Clientes.FirstOrDefault(x => x.Id == c.IdCliente);
            }


            return View(cartoes);
        }

        [HttpPut]
        public IActionResult Editar(Cartao cartao)
        {
            try
            {
                _context.Cartoes.Update(cartao);
                 _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                TempData["mensagem"] = "Ops! Alguma coisa deu errado.";
            }

            TempData["mensagem"] = "Cartão editado!";
            return View("Index", cartao);
        }

        [HttpDelete]
        public IActionResult Excluir(int id)
        { 
            try
            {
                var cartao = _context.Cartoes.Find(id);
                _context.Cartoes.Remove(cartao);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                TempData["mensagem"] = "Ops! Alguma coisa deu errado.";
            }

            TempData["mensagem"] = "Cartão excluído!";
            return RedirectToAction("Consultar");
        }



    }
}
