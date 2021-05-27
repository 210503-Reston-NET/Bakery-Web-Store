using System;
using System.Collections.Generic;
using SModel;
namespace SUI
{
    
    public class MainMenu : InterfaceMenu
    {
        //test structure for functionality
        private InterfaceMenu menuPortal;
        public void Launch(){
            bool exit = false;
            do
            {
                string selection;

                Console.WriteLine("Welcome to the Pheonix Bakery Coalition");
                Console.WriteLine("Please enter a correspoonding number to select an option");
                Console.WriteLine("[1]: Place an Order");
                Console.WriteLine("[2]: Customer Add/Search");
                Console.WriteLine("[3]: Location Search");
                Console.WriteLine("[4]: Quit");


                selection = Console.ReadLine();


                switch(selection)
                {
                    case "1":
                        menuPortal = MenuFactory.GetMenu("order");
                        menuPortal.Launch();
                        break;
                    case "2":
                        menuPortal = MenuFactory.GetMenu("customer");
                        menuPortal.Launch();
                        break;  
                    case "3":
                        menuPortal = MenuFactory.GetMenu("location");
                        menuPortal.Launch();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please Select a Valid Option");
                        exit = false;
                        break;
                }
            }while(exit == false);
        }
    }
}