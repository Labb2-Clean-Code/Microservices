using Microsoft.AspNetCore.Mvc;
using OrderService.Services.Interfaces;

namespace OrderService.Services.Classes {
    public class AddOrder : IAddOrder {
        async Task<IActionResult> IAddOrder.AddOrder() {

            throw new NotImplementedException();

        }
    }
}
