using System.Collections.Generic;
using SModel;
namespace SDL
{
    public interface ICustStorage
    {
        /// <summary>
        /// sends a new customer object to be stores on the database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        Customer AddCustomer(Customer customer);
        Customer GetCustomer(Customer customer);

        Orders AddOrder(Customer customer, Orders order, int location);
        List<Orders> GetOrders(Customer customer);
        
        List<Orders> GetBakeryOrders(int location);
        List<Bread> GetBakeryInventory(int locationID);
        void UpdateInventory(int locationID, int BreadType, int moreBread);
        List<Customer> GetAllCustomers();

         Bread GetBread(string breadtype);
    }
}