using System;
using System.Collections.Generic;
using SModel;
namespace SBL
{
    public interface IOrderBL
    {
        
        Orders AddOrder(Customer customer, Orders order, int location);
        List<Orders> GetOrders(Customer customer);
        List<Orders> GetBakeryOrders(int location);
        List<Bread> GetBakeryInvertory(int location);

        List<Bakery> GetBakeries();

        BakeryInventory GetInventoryByID(int id);
        void UpdateInventory(int locationID, int BreadType, int moreBread);
        Bread GetBread(string breadType);

    }
}