using Microsoft.EntityFrameworkCore;
using samplewebsite.Models;

namespace samplewebsite.Data;

public class BakeryContext : DbContext
{
    public BakeryContext(DbContextOptions<BakeryContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Product>().HasKey(p => p.Id);
        modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(255);
        modelBuilder.Entity<Product>().Property(p => p.Description).HasMaxLength(1000);
        modelBuilder.Entity<Product>().Property(p => p.ImageName).HasMaxLength(255);
    }
}
