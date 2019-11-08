using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ejemplo.Models;
using ejemplo.Models.DATA.DDL;

namespace ejemplo.Controllers
{
    public class VehiculoesController : Controller
    {
        private readonly ejemploContext _context;

        public VehiculoesController(ejemploContext context)
        {
            _context = context;
        }

        // GET: Vehiculoes
        public async Task<IActionResult> Index()
        {
            var ejemploContext = _context.Vehiculo.Include(v => v.clientes).Include(v => v.tipoVehiculo);
            return View(await ejemploContext.ToListAsync());
        }

        // GET: Vehiculoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo
                .Include(v => v.clientes)
                .Include(v => v.tipoVehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // GET: Vehiculoes/Create
        public IActionResult Create()
        {
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "Id", "Id");
            ViewData["TipoVehiculoId"] = new SelectList(_context.TipoVehiculo, "Id", "Id");
            return View();
        }

        // POST: Vehiculoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,placa,nombre,TipoVehiculoId,ClientesId")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "Id", "Id", vehiculo.ClientesId);
            ViewData["TipoVehiculoId"] = new SelectList(_context.TipoVehiculo, "Id", "Id", vehiculo.TipoVehiculoId);
            return View(vehiculo);
        }

        // GET: Vehiculoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "Id", "Id", vehiculo.ClientesId);
            ViewData["TipoVehiculoId"] = new SelectList(_context.TipoVehiculo, "Id", "Id", vehiculo.TipoVehiculoId);
            return View(vehiculo);
        }

        // POST: Vehiculoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,placa,nombre,TipoVehiculoId,ClientesId")] Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoExists(vehiculo.Id))
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
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "Id", "Id", vehiculo.ClientesId);
            ViewData["TipoVehiculoId"] = new SelectList(_context.TipoVehiculo, "Id", "Id", vehiculo.TipoVehiculoId);
            return View(vehiculo);
        }

        // GET: Vehiculoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo
                .Include(v => v.clientes)
                .Include(v => v.tipoVehiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // POST: Vehiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculo = await _context.Vehiculo.FindAsync(id);
            _context.Vehiculo.Remove(vehiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoExists(int id)
        {
            return _context.Vehiculo.Any(e => e.Id == id);
        }
    }
}
