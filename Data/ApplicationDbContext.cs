using Microsoft.EntityFrameworkCore;
using OSSApi.Models;

// Represents the application's database context
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Represents the DbSet for the LicenseCompatibility entity
    public DbSet<LicenseCompatibility> license_compatibility { get; set; }
}