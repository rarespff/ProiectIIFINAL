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
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
    }
}
