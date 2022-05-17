using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class CartProductRepository:ICartProductRepository
    {
        private readonly IIDatabaseDbContext context;

        public CartProductRepository(IIDatabaseDbContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<IEnumerable<CartProduct>>> GetCartProductsByCartId(int id)
        {
            return await context.CartProducts.Where(cartProduct=>cartProduct.ShoppingCartId==id).ToListAsync();
        }
    }
}
