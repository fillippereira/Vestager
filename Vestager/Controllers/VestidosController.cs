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
    public class VestidosController : Controller
    {
        private readonly Context _context;

        public VestidosController(Context context)
        {
            _context = context;
        }

        // GET: Vestidos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vestidos.ToListAsync());
        }

        // GET: Vestidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vestido = await _context.Vestidos
                .FirstOrDefaultAsync(m => m.VestidoID == id);
            if (vestido == null)
            {
                return NotFound();
            }

            return View(vestido);
        }

        // GET: Vestidos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vestidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VestidoID,Nome,Cor,Tamanho,Descricao")] Vestido vestido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vestido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vestido);
        }

        // GET: Vestidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vestido = await _context.Vestidos.FindAsync(id);
            if (vestido == null)
            {
                return NotFound();
            }
            return View(vestido);
        }

        // POST: Vestidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VestidoID,Nome,Cor,Tamanho,Descricao")] Vestido vestido)
        {
            if (id != vestido.VestidoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vestido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VestidoExists(vestido.VestidoID))
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
            return View(vestido);
        }

        // GET: Vestidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vestido = await _context.Vestidos
                .FirstOrDefaultAsync(m => m.VestidoID == id);
            if (vestido == null)
            {
                return NotFound();
            }

            return View(vestido);
        }

        // POST: Vestidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vestido = await _context.Vestidos.FindAsync(id);
            _context.Vestidos.Remove(vestido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VestidoExists(int id)
        {
            return _context.Vestidos.Any(e => e.VestidoID == id);
        }
    }
}
