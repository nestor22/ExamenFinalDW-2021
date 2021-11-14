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
    public class TblCursoController : ControllerBase
    {
        private readonly ExamenFinalContext _context;

        public TblCursoController(ExamenFinalContext context)
        {
            _context = context;
        }

        // GET: api/TblCurso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCurso>>> GetTblCursos()
        {
            return await _context.TblCursos.ToListAsync();
        }

        // GET: api/TblCurso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCurso>> GetTblCurso(long id)
        {
            var tblCurso = await _context.TblCursos.FindAsync(id);

            if (tblCurso == null)
            {
                return NotFound();
            }

            return tblCurso;
        }

        // PUT: api/TblCurso/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCurso(long id, TblCurso tblCurso)
        {
            if (id != tblCurso.CodigoCurso)
            {
                return BadRequest();
            }

            _context.Entry(tblCurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCursoExists(id))
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

        // POST: api/TblCurso
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblCurso>> PostTblCurso(TblCurso tblCurso)
        {
            _context.TblCursos.Add(tblCurso);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblCursoExists(tblCurso.CodigoCurso))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblCurso", new { id = tblCurso.CodigoCurso }, tblCurso);
        }

        // DELETE: api/TblCurso/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblCurso>> DeleteTblCurso(long id)
        {
            var tblCurso = await _context.TblCursos.FindAsync(id);
            if (tblCurso == null)
            {
                return NotFound();
            }

            _context.TblCursos.Remove(tblCurso);
            await _context.SaveChangesAsync();

            return tblCurso;
        }

        private bool TblCursoExists(long id)
        {
            return _context.TblCursos.Any(e => e.CodigoCurso == id);
        }
    }
}
