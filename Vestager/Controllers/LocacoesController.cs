using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vestager.Domain.Entities;
using Vestager.Infra.Data;

namespace Vestager.MVC.Controllers
{
    public class LocacoesController : Controller
    {
        private readonly Context _context;

        public LocacoesController(Context context)
        {
            _context = context;
        }

        // GET: Locacaos
        public async Task<IActionResult> Index()
        {
            var context = _context.Locacoes.Include(l => l.Cliente).Include(l => l.Vestido);
            return View(await context.ToListAsync());
        }

        // GET: Locacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacao = await _context.Locacoes
                .Include(l => l.Cliente)
                .Include(l => l.Vestido)
                .FirstOrDefaultAsync(m => m.LocacaoID == id);
            if (locacao == null)
            {
                return NotFound();
            }

            return View(locacao);
        }

        // GET: Locacaos/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Clientes, "UserID", "UserID");
            ViewData["VestidoID"] = new SelectList(_context.Vestidos, "VestidoID", "Discriminator");
            return View();
        }

        // POST: Locacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocacaoID,DataRetirada,DataDevolucao,UserID,VestidoID,Valor,Desconto,FormaDePagamento")] Locacao locacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Clientes, "UserID", "UserID", locacao.UserID);
            ViewData["VestidoID"] = new SelectList(_context.Vestidos, "VestidoID", "Discriminator", locacao.VestidoID);
            return View(locacao);
        }

        // GET: Locacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacao = await _context.Locacoes.FindAsync(id);
            if (locacao == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Clientes, "UserID", "UserID", locacao.UserID);
            ViewData["VestidoID"] = new SelectList(_context.Vestidos, "VestidoID", "Discriminator", locacao.VestidoID);
            return View(locacao);
        }

        // POST: Locacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocacaoID,DataRetirada,DataDevolucao,UserID,VestidoID,Valor,Desconto,FormaDePagamento")] Locacao locacao)
        {
            if (id != locacao.LocacaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocacaoExists(locacao.LocacaoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Clientes, "UserID", "UserID", locacao.UserID);
            ViewData["VestidoID"] = new SelectList(_context.Vestidos, "VestidoID", "Discriminator", locacao.VestidoID);
            return View(locacao);
        }

        // GET: Locacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacao = await _context.Locacoes
                .Include(l => l.Cliente)
                .Include(l => l.Vestido)
                .FirstOrDefaultAsync(m => m.LocacaoID == id);
            if (locacao == null)
            {
                return NotFound();
            }

            return View(locacao);
        }

        // POST: Locacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locacao = await _context.Locacoes.FindAsync(id);
            _context.Locacoes.Remove(locacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocacaoExists(int id)
        {
            return _context.Locacoes.Any(e => e.LocacaoID == id);
        }
    }
}
