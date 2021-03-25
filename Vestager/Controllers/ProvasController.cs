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
    public class ProvasController : Controller
    {
        private readonly Context _context;

        public ProvasController(Context context)
        {
            _context = context;
        }

        // GET: Provas
        public async Task<IActionResult> Index()
        {
            var context = _context.Provas.Include(p => p.Cliente);
            return View(await context.ToListAsync());
        }

        // GET: Provas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prova = await _context.Provas
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.ProvaID == id);
            if (prova == null)
            {
                return NotFound();
            }

            return View(prova);
        }

        // GET: Provas/Create
        public IActionResult Create()
        {
            ViewData["ClienteID"] = new SelectList(_context.Clientes, "UserID", "UserID");
            return View();
        }

        // POST: Provas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProvaID,ClienteID,DataProva")] Prova prova)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prova);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteID"] = new SelectList(_context.Clientes, "UserID", "UserID", prova.ClienteID);
            return View(prova);
        }

        // GET: Provas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prova = await _context.Provas.FindAsync(id);
            if (prova == null)
            {
                return NotFound();
            }
            ViewData["ClienteID"] = new SelectList(_context.Clientes, "UserID", "UserID", prova.ClienteID);
            return View(prova);
        }

        // POST: Provas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProvaID,ClienteID,DataProva")] Prova prova)
        {
            if (id != prova.ProvaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prova);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvaExists(prova.ProvaID))
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
            ViewData["ClienteID"] = new SelectList(_context.Clientes, "UserID", "UserID", prova.ClienteID);
            return View(prova);
        }

        // GET: Provas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prova = await _context.Provas
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.ProvaID == id);
            if (prova == null)
            {
                return NotFound();
            }

            return View(prova);
        }

        // POST: Provas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prova = await _context.Provas.FindAsync(id);
            _context.Provas.Remove(prova);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProvaExists(int id)
        {
            return _context.Provas.Any(e => e.ProvaID == id);
        }
    }
}
