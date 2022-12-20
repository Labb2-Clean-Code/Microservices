using Microsoft.AspNetCore.Mvc;
using OrderService.Domain;
using OrderService.Domain.Models;

namespace OrderService.Controllers {

    [ApiController]
    [Route("/order/[controller]")]
    public class OrderServiceController : Controller {
        
        private readonly IOrderRepository orderRepository;

        public OrderServiceController(IOrderRepository orderRepository) 
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet("/GetAllOrders")]
        public async Task<IActionResult> GetAllOrders() 
        {
            var orders = await orderRepository.GetAllOrders();
            return Ok(orders);
        }

        [HttpPost("/AddOrder")]
        public async Task<IActionResult> AddOrder(Order order) {

            var addedOrder = await orderRepository.AddOrder(order);
            return Ok(addedOrder);

        }

    }
}
