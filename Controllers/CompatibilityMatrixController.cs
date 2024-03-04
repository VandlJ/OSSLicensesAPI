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

        // POST: api/CompatibilityMatrix/CheckCompatibility
        [HttpPost("CheckCompatibility")]
        public async Task<ActionResult<string>> CheckCompatibility3(InLicenses license)
        {
            var compatibility = await _context.license_compatibility
                .Where(x => 
                    (x.License1 == license.Name1 && x.License2 == license.Name2))
                .Select(x => x.Compatibility)
                .FirstOrDefaultAsync();

            return compatibility ?? ""; // Pokud není nalezena žádná shoda, vrátí se prázdný řetězec
        }

        // GET: api/CompatibilityMatrix/CheckCompatibility
        [HttpGet("CheckCompatibility")]
        public async Task<ActionResult<string>> CheckCompatibility3(string license1, string license2)
        {
            var compatibility = await _context.license_compatibility
                .Where(x => 
                    (x.License1 == license1 && x.License2 == license2))
                .Select(x => x.Compatibility)
                .FirstOrDefaultAsync();

            return compatibility ?? ""; // Pokud není nalezena žádná shoda, vrátí se prázdný řetězec
        }
        
        // GET: api/CompatibilityMatrix/GetLicenses
        [HttpGet("GetLicenses")]
        public async Task<ActionResult<IEnumerable<string>>> GetUniqueLicenseNames()
        {
            var uniqueLicenseNames = await _context.license_compatibility
                .Select(x => x.License1)
                .Union(_context.license_compatibility.Select(x => x.License2))
                .Where(x => x != null)
                .Distinct()
                .ToListAsync();

            return uniqueLicenseNames;
        }
    }
}