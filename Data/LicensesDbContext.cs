using Microsoft.EntityFrameworkCore;
using OSSApi.Models;

namespace OSSApi.Data;

public class LicensesDbContext : DbContext
{
    public LicensesDbContext(DbContextOptions<LicensesDbContext> licenses) : base(licenses)
    {
        
    }
    
    public DbSet<Licenses> licenses { get; set; }
}