using Microsoft.EntityFrameworkCore;
using OSSApi.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<CompatibilityMatrix> compatibility_matrix { get; set; }
    public DbSet<Licenses> licenses { get; set; }
}