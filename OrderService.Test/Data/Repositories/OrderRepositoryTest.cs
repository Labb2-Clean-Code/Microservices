using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderService.Data;
using OrderService.Data.Repositories;
using OrderService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderService.Test.Data.Repositories
{
    [TestClass]
    public class OrderRepositoryTest
    {
        private async Task<DataContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new DataContext(options);
            databaseContext.Database.EnsureCreated();
            if(await databaseContext.Orders.CountAsync() <= 0)
            {
                databaseContext.Add(
                    new Order
                    {
                        Products = new List<Product>
                        {
                            new Product
                            {
                                Id = 1,
                            }
                        }
                    }
                    );
                await databaseContext.SaveChangesAsync();
            }
            return databaseContext;
        }

        [TestMethod]
        public async Task OrderRepository_GetAllOrders_ReturnsListOfOrders()
        {
            // Arrange
            var dbContext = await GetDatabaseContext();
            var orderRepository = new OrderRepository(dbContext);
            // Act
            var result = await orderRepository.GetAllOrders();
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Order>));
        }

        [TestMethod]
        public async Task OrderRepository_AddOrder_AddsToTheInMemoryDatabase()
        {
            // Arrange
            var order = new Order
            {
                Products = new List<Product>
                {
                    new Product { Id = 2 }
                }
            };
            var dbContext = await GetDatabaseContext();
            var orderRepository = new OrderRepository(dbContext);
            // Act
            var result = await orderRepository.AddOrder(order);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Order));
        }
    }
}
