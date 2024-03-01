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
    public class LicensesController : ControllerBase
    {
        private readonly LicensesDbContext _context;

        public LicensesController(LicensesDbContext context)
        {
            _context = context;
        }

        // GET: api/Licenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Licenses>>> Getlicenses()
        {
            return await _context.licenses.ToListAsync();
        }

        // GET: api/Licenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Licenses>> GetLicenses(int id)
        {
            var licenses = await _context.licenses.FindAsync(id);

            if (licenses == null)
            {
                return NotFound();
            }

            return licenses;
        }

        // PUT: api/Licenses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLicenses(int id, Licenses licenses)
        {
            if (id != licenses.Id)
            {
                return BadRequest();
            }

            _context.Entry(licenses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LicensesExists(id))
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

        // POST: api/Licenses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Licenses>> PostLicenses(Licenses licenses)
        {
            _context.licenses.Add(licenses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLicenses", new { id = licenses.Id }, licenses);
        }

        // DELETE: api/Licenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLicenses(int id)
        {
            var licenses = await _context.licenses.FindAsync(id);
            if (licenses == null)
            {
                return NotFound();
            }

            _context.licenses.Remove(licenses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LicensesExists(int id)
        {
            return _context.licenses.Any(e => e.Id == id);
        }
    }
}
