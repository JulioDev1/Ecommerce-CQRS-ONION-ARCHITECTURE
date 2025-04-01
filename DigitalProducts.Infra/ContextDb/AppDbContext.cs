using Microsoft.EntityFrameworkCore;

namespace DigitalProducts.Infra.ContextDb
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions)
            : base(dbContextOptions)
        { }

        public DbSet<Product>

    }
}
