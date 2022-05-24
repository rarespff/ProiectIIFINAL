using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;
using ProiectII.Services.Interfaces;

namespace ProiectII.Services.Implementations
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IIDatabaseDbContext context;
        private readonly IShoppingCartRepository shoppingRepository;

        public ShoppingCartService(IIDatabaseDbContext context, IShoppingCartRepository shoppingRepository)
        {
            this.context = context;
            this.shoppingRepository = shoppingRepository;
        }

        public async Task<ShoppingCart> GetShoppingCartByUserId(int id)
        {
            return await shoppingRepository.GetCartByUserId(id);
        }
    }
}
