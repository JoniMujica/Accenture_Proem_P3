using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace WebAPI.Models.Configuration
{
    public class ArticuloConfiguration : IEntityTypeConfiguration<Articulo>
    {
        public void Configure(EntityTypeBuilder<Articulo> builder)
        {
            builder.ToTable("LosArticulos");
            builder.Property(p => p.Nombre).HasMaxLength(50);
            builder.HasIndex(p => p.Nombre);
        }
    }
}
