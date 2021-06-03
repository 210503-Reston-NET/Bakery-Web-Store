using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SModel;

namespace BakeryWebUI.Models
{
    public class LocationVM
    {
        public LocationVM()
        {

        }
        public LocationVM(Bakery bakery)
        {
            Id = bakery.BakeryId;
            BakeryName = bakery.BakeryName;
            City = bakery.City;
            State = bakery.State;
        }

        public int Id { get; set; }
        public string BakeryName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
