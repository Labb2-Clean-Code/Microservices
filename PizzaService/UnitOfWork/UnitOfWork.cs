using PizzaService.Data;
using PizzaService.Interfaces;
using PizzaService.Repositories;

namespace PizzaService.UnifOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _dataContext;
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            Pizzas = new PizzaRepository(_dataContext);
        }
        public IPizzaRepository Pizzas { get; private set; }
        public int Complete()
        {
            return _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
