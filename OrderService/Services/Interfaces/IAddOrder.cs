using Microsoft.AspNetCore.Mvc;
using OrderService.Models;

namespace OrderService.Services.Interfaces
{
    public interface IAddOrder
    {
        Task<IActionResult> AddOrder(Order order);

    }
}
