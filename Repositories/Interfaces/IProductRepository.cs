using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EF.Models;
using Microsoft.AspNetCore.Mvc;
using ProiectII.EF.ViewModels;

namespace DataAccess.Repositories.Interfaces
{
   public interface IProductRepository
    {
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetProductByCategoryName(string name);
        Task<IEnumerable<Product>> GetAvailableProducts();
        Task<Product> GetProductByName(string name);
        Task<String> AddProduct(Product product);
        Task<String> DeleteProduct(int id);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<String> EditProduct(AddProductVM product,string photoUrl);

    }
}
