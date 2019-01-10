using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoPadraoNetCore.Domain.ViewModel
{
    public class MeuServicoViewModel
    {
        /// <summary>
        /// ID do serviço
        /// </summary>
        public int MeuServicoID { get; set; }

        /// <summary>
        /// Nome do Serviço
        /// </summary>
        public string MeuServicoNome { get; set; }
    }
}
