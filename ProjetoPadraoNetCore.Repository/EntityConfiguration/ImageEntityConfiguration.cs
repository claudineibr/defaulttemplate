using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoPadraoNetCore.Domain.Classes;

namespace ProjetoPadraoNetCore.Repository.EntityConfiguration
{
    public class ImageEntityConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("TB_IMAGE");
            builder.HasKey(c => c.ImageCode).HasName("ImageCode");
            builder.Property(c => c.ImageCode).HasColumnName("ImageCode").HasMaxLength(100).IsRequired();
            builder.Property(c => c.ProductCode).HasColumnName("ProductCode").HasMaxLength(100).IsRequired();
            builder.Property(c => c.Name).HasColumnName("Name").HasMaxLength(20).IsRequired();
            builder.Property(c => c.Url).HasColumnName("Url").HasMaxLength(5000).IsRequired();
        }
    }
}