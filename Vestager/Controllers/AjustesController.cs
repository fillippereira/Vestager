using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vestager.Domain.Entities;
using Vestager.Domain.Interfaces.UnitOfWork;
using Vestager.Infra.Data;
using Vestager.Infra.UnitOfWork;

namespace Vestager.MVC.Controllers
{
    public class AjustesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AjustesController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
        // GET: Ajustes
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.Ajustes.GetAllAsync());
        }

        // GET: Ajustes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ajuste = await _unitOfWork.Ajustes
                .FirstOrDefaultAsync(m => m.AjusteID == id);
            if (ajuste == null)
            {
                return NotFound();
            }

            return View(ajuste);
        }

        // GET: Ajustes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ajustes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AjusteID,Nome,Nivel,TempoEstimado")] Ajuste ajuste)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Ajustes.Add(ajuste);
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ajuste);
        }

        // GET: Ajustes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var ajuste = await _unitOfWork.Ajustes.GetByIdAsync(id);
            if (ajuste == null)
            {
                return NotFound();
            }
            return View(ajuste);
        }

        // POST: Ajustes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AjusteID,Nome,Nivel,TempoEstimado")] Ajuste ajuste)
        {
            if (id != ajuste.AjusteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Ajustes.Update(ajuste);
                    await _unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AjusteExists(ajuste.AjusteID))
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
            return View(ajuste);
        }

        // GET: Ajustes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ajuste = await _unitOfWork.Ajustes
                .FirstOrDefaultAsync(m => m.AjusteID == id);
            if (ajuste == null)
            {
                return NotFound();
            }

            return View(ajuste);
        }

        // POST: Ajustes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ajuste = await _unitOfWork.Ajustes.GetByIdAsync(id);
            _unitOfWork.Ajustes.Remove(ajuste);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AjusteExists(int id)
        {
            return _unitOfWork.Ajustes.Any(e => e.AjusteID == id);
        }
    }
}
