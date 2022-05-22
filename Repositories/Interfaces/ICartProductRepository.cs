using DataAccess.EF.Models;
using Microsoft.AspNetCore.Mvc;
using ProiectII.EF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface ICartProductRepository
    {
        Task<IEnumerable<CartProduct>> GetCartProductsByUserId(int id );
        Task<String> AddProductToCart(int userId,CartProductVM cartProductVM);
        Task<Int32> GetCartProductsNumber(int id);
        Task<String> RemoveProductsFromCart(int id);
    }
}
