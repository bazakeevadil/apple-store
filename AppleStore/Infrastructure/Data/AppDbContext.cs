using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var product = modelBuilder.Entity<Product>();
        product.HasIndex(p => p.Name).IsUnique();
        product.Property(p => p.Name).UseCollation("SQL_Latin1_General_CP1_CI_AS");

        var category = modelBuilder.Entity<Category>();
        category.HasIndex(c => c.Name).IsUnique();
        category.Property(c => c.Name).UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Product>().Navigation(p => p.Category).AutoInclude();
    }
}
