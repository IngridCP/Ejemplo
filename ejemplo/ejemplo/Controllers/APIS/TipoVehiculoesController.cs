using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ejemplo.Models;
using ejemplo.Models.DATA.DDL;

namespace ejemplo.Controllers.APIS
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoVehiculoesController : ControllerBase
    {
        private readonly ejemploContext _context;

        public TipoVehiculoesController(ejemploContext context)
        {
            _context = context;
        }

        // GET: api/TipoVehiculoes
        [HttpGet]
        public IEnumerable<TipoVehiculo> GetTipoVehiculo()
        {
            return _context.TipoVehiculo;
        }

        // GET: api/TipoVehiculoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoVehiculo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoVehiculo = await _context.TipoVehiculo.FindAsync(id);

            if (tipoVehiculo == null)
            {
                return NotFound();
            }

            return Ok(tipoVehiculo);
        }

        // PUT: api/TipoVehiculoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoVehiculo([FromRoute] int id, [FromBody] TipoVehiculo tipoVehiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoVehiculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoVehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoVehiculoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TipoVehiculoes
        [HttpPost]
        public async Task<IActionResult> PostTipoVehiculo([FromBody] TipoVehiculo tipoVehiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TipoVehiculo.Add(tipoVehiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoVehiculo", new { id = tipoVehiculo.Id }, tipoVehiculo);
        }

        // DELETE: api/TipoVehiculoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoVehiculo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoVehiculo = await _context.TipoVehiculo.FindAsync(id);
            if (tipoVehiculo == null)
            {
                return NotFound();
            }

            _context.TipoVehiculo.Remove(tipoVehiculo);
            await _context.SaveChangesAsync();

            return Ok(tipoVehiculo);
        }

        private bool TipoVehiculoExists(int id)
        {
            return _context.TipoVehiculo.Any(e => e.Id == id);
        }
    }
}