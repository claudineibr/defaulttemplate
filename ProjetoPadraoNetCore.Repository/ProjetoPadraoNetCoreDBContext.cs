using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjetoPadraoNetCore.Domain.Classes;
using ProjetoPadraoNetCore.Repository.EntityConfiguration;

namespace ProjetoPadraoNetCore.Repository
{
    public class ProjetoPadraoNetCoreDBContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        public ProjetoPadraoNetCoreDBContext(DbContextOptions<ProjetoPadraoNetCoreDBContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            this._loggerFactory = loggerFactory;
        }

        public DbSet<MeuServico> MeuServico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigEntity(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(this._loggerFactory);
        }

        private void ConfigEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MeuServicoEntityConfiguration());
        }
    }
}
