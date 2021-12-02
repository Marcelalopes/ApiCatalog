using Microsoft.EntityFrameworkCore;
using api_catalogo.models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_catalogo.EntityConfig
{
  public class CategoryConfig : IEntityTypeConfiguration<Category>
  {
    public void Configure(EntityTypeBuilder<Category> builder)
    {
      builder.ToTable("Categories");

      builder.HasKey(prop => prop.Id)
          .HasName("Pk_CategoryId");

      builder.Property(prop => prop.Name)
          .HasColumnType("varchar(100)")
          .IsRequired();
    }
  }
}