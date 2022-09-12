using ProjetoPadraoNetCore.Domain.Classes;
using ProjetoPadraoNetCore.Domain.IRepository;
using System;

namespace ProjetoPadraoNetCore.Repository.Repositories
{
    public class MeuServicoRepository : IMeuServicoRepository
    {
        private readonly ProjetoPadraoNetCoreDBContext context;

        public MeuServicoRepository(ProjetoPadraoNetCoreDBContext _contex)
        {
            this.context = _contex;
        }

        public MeuServico GetMeuServico(int id)
        {
            throw new NotImplementedException();
        }
    }
}
