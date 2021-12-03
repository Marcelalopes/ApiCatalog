using Microsoft.EntityFrameworkCore;
using api_catalogo.models;
using api_catalogo.EntityConfig;

namespace api_catalogo.Context
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Category> Category { get; set; }
    public DbSet<Product> Product { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Category>(new CategoryConfig().Configure);
      modelBuilder.Entity<Product>(new ProductConfig().Configure);
    }
  }

}