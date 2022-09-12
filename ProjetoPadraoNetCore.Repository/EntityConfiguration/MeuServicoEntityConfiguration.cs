using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoPadraoNetCore.Domain.Classes;

namespace ProjetoPadraoNetCore.Repository.EntityConfiguration
{
    public class MeuServicoEntityConfiguration : IEntityTypeConfiguration<MeuServico>
    {
        public void Configure(EntityTypeBuilder<MeuServico> builder)
        {
            builder.ToTable("TB_MYSERVICE");
            builder.HasKey(c => c.MeuServicoID).HasName("ID_MEUSERVICO");
            builder.Property(c => c.MeuServicoID).HasColumnName("ID_MEUSERVICO").ValueGeneratedOnAdd();
            builder.Property(c => c.MeuServicoNome).HasColumnName("NAME").HasMaxLength(100);
        }
    }
}
