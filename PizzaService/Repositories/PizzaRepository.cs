using PizzaService.Data;
using PizzaService.Interfaces;
using PizzaService.Models;

namespace PizzaService.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly DataContext _dataContext;
        public PizzaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task AddPizza(Pizza pizza)
        {
            throw new NotImplementedException();
        }

        public Task<List<Pizza>> GetAllPizzas()
        {
            throw new NotImplementedException();
        }
    }
}
