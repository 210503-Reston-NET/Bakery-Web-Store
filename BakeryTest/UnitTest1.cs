using Microsoft.AspNetCore.Mvc;
using Moq;
using SBL;
using SModel;
using BakeryWebUI.Controllers;
using BakeryWebUI.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace BakeryTest
{
    public class UnitTest1
    {
        [Fact]
        public void CustomerControllerIndexList1()
        {
            //Arrange
            var mockBL = new Mock<ICustomerBL>();
            mockBL.Setup(x => x.GetAllCustomers()).Returns(
                new List<Customer>()
                {
                    new Customer("Adam", "Sandler"),
                    new Customer("Jim", "Beam"),
                    new Customer("Angie", "Morna")
                }
                );
            var controller = new CustomerController(mockBL.Object);
            var result = controller.Index();
 
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CustomerVM>>(viewResult.ViewData.Model);

            Assert.Equal(3, model.Count());
        }

        [Fact]
        public void CustomerControllerIndexList2()
        {
            var mockBL = new Mock<ICustomerBL>();
            mockBL.Setup(x => x.GetAllCustomers()).Returns(
                new List<Customer>()
                {
                    new Customer("Adam", "Sandler"),
                    new Customer("Jim", "Beam"),
                    new Customer("Angie", "Morna"),
                    new Customer("Morgan", "Thall")
                }
                );
            var controller = new CustomerController(mockBL.Object);
            var result = controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<CustomerVM>>(viewResult.ViewData.Model);
            Assert.Equal(4, model.Count());
        }
        /*[Fact]
        public void LocationControllerTest()
        {
            var MockBL = newMock<IOrderBL>();

        }*/
        [Fact]
        public void BakeryTest()
        {
            
            Bakery test = new Bakery("Bakery", "Mobile", "AL");
            string state = "AL";

            Assert.Equal(state, test.State);
        }

        [Fact]
        public void CustomerTest()
        {

            Customer test = new Customer("Andrew", "Wear");
            string firstName = "Andrew";
            string lastName = "Wear";

            Assert.Equal(test.FirstName, firstName);
        }
        [Fact]
        public void OrderTest()
        {

            Orders test = new Orders(1, new Bread(1, "Brioche", 2.00), 4);
            string s = "Brioche";
            Assert.Equal(s, test.Loaf.Breadtype);

        }
    }
}
