using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SModel;
namespace BakeryWebUI.Models
{
    /// <summary>
    /// Restaurant View Model Class
    /// </summary>
    public class CustomerVM
    {
        public CustomerVM(Customer customer)
        {
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;

        }
        public CustomerVM()
        {

        }
        public int Id { get; set; }


        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public List<Orders> OrderList { get; set; }

    }
}
