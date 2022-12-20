using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Services.Interfaces;

namespace OrderService.Services.Classes {
    public class AddOrder : IAddOrder {
        async Task<IActionResult> IAddOrder.AddOrder(Order order) {

            throw new NotImplementedException();

        }
    }
}
