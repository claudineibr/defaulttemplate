using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjetoPadraoNetCore.Domain.Classes;
using ProjetoPadraoNetCore.Repository.EntityConfiguration;

namespace ProjetoPadraoNetCore.Repository
{
    public class ProjetoPadraoNetCoreDBContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        public ProjetoPadraoNetCoreDBContext(
            DbContextOptions<ProjetoPadraoNetCoreDBContext> options, 
            ILoggerFactory loggerFactory) 
            : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public DbSet<MeuServico> MeuServico { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Company> Company { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigEntity(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }

        private void ConfigEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("myservice");
            modelBuilder.ApplyConfiguration(new MeuServicoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ImageEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
        }
    }
}
