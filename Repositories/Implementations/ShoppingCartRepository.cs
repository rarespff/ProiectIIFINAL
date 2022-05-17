using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementations
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IIDatabaseDbContext context;

        public ShoppingCartRepository(IIDatabaseDbContext context)
        {
            this.context = context;
        }

        public async Task<ShoppingCart> GetCartByUserId(int id)
        {
            return await context.ShoppingCarts.Where(shoppingCart=>shoppingCart.UserId==id).SingleOrDefaultAsync();
        }
    }
}
