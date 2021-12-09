using Microsoft.EntityFrameworkCore;
using api_catalogo.models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_catalogo.EntityConfig
{
  public class ProductConfig : IEntityTypeConfiguration<Product>
  {
    public void Configure(EntityTypeBuilder<Product> builder)
    {
      builder.ToTable("Products");

      builder.HasKey(prop => prop.Id)
          .HasName("Pk_ProductId");

      builder.Property(prop => prop.Name)
          .HasColumnType("varchar(80)")
          .IsRequired();
      builder.Property(prop => prop.Description)
          .HasColumnType("varchar(255)")
          .IsRequired();
      builder.Property(prop => prop.Price)
          .HasColumnType("decimal")
          .HasPrecision(10, 2)
          .IsRequired();
      builder.Property(prop => prop.Inventory)
          .HasColumnType("int")
          .IsRequired();
      builder.Property(prop => prop.RegistrationDate)
          .HasColumnType("datetime")
          .IsRequired();
      builder.HasOne(p => p.Category)
          .WithMany(c => c.Products)
          .HasForeignKey(p => p.CategoryId)
          .IsRequired();
    }
  }
}