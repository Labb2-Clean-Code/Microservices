using Microsoft.EntityFrameworkCore;
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

        public async Task<Pizza> AddPizza(Pizza pizza)
        {
            var found = await _dataContext.Pizzas.FirstOrDefaultAsync(p => p.Id == pizza.Id);
            if (found is not null)
            {
                throw new Exception();
            }
            await _dataContext.AddAsync(pizza);
            await _dataContext.SaveChangesAsync();
            return pizza;
        }

        public async Task<IEnumerable<Pizza>> GetAllPizzas()
        {
            return await _dataContext.Pizzas.ToListAsync();
        }


    }
}
