using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.DataContext {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base(options) {

            

        }

        public DbSet<Order> Orders {

            get;

            set;

        }

        public DbSet<Product> Products {

            get;

            set;

        }

    }

}
