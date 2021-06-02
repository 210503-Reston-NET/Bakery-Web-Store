using System.Collections.Generic;
using SModel;
using SDL;
namespace SBL
{
    public class CustomerBL : ICustomerBL
    {
        private ICustStorage storage;

        public CustomerBL(ICustStorage stor)
        {
            storage = stor;
        }
        public Customer AddCustomer(Customer customer)
        {
            return storage.AddCustomer(customer);
        }
        public Customer GetCustomerById(int id)
        {
            return storage.GetCustomerById(id);
        }

        public Customer GetCustomer(Customer customer)
        {
            return storage.GetCustomer(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return storage.GetAllCustomers();
        }
    }
}