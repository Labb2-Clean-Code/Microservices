using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaService;
using PizzaService.Interfaces;
using PizzaService.Models;
using PizzaService.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace PizzaService.Tests.Controller {
    public class PizzaControllerTests {

        private readonly IPizzaRepository pizzaRepository;

        public PizzaControllerTests() {
            pizzaRepository = A.Fake<IPizzaRepository>();
        }

        [Fact]
        public async Task OrderServiceController_GetAllOrders_ReturnsOk() {
            // Arrange
            var orders = A.Fake<IEnumerable<Pizza>>();
            A.CallTo(() => pizzaRepository.GetAllPizzas()).Returns(orders);
            var controller = new PizzaController(pizzaRepository);

            // Act
            var result = await controller.GetAllPizzas();

            // Assert
            Assert.NotNull(result);
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async Task OrderServiceController_AddOrder_ReturnsOk() {
            // Arrange
            var pizza = A.Fake<Pizza>();
            A.CallTo((object)(() => pizzaRepository.AddPizza(pizza)));
            var controller = new PizzaController(pizzaRepository);

            // Act
            var result = await controller.AddPizza(pizza);

            // Assert
            Assert.NotNull(result);
            result.Should().BeOfType(typeof(OkObjectResult));
        }

    }
}
