using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using DataAccess.EF.Models;
using ProiectII.EF.ViewModels;

namespace ProiectII.Services.Interfaces
{
    public interface ICartProductService
    {
        Task<IEnumerable<CartProductVM>> GetCartProducts(int id);
        Task<String> AddCartProduct(int userId, [FromBody] CartProductVM cartProductVM);
        Task<Int32> GetCartProductsNumber(int id);
        Task<String> DeleteCartProduct(int id);
    }
}
