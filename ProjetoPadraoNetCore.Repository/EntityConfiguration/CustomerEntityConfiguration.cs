using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoPadraoNetCore.Domain.Classes;

namespace ProjetoPadraoNetCore.Repository.EntityConfiguration
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("TB_CUSTOMER");
            builder.HasKey(c => c.CustomerCode).HasName("CustomerCode");
            builder.Property(c => c.CustomerCode).HasColumnName("CustomerCode").HasMaxLength(100).IsRequired();
            builder.Property(c => c.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            builder.Property(c => c.Document).HasColumnName("Document").HasMaxLength(100).IsRequired();
            builder.Property(c => c.Email).HasColumnName("Email").HasMaxLength(100).IsRequired();
            builder.Property(c => c.Password).HasColumnName("Password").HasMaxLength(200).IsRequired();
        }
    }
}
