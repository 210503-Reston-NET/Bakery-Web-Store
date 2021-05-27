using System;
using System.Collections.Generic;
using SBL;
using SModel;
namespace SUI
{
    /// <summary>
    /// Handles Bakery Related functions
    /// </summary>
    public class LocationMenu : InterfaceMenu
    {
        /// <summary>
        /// connection to buildlayer 
        /// </summary>
        private IOrderBL _orderBL;

        /// <summary>
        /// Preset password for login verification
        /// </summary>
        private string pass = "password";
        private string secureLogin;
        /// <summary>
        /// Handles location relation functions
        /// </summary>
        /// <param name="oBL"></param>
        public LocationMenu(IOrderBL oBL)
        {
            _orderBL = oBL;
        }
        public void Launch()
        {
            string adOrder;
            int location;
            int AdditionalBread;
            int breadNum;
            Console.WriteLine("Welcome to the location portal");
            Console.WriteLine("Please Choose an Option");
            Console.WriteLine("[1] View Orders by Location");
            Console.WriteLine("[2] View Bakery Inventory");
            Console.WriteLine("[3] Update Bakery Inventory(Managers Only)");
            adOrder = Console.ReadLine();
            switch(adOrder)
            {
                case "1":
                    location = LocationSelector();
                    ViewLocationOrders(location);
                    break;
                case "2":
                    location = LocationSelector();
                    ViewLocationInventory(location);
                    break;
                case "3":
                    location = LocationSelector();
                    Console.WriteLine("This is a Manager only section, Please Enter the secret password");
                    secureLogin = Console.ReadLine();
                    if(secureLogin == pass){}
                    else{
                        Console.WriteLine("Stop! you violated the law, pay the court a fine or server your sentence");
                        break;
                    }
                    Console.WriteLine("Welcome Lord Manager!");
                    Console.WriteLine("Please enter the bread you would like to update");
                    breadNum = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter how many you would like to add");
                    AdditionalBread = Convert.ToInt32(Console.ReadLine());
                    UpdateInventory(location, breadNum, AdditionalBread);
                    break;
                default:
                    Console.WriteLine("invalid input. Please select a valid option");
                    break;
            }
        }

        private void ViewLocationOrders(int local)
        {
            List<Orders> orderResult = _orderBL.GetBakeryOrders(local);
            foreach(Orders o in orderResult)
            {
                Console.WriteLine(o.ToString());
            }

        }
        private void ViewLocationInventory(int local)
        {
            List<Bread> orderResult = _orderBL.GetBakeryInvertory(local);
            foreach(Bread o in orderResult)
            {
                Console.WriteLine(o.ToString());
            }
        }

        private void UpdateInventory(int local, int id, int moreBeard)
        {
            _orderBL.UpdateInventory(local,id,moreBeard);
        }

        private int LocationSelector()
        {
            string num;
            int selection = 0;
            bool isValid = true;
            Console.WriteLine("Please Select you local bakery: ");
            Console.WriteLine("[1]: Bens Bakery ");
            Console.WriteLine("[2]: Suzies");
            Console.WriteLine("[3]: SD Breads & More");
            Console.WriteLine("[4]: Pita Palace");
            Console.WriteLine("[5]: Wheat Workers");
            Console.WriteLine("[6]: Bread Store");
            Console.WriteLine("[7]: Chomps");
            Console.WriteLine("[8]: Matzo & More");
            Console.WriteLine("[9]: Bens Bakery");
            num = Console.ReadLine();
            
            do{
                switch(num)
                {
                    case "1":
                        isValid = true;
                        selection = 1; 
                        break;
                    case "2":
                        isValid = true;
                        selection = 2;
                        break;
                    case "3":
                        isValid = true;
                        selection = 3;
                        break; 
                    case "4":
                        isValid = true;
                        selection = 4;
                        break; 
                    case "5":
                        isValid = true;
                        selection = 5;
                        break; 
                    case "6":
                        isValid = true;
                        selection = 6;
                        break; 
                    case "7":
                        isValid = true;
                        selection = 7;
                        break; 
                    case "8":
                        isValid = true;
                        selection = 8;
                        break; 
                    case "9":
                        isValid = true;
                        selection = 9;
                        break;
                    default:
                        isValid = false;
                        Console.WriteLine("invalid input. Please select a valid option");
                        break;
                }
            }while(isValid == false);
            return selection;
        }
    }
}