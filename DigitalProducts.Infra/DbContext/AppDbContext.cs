using DigitalProducts.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalProducts.Infra;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public  DbSet<Cart> Carts { get; set; }
    public  DbSet<CartProduct> CartsProducts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<TypeProduct> TypeProducts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Products)
            .WithOne(p => p.Creator)
            .HasForeignKey(p => p.CreatorId)
            .IsRequired();

        modelBuilder.Entity<Product>()
            .HasOne(p => p.TypeProduct)
            .WithOne(tp => tp.Product)
            .HasForeignKey<Product>(p => p.TypeProductId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Cart>()
            .HasMany(c => c.Products)
            .WithMany(p => p.Carts)
            .UsingEntity<CartProduct>(
                c => c.HasOne<Product>(e=> e.Products).WithMany(e=> e.CartProducts),
                c => c.HasOne<Cart>(e => e.Carts).WithMany(e => e.CartProducts)
            );
    }
}
