using DesafioCarros.Data;
using DesafioCarros.Models;
using DesafioCarros.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            /*Cria um objeto view model e popula a 
             * lista de departamentos*/
            var viewModel = new NotaViewModel();
            viewModel.Carros = _context.Carro.ToList();
            viewModel.Clientes = _context.Cliente.ToList();
            viewModel.Vendedores = _context.Vendedor.ToList();
            return View(viewModel);
        }

        // POST: Notas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        public IActionResult Create(Nota nota)
        {
            if (nota == null)
            {
                return NotFound();
            }
            _context.Add(nota);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Notas/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nota = _context.Nota.First(sr => sr.Id == id);

            if (nota == null)
            {
                return NotFound();
            }

            NotaViewModel viewModel = new NotaViewModel();
            viewModel.Nota = nota;
            viewModel.Carros = _context.Carro.ToList();
            viewModel.Clientes = _context.Cliente.ToList();
            viewModel.Vendedores = _context.Vendedor.ToList();

            return View(viewModel);
        }

        // POST: Notas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Edit(Nota nota)
        {
            _context.Update(nota);
            _context.SaveChanges();
            return RedirectToAction("Index");
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
