using Microsoft.AspNetCore.Mvc;
using OrderService.Models;

namespace OrderService.Services.Interfaces {
    public interface IGetAllOrders {

        Task<IEnumerable<Order>> GetAllOrders();

    }
}
