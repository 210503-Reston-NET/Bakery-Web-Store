using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using SBL;
using SDL;
namespace SUI
{
    public class MenuFactory
    {
        /// <summary>
        /// common portal for delegating which menu to initialize based on the input
        /// </summary>
        /// <param name="menuSelect"></param>
        /// <returns></returns>
        public static InterfaceMenu GetMenu(string menuSelect)
        {
            //used to build a connection with the database
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            
            string connector = configuration.GetConnectionString("BakeryDB");
            DbContextOptions<BakeryDBContext> options = new DbContextOptionsBuilder<BakeryDBContext>()
            .UseSqlServer(connector)
            .Options;

            var context = new BakeryDBContext(options);
            switch(menuSelect.ToLower())
            {
                case "main":
                    return new MainMenu();
                case "order":
                    return new OrderMenu(new CustomerBL(new CustomerDB(context)), new OrderBL(new CustomerDB(context)));
                case "customer":
                    return new CustomerMenu(new CustomerBL(new CustomerDB(context)));
                case "location":
                    return new LocationMenu(new OrderBL(new CustomerDB(context)));
                default:
                    return null;
            }
        }
    }
}