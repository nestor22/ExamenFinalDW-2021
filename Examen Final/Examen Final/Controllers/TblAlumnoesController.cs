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
    public class TblAlumnoesController : ControllerBase
    {
        private readonly ExamenFinalContext _context;

        public TblAlumnoesController(ExamenFinalContext context)
        {
            _context = context;
        }

        // GET: api/TblAlumnoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblAlumno>>> GetTblAlumnos()
        {
            return await _context.TblAlumnos.ToListAsync();
        }

        // GET: api/TblAlumnoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAlumno>> GetTblAlumno(long id)
        {
            var tblAlumno = await _context.TblAlumnos.FindAsync(id);

            if (tblAlumno == null)
            {
                return NotFound();
            }

            return tblAlumno;
        }

        // PUT: api/TblAlumnoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAlumno(long id, TblAlumno tblAlumno)
        {
            if (id != tblAlumno.Carnet)
            {
                return BadRequest();
            }

            _context.Entry(tblAlumno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAlumnoExists(id))
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

        // POST: api/TblAlumnoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblAlumno>> PostTblAlumno(TblAlumno tblAlumno)
        {
            _context.TblAlumnos.Add(tblAlumno);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblAlumnoExists(tblAlumno.Carnet))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblAlumno", new { id = tblAlumno.Carnet }, tblAlumno);
        }

        // DELETE: api/TblAlumnoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblAlumno>> DeleteTblAlumno(long id)
        {
            var tblAlumno = await _context.TblAlumnos.FindAsync(id);
            if (tblAlumno == null)
            {
                return NotFound();
            }

            _context.TblAlumnos.Remove(tblAlumno);
            await _context.SaveChangesAsync();

            return tblAlumno;
        }

        private bool TblAlumnoExists(long id)
        {
            return _context.TblAlumnos.Any(e => e.Carnet == id);
        }
    }
}
