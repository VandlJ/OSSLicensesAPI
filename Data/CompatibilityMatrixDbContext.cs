using Microsoft.EntityFrameworkCore;
using OSSApi.Models;

namespace OSSApi.Data;

public class CompatibilityMatrixDbContext : DbContext
{
    public CompatibilityMatrixDbContext(DbContextOptions<CompatibilityMatrixDbContext> options) : base(options)
    {
    }

    public DbSet<CompatibilityMatrix> CompatibilityMatrices { get; set; }
}



