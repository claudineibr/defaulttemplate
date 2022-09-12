using ProjetoPadraoNetCore.Domain.Classes;

namespace ProjetoPadraoNetCore.Domain.ViewModel
{
    public class CustomerViewModel
    {
        private readonly Customer Customer;

        public CustomerViewModel(Customer customer)
        {
            this.Customer = customer;
            if (!(this.Customer is null)) this.Map();
        }

        private void Map()
        {
            CustomerCode = this.Customer.CustomerCode;
            Name = this.Customer.Name;
            Document = this.Customer.Document;
            Email = this.Customer.Email;
        }

        public string CustomerCode { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
    }
}
