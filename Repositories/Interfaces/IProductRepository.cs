using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataAccess.Repositories.Interfaces
{
   public interface IProductRepository
    {
        Task<Product> GetProductById(int id);
        Task<ActionResult<IEnumerable<Product>>> GetProductByCategoryName(string name);
        Task<ActionResult<IEnumerable<Product>>> GetAvailableProducts();
        Task<ActionResult<Product>> GetProductByName(string name);
    }
}
