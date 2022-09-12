using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoPadraoNetCore.Domain.Classes
{
    public class Customer
    {
        public string CustomerCode { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
