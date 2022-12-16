using Microsoft.AspNetCore.Mvc;

namespace OrderService.Services.Interfaces
{
    public interface IAddOrder
    {
        Task<IActionResult> AddOrder();

    }
}
