using PizzaService.Models;
using PizzaService.UnifOfWork;

namespace PizzaService.Services
{
    public class PizzaServices : IPizzaService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public PizzaServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddPizza(Pizza pizza)
        {
            await _unitOfWork.Pizzas.AddPizza(pizza);
            _unitOfWork.Complete();
        }

        public async Task<List<Pizza>> GetAllPizzas()
        {
            return await _unitOfWork.Pizzas.GetAllPizzas();
        }
    }
}
