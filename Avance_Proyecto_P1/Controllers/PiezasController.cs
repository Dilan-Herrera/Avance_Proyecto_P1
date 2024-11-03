using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Avance_Proyecto_P1.Data;
using Avance_Proyecto_P1.Models;

namespace Avance_Proyecto_P1.Controllers
{
    public class PiezasController : Controller
    {
        private readonly Avance_Proyecto_P1Context _context;

        public PiezasController(Avance_Proyecto_P1Context context)
        {
            _context = context;
        }

        // GET: Piezas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pieza.ToListAsync());
        }

        // GET: Piezas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pieza = await _context.Pieza
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pieza == null)
            {
                return NotFound();
            }

            return View(pieza);
        }

        // GET: Piezas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Piezas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CantidadDisponible,PrecioUnitario")] Pieza pieza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pieza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pieza);
        }

        // GET: Piezas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pieza = await _context.Pieza.FindAsync(id);
            if (pieza == null)
            {
                return NotFound();
            }
            return View(pieza);
        }

        // POST: Piezas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CantidadDisponible,PrecioUnitario")] Pieza pieza)
        {
            if (id != pieza.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pieza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PiezaExists(pieza.Id))
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
            return View(pieza);
        }

        // GET: Piezas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pieza = await _context.Pieza
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pieza == null)
            {
                return NotFound();
            }

            return View(pieza);
        }

        // POST: Piezas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pieza = await _context.Pieza.FindAsync(id);
            if (pieza != null)
            {
                _context.Pieza.Remove(pieza);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PiezaExists(int id)
        {
            return _context.Pieza.Any(e => e.Id == id);
        }
    }
}
