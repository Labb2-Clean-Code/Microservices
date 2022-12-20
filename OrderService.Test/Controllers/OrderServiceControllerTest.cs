using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderService.Controllers;
using OrderService.Models;
using OrderService.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderService.Test.Controllers
{
    [TestClass]
    public class OrderServiceControllerTest
    {
        private readonly IGetAllOrders _getAllOrders;
        private readonly IAddOrder _addOrder;

        public OrderServiceControllerTest()
        {
            _getAllOrders = A.Fake<IGetAllOrders>();
            _addOrder = A.Fake<IAddOrder>();
        }

        [TestMethod]
        public async Task OrderServiceController_GetAllOrders_ReturnsOk()
        {
            // Arrange
            var orders = A.Fake<IEnumerable<Order>>();
            A.CallTo(() => _getAllOrders.GetAllOrders()).Returns(orders);
            var controller = new OrderServiceController(_getAllOrders, _addOrder);

            // Act
            var result = await controller.GetAllOrders();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task OrderServiceController_AddOrder_ReturnsOk()
        {
            // Arrange
            var order = A.Fake<Order>();
            A.CallTo(() => _addOrder.AddOrder(order));
            var controller = new OrderServiceController(_getAllOrders, _addOrder);

            // Act
            var result = await controller.AddOrder(order);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
