using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SModel;
namespace BakeryWebUI.Models
{
    public class InventoryVM
    {
        public InventoryVM()
        {

        }
        public InventoryVM(InventoryVM invVM)
        {
            Stock = invVM.Stock;
            ProductId = invVM.ProductId;
        }
        public InventoryVM(string bread, int stock, int prodId)
        {
            Stock = stock;
            ProductId = prodId;
            breadName = bread;
        }
        public int Id { get; set; }

        //Attribute
        public int Stock { get; set; }

        //Foreign Keys
        public int ProductId { get; set; }
        public int StoreId { get; set; }

        public string breadName { get; set; }
    }
}
