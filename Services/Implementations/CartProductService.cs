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
        private readonly IProductRepository productRepository;
        private readonly IUserRepository userRepository;
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IStockService stockService;

        public CartProductService(IIDatabaseDbContext context, ICartProductRepository cartProductRepository,
                                    IProductRepository productRepository, IUserRepository userRepository,
                                    IShoppingCartRepository shoppingCartRepository, IStockService stockService)
        {
            this.context = context;
            this.cartProductRepository = cartProductRepository;
            this.productRepository= productRepository;
            this.userRepository= userRepository;
            this.shoppingCartRepository= shoppingCartRepository;
            this.stockService= stockService;
        }
        public async Task<IEnumerable<CartProductsToShowVM>> GetCartProductsByUserId(int id)
        {
            IEnumerable<CartProduct> cartProducts = await cartProductRepository.GetCartProductsByUserId(id);
            //Product product = await productRepository.GetProductById(5);
            //int a = 5;
            return cartProducts.Select(cartProduct => new CartProductsToShowVM(cartProduct,productRepository.GetProductById(cartProduct.ProductId).Result.PhotoUrl,
                                                                                productRepository.GetProductById(cartProduct.ProductId).Result.Name));
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

        public async Task<String> OrderProducts(int userId)
        {
            User user = await userRepository.GetUserById(userId);
            if(user == null)
            {
                return null;
            }
            else
            {
                IEnumerable<CartProduct> cartProducts = await cartProductRepository.GetCartProductsByUserId(userId);
                ShoppingCart cart = await shoppingCartRepository.GetCartByUserId(userId);
                foreach(CartProduct cartProduct in cartProducts)
                {
                    await stockService.AlterStock(cartProduct.ProductId, cartProduct.Size, cartProduct.Quantity);
                }
                cart.IsOrdered = true;
                return "Ok";
            }
        }
    }
}
