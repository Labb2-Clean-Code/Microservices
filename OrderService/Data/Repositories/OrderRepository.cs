using Microsoft.EntityFrameworkCore;
using OrderService.Domain;
using OrderService.Domain.Models;

namespace OrderService.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;
        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Order> AddOrder(Order order)
        {
            var found = await _dataContext.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
            if(found is not null)
            {
                throw new Exception();
            }
            await _dataContext.Orders.AddAsync(order);
            await _dataContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _dataContext.Orders.Include(x => x.Products).ToListAsync();
        }
    }
}
