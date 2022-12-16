using PizzaService.Models;
using PizzaService.UnifOfWork;

namespace PizzaService.Services
{
    public interface IPizzaService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        Task AddPizza(Pizza pizza);
        Task<List<Pizza>> GetAllPizzas();
    }
}
