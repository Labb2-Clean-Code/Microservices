using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaService.Interfaces;
using PizzaService.Models;
using PizzaService.UnifOfWork;

namespace PizzaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaRepository _pizzaRepository;
        public PizzaController(IPizzaRepository pizzaRepository)
        {
             _pizzaRepository = pizzaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var pizzas = await _pizzaRepository.GetAllPizzas();
            return Ok(pizzas);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(Pizza pizza)
        {
            await _pizzaRepository.AddPizza(pizza);
            return Ok();
        }
    }
}
