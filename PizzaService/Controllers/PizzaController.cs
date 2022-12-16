using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaService.Interfaces;
using PizzaService.Models;

namespace PizzaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private IPizzaService _pizzaService { get; set; }
        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var pizzas = await _pizzaService.GetAllPizzas();
            return Ok(pizzas);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(Pizza pizza)
        {
            await _pizzaService.AddPizza(pizza);
            return Ok();
        }
    }
}
