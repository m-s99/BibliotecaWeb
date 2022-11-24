using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaWeb.Data;
using BibliotecaWeb.Models;

namespace BibliotecaWeb.Controllers
{
    public class TematicasController : Controller
    {
        private readonly smartsof_biblioContext _context;

        public TematicasController(smartsof_biblioContext context)
        {
            _context = context;
        }

        // GET: Tematicas
        public async Task<IActionResult> Index()
        {
            var bibliotecaWebContext = _context.Tematicas.Include(t => t.Usuario);
            return View(await bibliotecaWebContext.ToListAsync());
        }

        // GET: Tematicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tematicas == null)
            {
                return NotFound();
            }

            var tematica = await _context.Tematicas
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tematica == null)
            {
                return NotFound();
            }

            return View(tematica);
        }

        // GET: Tematicas/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "Id", "Id");
            return View();
        }

        // POST: Tematicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,UsuarioId,FechaHoraEliminacion,Eliminado")] Tematica tematica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tematica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "Id", "Id", tematica.UsuarioId);
            return View(tematica);
        }

        // GET: Tematicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tematicas == null)
            {
                return NotFound();
            }

            var tematica = await _context.Tematicas.FindAsync(id);
            if (tematica == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "Id", "Id", tematica.UsuarioId);
            return View(tematica);
        }

        // POST: Tematicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,UsuarioId,FechaHoraEliminacion,Eliminado")] Tematica tematica)
        {
            if (id != tematica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tematica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TematicaExists(tematica.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "Id", "Id", tematica.UsuarioId);
            return View(tematica);
        }

        // GET: Tematicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tematicas == null)
            {
                return NotFound();
            }

            var tematica = await _context.Tematicas
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tematica == null)
            {
                return NotFound();
            }

            return View(tematica);
        }

        // POST: Tematicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tematicas == null)
            {
                return Problem("Entity set 'BibliotecaWebContext.Tematica'  is null.");
            }
            var tematica = await _context.Tematicas.FindAsync(id);
            if (tematica != null)
            {
                _context.Tematicas.Remove(tematica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TematicaExists(int id)
        {
          return _context.Tematicas.Any(e => e.Id == id);
        }
    }
}
