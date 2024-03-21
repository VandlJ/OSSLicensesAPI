using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OSSApi.Models;

namespace OSSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompatibilityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompatibilityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CompatibilityMatrix/CheckCompatibility
        [HttpGet("CheckCompatibility")]
        public async Task<ActionResult<CompatibilityResponseModel>> CheckCompatibility(string license1, string license2)
        {
            // Retrieve compatibility for the provided licenses from the database
            var compatibilityResult = await _context.license_compatibility
                .Where(x => (x.License1 == license1 && x.License2 == license2) || (x.License1 == license2 && x.License2 == license1))
                .FirstOrDefaultAsync();

            if (compatibilityResult == null)
            {
                return NotFound();
            }

            // Determine the enum value based on the compatibility string
            CompatibilityResultE resultEnum;
            if (compatibilityResult.Compatibility == "Yes")
            {
                resultEnum = CompatibilityResultE.Yes;
            }
            else if (compatibilityResult.Compatibility == "No")
            {
                resultEnum = CompatibilityResultE.No;
            }
            else if (compatibilityResult.Compatibility == "Same")
            {
                resultEnum = CompatibilityResultE.Same;
            }
            else
            {
                // Treat any other result as Unknown
                resultEnum = CompatibilityResultE.Unknown;
            }

            // Create and return the response model with the compatibility result
            var responseModel = new CompatibilityResponseModel
            {
                CompatibilityResult = resultEnum
            };

            return responseModel;
        }
        
        // GET: api/CompatibilityMatrix/GetLicenses
        [HttpGet("GetLicenses")]
        public async Task<ActionResult<IEnumerable<string?>>> GetUniqueLicenseNames()
        {
            // Retrieve unique license names from the database
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
