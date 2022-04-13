using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EF.AppDbContext;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Implementations
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IIDatabaseDbContext context;

        public ShoppingCartRepository(IIDatabaseDbContext context)
        {
            this.context = context;
        }
        public EF.Models.ShoppingCart GetShoppingCartById(int id)
        {
            return context.ShoppingCarts.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<EF.Models.ShoppingCart> GetShoppingCarts()
        {
            return context.ShoppingCarts.ToList();
        }
    }
}
