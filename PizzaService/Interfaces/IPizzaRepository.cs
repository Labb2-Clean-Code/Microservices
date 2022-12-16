using PizzaService.Models;

namespace PizzaService.Interfaces
{
    public interface IPizzaRepository
    {
        Task<List<Pizza>> GetAllPizzas();
        Task AddPizza(Pizza pizza);
    }
}
