using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBiblioteca.Data;
using WebBiblioteca.Models;

namespace WebBiblioteca.Controllers
{
    public class EjemplaresController : Controller
    {
        private readonly BibliotecaContext _context;

        public EjemplaresController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Ejemplares
        public async Task<IActionResult> Index()
        {
            var bibliotecaContext = _context.Ejemplars.Include(e => e.Libro);
            return View(await bibliotecaContext.ToListAsync());
        }

        // GET: Ejemplares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ejemplars == null)
            {
                return NotFound();
            }

            var ejemplar = await _context.Ejemplars
                .Include(e => e.Libro)
                .FirstOrDefaultAsync(m => m.EjemplarId == id);
            if (ejemplar == null)
            {
                return NotFound();
            }

            return View(ejemplar);
        }

        // GET: Ejemplares/Create
        public IActionResult Create()
        {
            ViewData["LibroId"] = new SelectList(_context.Libros, "LibroId", "Editorial");
            return View();
        }

        // POST: Ejemplares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EjemplarId,LibroId,Localizacion")] Ejemplar ejemplar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ejemplar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LibroId"] = new SelectList(_context.Libros, "LibroId", "Editorial", ejemplar.LibroId);
            return View(ejemplar);
        }

        // GET: Ejemplares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ejemplars == null)
            {
                return NotFound();
            }

            var ejemplar = await _context.Ejemplars.FindAsync(id);
            if (ejemplar == null)
            {
                return NotFound();
            }
            ViewData["LibroId"] = new SelectList(_context.Libros, "LibroId", "Editorial", ejemplar.LibroId);
            return View(ejemplar);
        }

        // POST: Ejemplares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EjemplarId,LibroId,Localizacion")] Ejemplar ejemplar)
        {
            if (id != ejemplar.EjemplarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ejemplar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EjemplarExists(ejemplar.EjemplarId))
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
            ViewData["LibroId"] = new SelectList(_context.Libros, "LibroId", "Editorial", ejemplar.LibroId);
            return View(ejemplar);
        }

        // GET: Ejemplares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ejemplars == null)
            {
                return NotFound();
            }

            var ejemplar = await _context.Ejemplars
                .Include(e => e.Libro)
                .FirstOrDefaultAsync(m => m.EjemplarId == id);
            if (ejemplar == null)
            {
                return NotFound();
            }

            return View(ejemplar);
        }

        // POST: Ejemplares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ejemplars == null)
            {
                return Problem("Entity set 'BibliotecaContext.Ejemplars'  is null.");
            }
            var ejemplar = await _context.Ejemplars.FindAsync(id);
            if (ejemplar != null)
            {
                _context.Ejemplars.Remove(ejemplar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EjemplarExists(int id)
        {
          return (_context.Ejemplars?.Any(e => e.EjemplarId == id)).GetValueOrDefault();
        }
    }
}
