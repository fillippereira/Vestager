﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vestager.Domain.Constants;
using Vestager.Domain.Entities;
using Vestager.Domain.Interfaces.UnitOfWork;
using Vestager.Infra.Data;
using Vestager.MVC.Models;

namespace Vestager.MVC.Controllers
{
    public class VestidosController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VestidosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
      
        // GET: Vestidos
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.Vestidos.GetAllAsync());
        }

        // GET: Vestidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vestido = await _unitOfWork.Vestidos
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
        public async Task<IActionResult> Create(VestidoViewModel vestidoViewModel)
        {
            
            if (ModelState.IsValid)
            {
                Vestido vestido = _mapper.Map<Vestido>(vestidoViewModel);
                _unitOfWork.Vestidos.Add(vestido);
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Vestidos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var vestido = await _unitOfWork.Vestidos.GetByIdAsync(id);
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
                    _unitOfWork.Vestidos.Update(vestido);
                    await _unitOfWork.SaveAsync();
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

            var vestido = await _unitOfWork.Vestidos
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
            var vestido = await _unitOfWork.Vestidos.GetByIdAsync(id);
            _unitOfWork.Vestidos.Remove(vestido);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VestidoExists(int id)
        {
            return _unitOfWork.Vestidos.Any(e => e.VestidoID == id);
        }
    }
}
