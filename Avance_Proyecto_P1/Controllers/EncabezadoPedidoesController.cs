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
    public class EncabezadoPedidoesController : Controller
    {
        private readonly Avance_Proyecto_P1Context _context;

        public EncabezadoPedidoesController(Avance_Proyecto_P1Context context)
        {
            _context = context;
        }

        // GET: EncabezadoPedidoes
        public async Task<IActionResult> Index()
        {
            var avance_Proyecto_P1Context = _context.EncabezadoPedido.Include(e => e.Cliente);
            return View(await avance_Proyecto_P1Context.ToListAsync());
        }

        // GET: EncabezadoPedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encabezadoPedido = await _context.EncabezadoPedido
                .Include(e => e.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (encabezadoPedido == null)
            {
                return NotFound();
            }

            return View(encabezadoPedido);
        }

        // GET: EncabezadoPedidoes/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "Id", "Id");
            return View();
        }

        // POST: EncabezadoPedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCliente,FechaPedido,Estado")] EncabezadoPedido encabezadoPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(encabezadoPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "Id", "Id", encabezadoPedido.IdCliente);
            return View(encabezadoPedido);
        }

        // GET: EncabezadoPedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encabezadoPedido = await _context.EncabezadoPedido.FindAsync(id);
            if (encabezadoPedido == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "Id", "Id", encabezadoPedido.IdCliente);
            return View(encabezadoPedido);
        }

        // POST: EncabezadoPedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCliente,FechaPedido,Estado")] EncabezadoPedido encabezadoPedido)
        {
            if (id != encabezadoPedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encabezadoPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncabezadoPedidoExists(encabezadoPedido.Id))
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
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "Id", "Id", encabezadoPedido.IdCliente);
            return View(encabezadoPedido);
        }

        // GET: EncabezadoPedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encabezadoPedido = await _context.EncabezadoPedido
                .Include(e => e.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (encabezadoPedido == null)
            {
                return NotFound();
            }

            return View(encabezadoPedido);
        }

        // POST: EncabezadoPedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var encabezadoPedido = await _context.EncabezadoPedido.FindAsync(id);
            if (encabezadoPedido != null)
            {
                _context.EncabezadoPedido.Remove(encabezadoPedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncabezadoPedidoExists(int id)
        {
            return _context.EncabezadoPedido.Any(e => e.Id == id);
        }
    }
}
