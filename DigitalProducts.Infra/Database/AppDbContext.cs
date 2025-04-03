using DigitalProducts.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalProducts.Infra.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartsProduct> CartsProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<TypeProduct> TypeProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
               .HasOne(p => p.TypeProduct)
               .WithOne(tp => tp.Product)
               .HasForeignKey<Product>(p => p.TypeProductId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Products)
                .WithMany(p => p.Carts)
                .UsingEntity<CartsProduct>(
                    c => c.HasOne(e => e.Product).WithMany(e => e.CartProducts),
                    c => c.HasOne(e => e.Cart).WithMany(e => e.CartProducts)
                );
        }
    }

}

