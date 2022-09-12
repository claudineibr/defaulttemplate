using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoPadraoNetCore.Domain.Classes;

namespace ProjetoPadraoNetCore.Repository.EntityConfiguration
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("TB_PRODUCT");
            builder.HasKey(c => c.ProductCode).HasName("ProductCode");
            builder.Property(c => c.ProductCode).HasColumnName("ProductCode").HasMaxLength(100).IsRequired();
            builder.Property(c => c.CategoryCode).HasColumnName("CategoryCode").HasMaxLength(100).IsRequired();
            builder.Property(c => c.Name).HasColumnName("Name").HasMaxLength(200).IsRequired();
            builder.Property(c => c.Description).HasColumnName("Description").HasMaxLength(8000);
            builder.Property(c => c.Price).HasColumnName("Price").HasColumnType("DECIMAL(16,4)").IsRequired();
            builder.Property(c => c.CreateAt).HasColumnName("CreateAt").HasColumnType("DATETIME").IsRequired();
            builder.Property(c => c.UpdateAt).HasColumnName("UpdateAt").HasColumnType("DATETIME").IsRequired();
            builder.HasOne(c => c.Category).WithMany().HasForeignKey(p => p.CategoryCode).IsRequired();
            builder.HasOne(c => c.Company).WithMany().HasForeignKey(p => p.CompanyCode).IsRequired();
            builder.HasMany(c => c.Images).WithOne(p => p.Product).HasForeignKey(f => f.ProductCode).IsRequired(false);
        }
    }
}
