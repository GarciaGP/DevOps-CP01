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
                _context.Add(cartao);
                _context.Cartoes.Add(cartao);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index");
        }


        private void CarregarClientes()
        {
            //Carregar as opções de cores do select
            this.clientes = _context.Clientes.ToList();
            ViewBag.clientes = new SelectList(clientes, nameof(Cliente.Id), nameof(Cliente.Nome));
        }
    }
}
