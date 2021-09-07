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

        public IActionResult Index()
        {
            CarregarClientes();
            return View();
        }

        public IActionResult Cadastrar(Cartao cartao)
        {
            // cartao.IdCliente = clientes.First(x => x.)
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

    }
}
