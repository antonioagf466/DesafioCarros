﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesafioCarros.Data;
using DesafioCarros.Models;

namespace DesafioCarros.Controllers
{
    public class NotasController : Controller
    {
        private readonly DesafioCarrosContext _context;

        public NotasController(DesafioCarrosContext context)
        {
            _context = context;
        }

        // GET: Notas
        public async Task<IActionResult> Index()
        {
            var desafioCarrosContext = _context.Nota.Include(n => n.carro).Include(n => n.cliente).Include(n => n.vendedor);
            return View(await desafioCarrosContext.ToListAsync());
        }

        // GET: Notas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota
                .Include(n => n.carro)
                .Include(n => n.cliente)
                .Include(n => n.vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        // GET: Notas/Create
        public IActionResult Create()
        {
            ViewData["CarroId"] = new SelectList(_context.Carro, "Id", "Id");
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id");
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "Id", "Id");
            return View();
        }

        // POST: Notas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,DataEmissao,Garantia,ValorVenda,ClienteId,VendedorId,CarroId")] Nota nota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarroId"] = new SelectList(_context.Carro, "Id", "Id", nota.CarroId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", nota.ClienteId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "Id", "Id", nota.VendedorId);
            return View(nota);
        }

        // GET: Notas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota.FindAsync(id);
            if (nota == null)
            {
                return NotFound();
            }
            ViewData["CarroId"] = new SelectList(_context.Carro, "Id", "Id", nota.CarroId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", nota.ClienteId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "Id", "Id", nota.VendedorId);
            return View(nota);
        }

        // POST: Notas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,DataEmissao,Garantia,ValorVenda,ClienteId,VendedorId,CarroId")] Nota nota)
        {
            if (id != nota.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaExists(nota.Id))
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
            ViewData["CarroId"] = new SelectList(_context.Carro, "Id", "Id", nota.CarroId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", nota.ClienteId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "Id", "Id", nota.VendedorId);
            return View(nota);
        }

        // GET: Notas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota
                .Include(n => n.carro)
                .Include(n => n.cliente)
                .Include(n => n.vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nota == null)
            {
                return Problem("Entity set 'DesafioCarrosContext.Nota'  is null.");
            }
            var nota = await _context.Nota.FindAsync(id);
            if (nota != null)
            {
                _context.Nota.Remove(nota);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaExists(int id)
        {
          return (_context.Nota?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
