using System.Threading.Tasks;
using DataAccess.EF.Models;

namespace ProiectII.Services.Interfaces
{
    public interface IShoppingCartService
    {
        Task<ShoppingCart> GetShoppingCartByUserId(int id);
    }
}
