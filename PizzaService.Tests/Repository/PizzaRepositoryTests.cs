using Microsoft.EntityFrameworkCore;
using PizzaService.Data;
using PizzaService.Repositories;
using PizzaService.Models;
using FluentAssertions;

namespace PizzaService.Tests.Repository {
    public class PizzaRepositoryTests {
        private static async Task<DataContext> GetDatabaseContext() {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new DataContext(options);
            databaseContext.Database.EnsureCreated();
            if (!await databaseContext.Pizzas.AnyAsync()) {
                databaseContext.Add(
                    new Pizza {

                        Id = 1,
                        Name = "Americana",
                        Ingredients = "Kyckling, Jordnötter, Banan, Curry, Ananas, Ost, Tomatsås",
                        Price = 100

                    }
                );
                await databaseContext.SaveChangesAsync();
            }
            return databaseContext;
        }

        [Fact]
        public async Task PizzaRepository_GetAllPizzas_ReturnsListOfPizzas() {
            // Arrange
            var dbContext = await GetDatabaseContext();
            var pizzaRepository = new PizzaRepository(dbContext);
            // Act
            var result = await pizzaRepository.GetAllPizzas();
            // Assert
            Assert.NotNull(result);
            result.Should().BeOfType(typeof(IEnumerable<Pizza>));
        }

        [Fact]
        public async Task PizzaRepository_AddPizza_AddsToTheInMemoryDatabase() {
            // Arrange
            var pizza = new Pizza {
                Id = 2, Name = "Kebabpizza", Ingredients = "Kebabkött, Kebabsås, Feferoni, Ost, Tomatsås", Price = 95
            };
            var dbContext = await GetDatabaseContext();
            var pizzaRepository = new PizzaRepository(dbContext);
            // Act
            var result = pizzaRepository.AddPizza(pizza);
            // Assert
            Assert.NotNull(result);
            result.Should().BeOfType(typeof(Pizza));
        }
    }

}
