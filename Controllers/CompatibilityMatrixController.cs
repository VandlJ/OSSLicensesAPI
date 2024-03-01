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
        private readonly ApplicationDbContext _context;

        public CompatibilityMatrixController(ApplicationDbContext context)
        {
            _context = context;
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
    }
}
