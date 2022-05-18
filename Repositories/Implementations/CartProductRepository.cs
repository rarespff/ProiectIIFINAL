using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectII.EF.ViewModels;
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
        private readonly IShoppingCartRepository shopCartRepository;

        public CartProductRepository(IIDatabaseDbContext context, IShoppingCartRepository shopCartRepository)
        {
            this.context = context;
            this.shopCartRepository= shopCartRepository;
        }

        public async Task<ActionResult<IEnumerable<CartProduct>>> GetCartProductsByUserId(int id)
        {
            var shoppingCart = await shopCartRepository.GetCartByUserId(id);
            return await context.CartProducts.Where(cartProduct=>cartProduct.ShoppingCartId==shoppingCart.Value.Id).ToListAsync();
        }

        public async Task<ActionResult<String>> AddProductToCart(int userId, CartProductVM cartProductVM)
        {
            var shoppingCart = await shopCartRepository.GetCartByUserId(userId);
            CartProduct cartProduct = new CartProduct();
            cartProduct.ProductId=cartProductVM.ProductId;
            cartProduct.Quantity=cartProductVM.Quantity;
            cartProduct.Size=cartProductVM.Size;
            cartProduct.ShoppingCartId = shoppingCart.Value.Id;
            context.CartProducts.Add(cartProduct);
            await context.SaveChangesAsync();
            return ("Ok");

        }

        public async Task<ActionResult<Int32>> GetCartProductsNumber(int id)
        {
            var shoppingCart = await shopCartRepository.GetCartByUserId(id);
            List<CartProduct> products= new List<CartProduct>();
            products = await context.CartProducts.Where(cartProduct => cartProduct.ShoppingCartId == id).ToListAsync();
            return products.Count();
        }

        public async Task<ActionResult<String>> RemoveProductsFromCart(int id)
        {
            var cartProduct = await context.CartProducts.Where(cartProduct => cartProduct.Id == id).SingleOrDefaultAsync(); ;
            if (cartProduct == null)
            {
                return "Produsul nu se afla in cos";
            }

            context.CartProducts.Remove(cartProduct);
            await context.SaveChangesAsync();
            return "Produsul a fost sters";
        }
    }
}
