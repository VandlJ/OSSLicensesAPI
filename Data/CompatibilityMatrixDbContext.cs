using Microsoft.EntityFrameworkCore;
using OSSApi.Models;

namespace OSSApi.Data;

public class CompatibilityMatrixDbContext : DbContext
{
    public CompatibilityMatrixDbContext(DbContextOptions<CompatibilityMatrixDbContext> compatibilityMatrix) : base(compatibilityMatrix)
    {
        
    }
    
    public DbSet<CompatibilityMatrix> compatibilityMatrix { get; set; }
}



