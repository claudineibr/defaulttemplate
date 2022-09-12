using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoPadraoNetCore.Domain.Classes;

namespace ProjetoPadraoNetCore.Repository.EntityConfiguration
{
    class CompanyEntityConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("TB_COMPANY");
            builder.HasKey(c => c.CompanyCode).HasName("CompanyCode");
            builder.Property(c => c.CompanyCode).HasColumnName("CompanyCode").HasMaxLength(100).IsRequired();
            builder.Property(c => c.Name).HasColumnName("Name").HasMaxLength(200).IsRequired();
            builder.Property(c => c.SmallName).HasColumnName("SmallName").HasMaxLength(45).IsRequired();
            builder.Property(c => c.LogoUrl).HasColumnName("LogoUrl").HasMaxLength(500);
            builder.Property(c => c.IsDefault).HasColumnName("IsDefault").HasColumnType("TINYINT(4)").IsRequired();
            builder.Property(c => c.IsActive).HasColumnName("IsActive").HasColumnType("TINYINT(4)").IsRequired();
            builder.Property(c => c.PrimaryColor).HasColumnName("PrimaryColor").HasMaxLength(10);
            builder.Property(c => c.SecondColor).HasColumnName("SecondColor").HasMaxLength(10);
            builder.Property(c => c.ThirdColor).HasColumnName("ThirdColor").HasMaxLength(10);
            builder.Property(c => c.CreateAt).HasColumnName("CreateAt").HasColumnType("DATETIME").IsRequired();
            builder.Property(c => c.UpdateAt).HasColumnName("UpdateAt").HasColumnType("DATETIME").IsRequired();
        }
    }
}