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

        public async Task AddPizza(Pizza pizza)
        {
            var found = await _dataContext.Pizzas.FirstOrDefaultAsync(p => p.Name == pizza.Name);
            if (found is not null)
            {
                throw new Exception();
            }
            await _dataContext.AddAsync(pizza);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pizza>> GetAllPizzas()
        {
            return await _dataContext.Pizzas.ToListAsync();
        }
    }
}
