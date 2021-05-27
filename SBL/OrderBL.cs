using System;
using System.Collections.Generic;
using SModel;
using SDL;
namespace SBL
{
    public class OrderBL : IOrderBL
    {
        private ICustStorage _storage;
        public OrderBL(ICustStorage storage)
        {
            _storage = storage;
        }
        /// <summary>
        /// passes data to the database to add an order
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="order"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public Orders AddOrder(Customer customer, Orders orders, int location)
        {
            _storage.AddOrder(customer, orders, location);
            return orders;
        }

        /// <summary>
        /// returns a bread object from database based on given input
        /// </summary>
        /// <param name="breadType"></param>
        /// <returns></returns>
        public Bread GetBread(string breadType)
        {
            return _storage.GetBread(breadType);
        }
        
        public List<Orders> GetOrders(Customer customer)
        {
            List<Orders> OrderList = _storage.GetOrders(customer);
            return OrderList;
        }
        /// <summary>
        /// Returns order list for a location rather than a 
        /// </summary>
        /// <param name="bakery"></param>
        /// <returns></returns>
        public List<Orders> GetBakeryOrders(int location)
        {
            List<Orders> OrderList = _storage.GetBakeryOrders(location);
            return OrderList;
        }
        public List<Bread> GetBakeryInvertory(int location)
        {
            List<Bread> INVList = _storage.GetBakeryInventory(location);
            return INVList;
        }

        public void UpdateInventory(int locationID, int BreadType, int moreBread)
        {
            _storage.UpdateInventory(locationID, BreadType, moreBread);
        }
        
    }
}