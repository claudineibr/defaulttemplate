using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ProjetoPadraoNetCore.ApplicationService;
using ProjetoPadraoNetCore.Domain.IApplicationService;
using ProjetoPadraoNetCore.Domain.IRepository;
using ProjetoPadraoNetCore.Domain.Utilities;
using ProjetoPadraoNetCore.Repository;
using ProjetoPadraoNetCore.Repository.Repositories;
using System;

namespace ProjetoPadraoNetCore.Test
{
    [TestClass]
    public class MeuServicoApplicationUnitTest
    {
        private IMeuServicoApplicationService meuServico;

        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                var services = new ServiceCollection();
                services.AddDbContext<ProjetoPadraoNetCoreDBContext>(option => option.UseMySql(Config.ConnectionString, mySqlOptions =>
                {
                    mySqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql); // replace with your Server Version and Type
                }));
                services.AddScoped<DbContext>(sp => sp.GetService<ProjetoPadraoNetCoreDBContext>());
                services.AddTransient<IMeuServicoRepository, MeuServicoRepository>();
                services.AddTransient<IMeuServicoApplicationService, MeuServicoApplicationService>();

                var serviceProvider = services.BuildServiceProvider();

                meuServico = serviceProvider.GetService<IMeuServicoApplicationService>();

                var result = meuServico.GetMeuServico(1);

                Assert.IsNotNull(result);
            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.Message);
            }    
        }
    }
}
