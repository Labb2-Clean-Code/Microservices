using Microsoft.AspNetCore.Mvc;

namespace OrderService.Services.Interfaces {
    public interface IGetAllOrders {

        Task<IActionResult> GetAllOrders();

    }
}
