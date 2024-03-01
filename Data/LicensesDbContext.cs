using Microsoft.EntityFrameworkCore;
using OSSApi.Models;

namespace OSSApi.Data;

public class LicensesDbContext : DbContext
{
    public LicensesDbContext(DbContextOptions<LicensesDbContext> options) : base(options)
    {
    }

    public DbSet<Licenses> Licenses { get; set; }
}