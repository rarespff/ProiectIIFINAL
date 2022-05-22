using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;
using ProiectII.EF.ViewModels;
using ProiectII.Services.Interfaces;

namespace ProiectII.Services.Implementations
{
    public class CartProductService : ICartProductService
    {
        private readonly IIDatabaseDbContext context;
        private readonly ICartProductRepository cartProductRepository;

        public CartProductService(IIDatabaseDbContext context, ICartProductRepository cartProductRepository)
        {
            this.context = context;
            this.cartProductRepository = cartProductRepository;
        }
        public async Task<IEnumerable<CartProductVM>> GetCartProducts(int id)
        {
            IEnumerable<CartProduct> cartProducts = await cartProductRepository.GetCartProductsByUserId(id);
            return cartProducts.Select(cartProduct => new CartProductVM(cartProduct));
        }

        public async Task<String> AddCartProduct(int userId, [FromBody] CartProductVM cartProductVM)
        {
            return await cartProductRepository.AddProductToCart(userId, cartProductVM);
        }

        public async Task<Int32> GetCartProductsNumber(int id)
        {
            return await cartProductRepository.GetCartProductsNumber(id);
        }

        public async Task<String> DeleteCartProduct(int id)
        {
            return await cartProductRepository.RemoveProductsFromCart(id);
        }
    }
}
