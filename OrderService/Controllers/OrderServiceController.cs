using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Services.Interfaces;

namespace OrderService.Controllers {

    [ApiController]
    [Route("/order/[controller]")]
    public class OrderServiceController : Controller {
        
        private readonly IGetAllOrders _getAllOrders;

        private readonly IAddOrder _addOrder;

        public OrderServiceController(IGetAllOrders getAllOrders, IAddOrder addOrder) {
            
            _getAllOrders = getAllOrders;

            _addOrder = addOrder;

        }

        [HttpGet("/GetAllOrders")]
        public async Task<IActionResult> GetAllOrders() 
        {
            var orders = await _getAllOrders.GetAllOrders();
            return Ok(orders);
        }

        [HttpPost("/AddOrder")]
        public async Task<IActionResult> AddOrder(Order order) {

            await _addOrder.AddOrder(order);
            return Ok();

        }

    }
}
