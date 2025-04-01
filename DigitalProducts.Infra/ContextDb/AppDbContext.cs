using DigitalProducts.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalProducts.Infra.ContextDb
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions)
            : base(dbContextOptions)
        { 
        }
        public DbSet<User> Users { get; set; }
        public DbSet<TypeProduct> typeProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> cartProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
