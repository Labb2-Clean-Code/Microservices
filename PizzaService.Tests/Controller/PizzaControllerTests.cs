using FakeItEasy;
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
        [Trait("PizzaService", "GetAllPizzasFromController")]
        public async Task PizzaController_GetAllPizzas_ReturnsOk() {
            // Arrange
            var pizzas = A.Fake<IEnumerable<Pizza>>();
            A.CallTo(() => pizzaRepository.GetAllPizzas()).Returns(pizzas);
            var controller = new PizzaController(pizzaRepository);

            // Act
            var result = await controller.GetAllPizzas();

            // Assert
            Assert.NotNull(result);
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        [Trait("PizzaService", "AddPizzaThroughController")]
        public async Task PizzaController_AddPizza_ReturnsOk() {
            // Arrange
            var pizza = A.Fake<Pizza>();
            A.CallTo(() => pizzaRepository.AddPizza(pizza));
            var controller = new PizzaController(pizzaRepository);

            // Act
            var result = await controller.AddPizza(pizza);

            // Assert
            Assert.NotNull(result);
            result.Should().BeOfType(typeof(OkResult));
        }

    }
}
