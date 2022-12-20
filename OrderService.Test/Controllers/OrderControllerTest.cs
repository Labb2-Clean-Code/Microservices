using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderService.Controllers;
using OrderService.Domain;
using OrderService.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderService.Test.Controllers
{
    [TestClass]
    public class OrderControllerTest
    {
        private readonly IOrderRepository orderRepository;

        public OrderControllerTest()
        {
            orderRepository = A.Fake<IOrderRepository>();
        }

        [TestMethod]
        public async Task OrderServiceController_GetAllOrders_ReturnsOk()
        {
            // Arrange
            var orders = A.Fake<IEnumerable<Order>>();
            A.CallTo(() => orderRepository.GetAllOrders()).Returns(orders);
            var controller = new OrderServiceController(orderRepository);

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
            A.CallTo(() => orderRepository.AddOrder(order));
            var controller = new OrderServiceController(orderRepository);

            // Act
            var result = await controller.AddOrder(order);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}
