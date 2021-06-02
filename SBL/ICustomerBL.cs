using System.Collections.Generic;
using SModel;
namespace SBL
{
    public interface ICustomerBL
    {
        Customer AddCustomer(Customer customer);

        Customer GetCustomer(Customer customer);

        Customer GetCustomerById(int id);

        List<Customer> GetAllCustomers();

    }
}