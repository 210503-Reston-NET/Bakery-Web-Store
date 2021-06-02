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
        public void RestaurantControllerIndexShouldReturnList()
        {
            //Arrange
            var mockBL = new Mock<ICustomerBL>();
            mockBL.Setup(x => x.GetAllCustomers()).Returns(
                new List<Customer>()
                {
                    new Customer("Adam", "Sandler"),
                    new Customer("Jim", "Beam")
                }
                );
            var controller = new CustomerController(mockBL.Object);
            //Act
            var result = controller.Index();
            //Assert
            //Check that we're getting a view as a result
            var viewResult = Assert.IsType<ViewResult>(result);
            //Check that the model of the viewResult is a list of restaurant VMs
            var model = Assert.IsAssignableFrom<IEnumerable<CustomerVM>>(viewResult.ViewData.Model);
            //Check that we're getting the same amount of restaurants that we're returning
            Assert.Equal(2, model.Count());
        }
    }
}
