using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Implementations
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IIDatabaseDbContext context;

        public OrdersRepository(IIDatabaseDbContext context)
        {
            this.context = context;
        }
        public Order GetOrderById(int id)
        {
            return context.Orders.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return context.Orders.ToList();
        }
    }
}
