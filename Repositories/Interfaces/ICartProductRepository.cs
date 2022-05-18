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
        Task<ActionResult<IEnumerable<CartProduct>>> GetCartProductsByUserId(int id );
        Task<ActionResult<String>> AddProductToCart(int userId, CartProductVM cartProductVM);
        Task<ActionResult<Int32>> GetCartProductsNumber(int id);
        Task<ActionResult<String>> RemoveProductsFromCart(int id);
    }
}
