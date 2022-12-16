using PizzaService.Interfaces;

namespace PizzaService.UnifOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPizzaRepository Pizzas { get; }
        int Complete();

    }
}
