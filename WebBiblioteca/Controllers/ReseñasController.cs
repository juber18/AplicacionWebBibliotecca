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
    public class ReseñasController : Controller
    {
        private readonly BibliotecaContext _context;

        public ReseñasController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Reseñas
        public async Task<IActionResult> Index()
        {
            var bibliotecaContext = _context.Reseñas.Include(r => r.Libro).Include(r => r.Usuario);
            return View(await bibliotecaContext.ToListAsync());
        }

        // GET: Reseñas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reseñas == null)
            {
                return NotFound();
            }

            var reseña = await _context.Reseñas
                .Include(r => r.Libro)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.LibroID == id);
            if (reseña == null)
            {
                return NotFound();
            }

            return View(reseña);
        }

        // GET: Reseñas/Create
        public IActionResult Create()
        {
            ViewData["LibroID"] = new SelectList(_context.Libros, "LibroId", "Editorial");
            ViewData["UsuarioID"] = new SelectList(_context.Usuarios, "UsuarioId", "Correo");
            return View();
        }

        // POST: Reseñas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LibroID,UsuarioID,Calificacion,TextReseña")] Reseña reseña)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reseña);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LibroID"] = new SelectList(_context.Libros, "LibroId", "Editorial", reseña.LibroID);
            ViewData["UsuarioID"] = new SelectList(_context.Usuarios, "UsuarioId", "Correo", reseña.UsuarioID);
            return View(reseña);
        }

        // GET: Reseñas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reseñas == null)
            {
                return NotFound();
            }

            var reseña = await _context.Reseñas.FindAsync(id);
            if (reseña == null)
            {
                return NotFound();
            }
            ViewData["LibroID"] = new SelectList(_context.Libros, "LibroId", "Editorial", reseña.LibroID);
            ViewData["UsuarioID"] = new SelectList(_context.Usuarios, "UsuarioId", "Correo", reseña.UsuarioID);
            return View(reseña);
        }

        // POST: Reseñas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LibroID,UsuarioID,Calificacion,TextReseña")] Reseña reseña)
        {
            if (id != reseña.LibroID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reseña);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReseñaExists(reseña.LibroID))
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
            ViewData["LibroID"] = new SelectList(_context.Libros, "LibroId", "Editorial", reseña.LibroID);
            ViewData["UsuarioID"] = new SelectList(_context.Usuarios, "UsuarioId", "Correo", reseña.UsuarioID);
            return View(reseña);
        }

        // GET: Reseñas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reseñas == null)
            {
                return NotFound();
            }

            var reseña = await _context.Reseñas
                .Include(r => r.Libro)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.LibroID == id);
            if (reseña == null)
            {
                return NotFound();
            }

            return View(reseña);
        }

        // POST: Reseñas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reseñas == null)
            {
                return Problem("Entity set 'BibliotecaContext.Reseñas'  is null.");
            }
            var reseña = await _context.Reseñas.FindAsync(id);
            if (reseña != null)
            {
                _context.Reseñas.Remove(reseña);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReseñaExists(int id)
        {
          return (_context.Reseñas?.Any(e => e.LibroID == id)).GetValueOrDefault();
        }
    }
}
