using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Services.Interfaces;

namespace OrderService.Services.Classes {
    public class GetAllOrders : IGetAllOrders {
        async Task<IEnumerable<Order>> IGetAllOrders.GetAllOrders() {

            throw new NotImplementedException();

        }
    }
}
