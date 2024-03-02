using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OSSApi.Models;

namespace OSSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompatibilityMatrixController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompatibilityMatrixController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/CompatibilityMatrix/CheckCompatibility?license1=NázevLicence1&license2=NázevLicence2
        [HttpPost("CheckCompatibility3")]
        public async Task<ActionResult<string>> CheckCompatibility3(InLicenses license)
        {
            var compatibility = await _context.license_compatibility
                .Where(x => 
                    (x.License1 == license.Name1 && x.License2 == license.Name2) ||
                    (x.License1 == license.Name2 && x.License2 == license.Name1))
                .Select(x => x.Compatibility)
                .FirstOrDefaultAsync();

            return compatibility ?? ""; // Pokud není nalezena žádná shoda, vrátí se prázdný řetězec
        }


        
        // GET: api/CompatibilityMatrix/CheckCompatibility?license1=NázevLicence1&license2=NázevLicence2
        [HttpGet("CheckCompatibility")]
        public async Task<ActionResult<bool>> CheckCompatibility(string license1, string license2)
        {
            var compatibility = await _context.compatibility_matrix
                .Join(_context.licenses,
                    cm => cm.License_id_1,
                    l => l.Id,
                    (cm, l1) => new { CompatibilityMatrix = cm, License1 = l1 })
                .Join(_context.licenses,
                    cm => cm.CompatibilityMatrix.License_id_2,
                    l => l.Id,
                    (cm, l2) => new { cm.CompatibilityMatrix, cm.License1, License2 = l2 })
                .Where(x => x.License1.Name == license1 && x.License2.Name == license2)
                .Select(x => x.CompatibilityMatrix.Compatible)
                .FirstOrDefaultAsync();

            if (compatibility == null)
            {
                return false;
            }

            return compatibility;
        }
        
        // POST: api/CompatibilityMatrix/CheckCompatibility?license1=NázevLicence1&license2=NázevLicence2
        [HttpPost("CheckCompatibility2")]
        public async Task<ActionResult<bool>> CheckCompatibility2(InLicenses license)
        {
            var compatibility = await _context.compatibility_matrix
                .Join(_context.licenses,
                    cm => cm.License_id_1,
                    l => l.Id,
                    (cm, l1) => new { CompatibilityMatrix = cm, License1 = l1 })
                .Join(_context.licenses,
                    cm => cm.CompatibilityMatrix.License_id_2,
                    l => l.Id,
                    (cm, l2) => new { cm.CompatibilityMatrix, cm.License1, License2 = l2 })
                .Where(x => x.License1.Name == license.Name1 && x.License2.Name == license.Name2)
                .Select(x => x.CompatibilityMatrix.Compatible)
                .FirstOrDefaultAsync();

            if (compatibility == null)
            {
                return false;
            }

            return compatibility;
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
