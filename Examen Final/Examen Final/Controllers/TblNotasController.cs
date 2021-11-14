using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen_Final.Models;

namespace Examen_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblNotasController : ControllerBase
    {
        private readonly ExamenFinalContext _context;

        public TblNotasController(ExamenFinalContext context)
        {
            _context = context;
        }

        // GET: api/TblNotas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblNota>>> GetTblNotas()
        {
            return await _context.TblNotas.ToListAsync();
        }

        // GET: api/TblNotas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblNota>> GetTblNota(long id)
        {
            var tblNota = await _context.TblNotas.FindAsync(id);

            if (tblNota == null)
            {
                return NotFound();
            }

            return tblNota;
        }

        // PUT: api/TblNotas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblNota(long id, TblNota tblNota)
        {
            if (id != tblNota.CodigoCurso)
            {
                return BadRequest();
            }

            _context.Entry(tblNota).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblNotaExists(id))
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

        // POST: api/TblNotas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblNota>> PostTblNota(TblNota tblNota)
        {
            _context.TblNotas.Add(tblNota);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblNotaExists(tblNota.CodigoCurso))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblNota", new { id = tblNota.CodigoCurso }, tblNota);
        }

        // DELETE: api/TblNotas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblNota>> DeleteTblNota(long id)
        {
            var tblNota = await _context.TblNotas.FindAsync(id);
            if (tblNota == null)
            {
                return NotFound();
            }

            _context.TblNotas.Remove(tblNota);
            await _context.SaveChangesAsync();

            return tblNota;
        }

        private bool TblNotaExists(long id)
        {
            return _context.TblNotas.Any(e => e.CodigoCurso == id);
        }
    }
}
