using Microsoft.AspNetCore.Mvc;
using OrderService.Domain.Models;

namespace OrderService.Domain
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(Order order);
        Task<IEnumerable<Order>> GetAllOrders();
    }
}
