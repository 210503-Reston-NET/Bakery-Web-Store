using System;
using SModel;
using System.Collections.Generic;
using System.Linq;
using SBL;
namespace SUI
{
    public class OrderMenu : InterfaceMenu  
    {
        private ICustomerBL _BreadBL;
        private IOrderBL _OrderBL;


        public OrderMenu(ICustomerBL cBL, IOrderBL oBL)
        {
            _BreadBL = cBL;
            _OrderBL = oBL;
        }
        
        public void Launch()
        {
            

            string firstName;
            string lastName;
            string selection;
            int BakeryLocal;
            
            bool exit = false;
            
            
            
            Console.WriteLine("Order Screen");
            Console.WriteLine("Please Enter your name to login.");
            Console.WriteLine("If you are a new user a new account will be created automatically");
            Console.WriteLine("Please Enter your First Name");
            firstName = Console.ReadLine();
            Console.WriteLine("Please Enter your Last Name");
            lastName = Console.ReadLine();

            
            
            Customer customer = _BreadBL.GetCustomer(new Customer(firstName, lastName));
            if(customer != null){
                Console.WriteLine($"Welcome Back Customer: {customer.LastName}");
            }
            else{
                customer = new Customer(firstName, lastName);
                Console.WriteLine($"New Customer Added: {customer.LastName}!");
            }
            

            

            do{
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] Add an new order");
                Console.WriteLine("[2] View your order history");
                Console.WriteLine("[3] Go back");
                selection = Console.ReadLine();
                switch(selection)
                {
                    case "1":
                        BakeryLocal = LocationSelector();
                        AddOrder(customer, BakeryLocal);
                        break;
                    case "2":
                        ViewOrders(customer);
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("invalid input. Please select a valid option");
                        break;
                }
            }while(!exit); 
            MenuFactory.GetMenu("main").Launch();  
        }
        /// <summary>
        /// Handles communivating with the buisness layer passing an order object.
        /// Additional order compaitible
        /// </summary>
        /// <param name="customer"></param>
        
        private void AddOrder(Customer customer, int local)
        {
            
                bool additionalOrder = true;
            do
            {
                string orderString = "";
                string adOrder;
                int count = 0;
                
                if(customer != null)
                {
                    
                    Console.WriteLine("Please Enter a bread type you would like to order");
                    orderString = Console.ReadLine();
                    Console.WriteLine("How many would you like to order?");
                    count = Convert.ToInt32(Console.ReadLine());
                    Bread getBread = _OrderBL.GetBread(orderString);
                    Console.WriteLine(getBread.ToString());
                    _OrderBL.AddOrder(customer, (new Orders(getBread, count)), local);
                }


                Console.WriteLine("Would you like to place an additional order?");
                Console.WriteLine("[1] Yes");
                Console.WriteLine("[2] no");
                adOrder = Console.ReadLine();
                switch(adOrder)
                {
                    case "1":
                        additionalOrder = true;
                        break;
                    case "2":
                        additionalOrder = false;
                        break;
                    default:
                        Console.WriteLine("invalid input. Please select a valid option");
                        break;
                }
            }while(additionalOrder);
            
            
            
            
            
        }
        /// <summary>
        /// gets a lost of orders and write them to console
        /// </summary>
        /// <param name="customer"></param>
        private void ViewOrders(Customer customer)
        {
            List<Orders> orderResult = _OrderBL.GetOrders(customer);
            foreach(Orders o in orderResult)
            {
                Console.WriteLine(o.ToString());
            }
        }
        /// <summary>
        /// Reusable code allowing user to select which store they would like to buy from
        /// </summary>
        /// <returns></returns>
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
            }while(!isValid);
            return selection;
        }
    }
}