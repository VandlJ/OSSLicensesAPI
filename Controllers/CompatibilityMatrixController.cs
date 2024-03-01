using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OSSApi.Data;
using OSSApi.Models;

namespace OSSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompatibilityMatrixController : ControllerBase
    {
        private readonly CompatibilityMatrixDbContext _context;

        public CompatibilityMatrixController(CompatibilityMatrixDbContext context)
        {
            _context = context;
        }

        // GET: api/CompatibilityMatrix
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompatibilityMatrix>>> GetcompatibilityMatrix()
        {
            return await _context.compatibility_matrix.ToListAsync();
        }

        // GET: api/CompatibilityMatrix/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompatibilityMatrix>> GetCompatibilityMatrix(int id)
        {
            var compatibilityMatrix = await _context.compatibility_matrix.FindAsync(id);

            if (compatibilityMatrix == null)
            {
                return NotFound();
            }

            return compatibilityMatrix;
        }

        // PUT: api/CompatibilityMatrix/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompatibilityMatrix(int id, CompatibilityMatrix compatibilityMatrix)
        {
            if (id != compatibilityMatrix.Id)
            {
                return BadRequest();
            }

            _context.Entry(compatibilityMatrix).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompatibilityMatrixExists(id))
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

        // POST: api/CompatibilityMatrix
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompatibilityMatrix>> PostCompatibilityMatrix(CompatibilityMatrix compatibilityMatrix)
        {
            _context.compatibility_matrix.Add(compatibilityMatrix);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompatibilityMatrix", new { id = compatibilityMatrix.Id }, compatibilityMatrix);
        }

        // DELETE: api/CompatibilityMatrix/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompatibilityMatrix(int id)
        {
            var compatibilityMatrix = await _context.compatibility_matrix.FindAsync(id);
            if (compatibilityMatrix == null)
            {
                return NotFound();
            }

            _context.compatibility_matrix.Remove(compatibilityMatrix);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompatibilityMatrixExists(int id)
        {
            return _context.compatibility_matrix.Any(e => e.Id == id);
        }
    }
}
