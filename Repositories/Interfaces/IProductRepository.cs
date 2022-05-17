using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EF.Models;

namespace DataAccess.Repositories.Interfaces
{
   public interface IProductRepository
    {
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetProductByCategoryName(string name);
        Task<IEnumerable<Product>> GetAvailableProducts();
        Task<Product> GetProductByName(string name);
    }
}
