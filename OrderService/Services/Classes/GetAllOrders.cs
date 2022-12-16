using Microsoft.AspNetCore.Mvc;
using OrderService.Services.Interfaces;

namespace OrderService.Services.Classes {
    public class GetAllOrders : IGetAllOrders {
        async Task<IActionResult> IGetAllOrders.GetAllOrders() {

            throw new NotImplementedException();

        }
    }
}
