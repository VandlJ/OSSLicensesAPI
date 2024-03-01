using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OSSApi.Data;
using OSSApi.Models;
using Microsoft.EntityFrameworkCore;
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
        
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<Licenses>>> GetUsers()
        {
            var result = await _context.licenses.ToListAsync();
            if (result.Count == 0)
            {
                return NotFound(new { Title = "Nothing found", Status = "404" });
            }
            return Ok(result);
        }
        
        // GET: api/<LicensesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LicensesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LicensesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LicensesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LicensesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
