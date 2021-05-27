using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace SModel
{
    public class Customer
    {
        public Customer()
        {

        }
        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Customer(int id, string firstName, string lastName) : this(firstName, lastName)
        {
            this.Id = id;
        }

        //public void addOrder(Orders order){
            //OrderList = new List<Orders>();
            //OrderList.Add(order);
        //}

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        public string FirstName{ get; set; }

        public string LastName{ get; set; }
        public List<Orders> OrderList { get; set; }

        public override string ToString()
        {
            return $"Customer Name: {FirstName}, {LastName}";
        }
    }
}