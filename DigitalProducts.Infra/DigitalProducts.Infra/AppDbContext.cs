using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DigitalProducts.Infra;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Cartsproduct> Cartsproducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Typeproduct> Typeproducts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=ManagementProducts;Username=postgres;Port=5432;Password=server;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("carts_pkey");

            entity.ToTable("carts");

            entity.HasIndex(e => e.Userid, "carts_userid_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createat");
            entity.Property(e => e.Productsid).HasColumnName("productsid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Products).WithMany(p => p.Carts)
                .HasForeignKey(d => d.Productsid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("carts_productsid_fkey");

            entity.HasOne(d => d.User).WithOne(p => p.Cart)
                .HasForeignKey<Cart>(d => d.Userid)
                .HasConstraintName("carts_userid_fkey");
        });

        modelBuilder.Entity<Cartsproduct>(entity =>
        {
            entity.HasKey(e => new { e.Cartid, e.Productid }).HasName("cartsproducts_pkey");

            entity.ToTable("cartsproducts");

            entity.Property(e => e.Cartid).HasColumnName("cartid");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1)
                .HasColumnName("quantity");

            entity.HasOne(d => d.Cart).WithMany(p => p.Cartsproducts)
                .HasForeignKey(d => d.Cartid)
                .HasConstraintName("cartsproducts_cartid_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.Cartsproducts)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cartsproducts_productid_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pkey");

            entity.ToTable("products");

            entity.HasIndex(e => e.Typeproductid, "products_typeproductid_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Creatorid).HasColumnName("creatorid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(2, 10)
                .HasColumnName("price");
            entity.Property(e => e.Typeproductid).HasColumnName("typeproductid");

            entity.HasOne(d => d.Creator).WithMany(p => p.Products)
                .HasForeignKey(d => d.Creatorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_creatorid_fkey");

            entity.HasOne(d => d.Typeproduct).WithOne(p => p.Product)
                .HasForeignKey<Product>(d => d.Typeproductid)
                .HasConstraintName("products_typeproductid_fkey");
        });

        modelBuilder.Entity<Typeproduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("typeproducts_pkey");

            entity.ToTable("typeproducts");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Productype).HasColumnName("productype");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
