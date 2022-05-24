using Microsoft.AspNetCore.Mvc;
using ProiectII.EF.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProiectII.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductVM>> GetProducts();
        Task<ProductVM> GetProductById(int id);
        Task<IEnumerable<ProductVM>> GetProductByCategoryName(string name);
        Task<ProductVM> GetProductByName(string name);
        Task<String> AddProduct([FromForm] AddProductVM productVM);
        Task<String> DeleteProduct(int id);
        Task<IEnumerable<ProductVM>> GetAllProducts();
        Task<IEnumerable<ProductVM>> GetCategoryProducts(string categoryName);

    }
}
