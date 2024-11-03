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
    public class DetallePedidoesController : Controller
    {
        private readonly Avance_Proyecto_P1Context _context;

        public DetallePedidoesController(Avance_Proyecto_P1Context context)
        {
            _context = context;
        }

        // GET: DetallePedidoes
        public async Task<IActionResult> Index()
        {
            var avance_Proyecto_P1Context = _context.DetallePedido.Include(d => d.EncabezadoPedido).Include(d => d.Pieza);
            return View(await avance_Proyecto_P1Context.ToListAsync());
        }

        // GET: DetallePedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedido
                .Include(d => d.EncabezadoPedido)
                .Include(d => d.Pieza)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            return View(detallePedido);
        }

        // GET: DetallePedidoes/Create
        public IActionResult Create()
        {
            ViewData["IdEncabezado"] = new SelectList(_context.Set<EncabezadoPedido>(), "Id", "Id");
            ViewData["IdPieza"] = new SelectList(_context.Set<Pieza>(), "Id", "Id");
            return View();
        }

        // POST: DetallePedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdEncabezado,IdPieza,Cantidad,Total")] DetallePedido detallePedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallePedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEncabezado"] = new SelectList(_context.Set<EncabezadoPedido>(), "Id", "Id", detallePedido.IdEncabezado);
            ViewData["IdPieza"] = new SelectList(_context.Set<Pieza>(), "Id", "Id", detallePedido.IdPieza);
            return View(detallePedido);
        }

        // GET: DetallePedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedido.FindAsync(id);
            if (detallePedido == null)
            {
                return NotFound();
            }
            ViewData["IdEncabezado"] = new SelectList(_context.Set<EncabezadoPedido>(), "Id", "Id", detallePedido.IdEncabezado);
            ViewData["IdPieza"] = new SelectList(_context.Set<Pieza>(), "Id", "Id", detallePedido.IdPieza);
            return View(detallePedido);
        }

        // POST: DetallePedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdEncabezado,IdPieza,Cantidad,Total")] DetallePedido detallePedido)
        {
            if (id != detallePedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallePedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallePedidoExists(detallePedido.Id))
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
            ViewData["IdEncabezado"] = new SelectList(_context.Set<EncabezadoPedido>(), "Id", "Id", detallePedido.IdEncabezado);
            ViewData["IdPieza"] = new SelectList(_context.Set<Pieza>(), "Id", "Id", detallePedido.IdPieza);
            return View(detallePedido);
        }

        // GET: DetallePedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedido
                .Include(d => d.EncabezadoPedido)
                .Include(d => d.Pieza)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            return View(detallePedido);
        }

        // POST: DetallePedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detallePedido = await _context.DetallePedido.FindAsync(id);
            if (detallePedido != null)
            {
                _context.DetallePedido.Remove(detallePedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallePedidoExists(int id)
        {
            return _context.DetallePedido.Any(e => e.Id == id);
        }
    }
}
