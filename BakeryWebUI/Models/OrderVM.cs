using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SModel;
using System.ComponentModel.DataAnnotations;

namespace BakeryWebUI.Models
{
    public class OrderVM
    {
        public OrderVM()
        {

        }
        public OrderVM(int custID)
        {
            CustomerId = custID;
        }
        public OrderVM(Orders order)
        {
            Id = order.Id;
            CustomerId = order.CustomerId;
            BreadCount = order.BreadCount;
            OrderTotal = order.OrderTotal;
            bakery = order.bakery;
            BreadType = order.Loaf.Breadtype;
        }

        public int Id;
        [Required]
        public int BreadCount { get; set; }
        public double OrderTotal { get; set; }
        [Required]
        public string BreadSelection { get; set; }
        [Required]
        public int LocationSelection { get; set; }

        public string BreadType { get; set; }

        public Bread Loaf { get; set; }
        public Bakery bakery { get; set; }

        //foreign Keys
        [Required]
        public int CustomerId { get; set; }
        public int BakeryId { get; set; }
    }
}
