using PizzaService.Models;

namespace PizzaService.Interfaces
{
    public interface IPizzaRepository
    {
        Task<IEnumerable<Pizza>> GetAllPizzas();
        Task AddPizza(Pizza pizza);
    }
}
