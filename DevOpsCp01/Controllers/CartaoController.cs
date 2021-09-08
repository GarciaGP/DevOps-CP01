using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevOpsCp01.Data;
using DevOpsCp01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace DevOpsCp01.Controllers
{
    public class CartaoController : Controller
    {
        private readonly DevOpsCp01Context _context;
        private IList<Cliente> clientes = new List<Cliente>();
        private bool modoEdicao = false;

        public CartaoController(DevOpsCp01Context context)
        {
            _context = context;
        }

        public IActionResult IndexEdicao(int id)
        {
            var cartao = _context.Cartoes.Find(id);
            TempData["cartao"] = id;
            return RedirectToAction("Index", cartao);
        }

        public IActionResult Index(Cartao cartao)
        {
            if (cartao.Id != default)
            {
                modoEdicao = true;
                ViewBag.edicao = true;
            }

            CarregarClientes();
            return View(cartao);
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar(Cartao cartao)
        {

            var retorno = "";
            try
            {
                if (TempData["cartao"] != null)
                {
                    var valor = cartao.Limite;
                    cartao = await _context.Cartoes.FindAsync((int)TempData["cartao"]);
                    cartao.Limite = valor;
                    _context.Cartoes.Update(cartao);
                    TempData["mensagem"] = "Limite do cartão atualizado!";
                    retorno = "Consultar";
                }
                else
                {
                    _context.Cartoes.Add(cartao);
                    TempData["mensagem"] = "Contrato de cartão cadastrado!";
                    retorno = "Index";
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                TempData["mensagem"] = "Ops! Alguma coisa deu errado.";
            }
            return RedirectToAction(retorno);
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
