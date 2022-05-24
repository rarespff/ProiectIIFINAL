using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ProiectII.EF.ViewModels;
using ProiectII.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectII.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IIDatabaseDbContext context;
        private readonly ICategoryRepository categoryRepository;
        private readonly IBrandRepository brandRepository;

        public ProductService(IIDatabaseDbContext context, IProductRepository productRepository,
                                ICategoryRepository categoryRepository, IBrandRepository brandRepository)
        {
            this.context = context;
            this.productRepository = productRepository;
            this.brandRepository = brandRepository;
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<ProductVM>> GetProducts()
        {
            IEnumerable<Product> productsList = await productRepository.GetAvailableProducts();
            return productsList.Select(product => new ProductVM(product));
        }

        public async Task<ProductVM> GetProductById(int id)
        {
            Product product = await productRepository.GetProductById(id);
            return new ProductVM(product);
        }

        public async Task<IEnumerable<ProductVM>> GetProductByCategoryName(string name)
        {
            IEnumerable<Product> productsList = await productRepository.GetProductByCategoryName(name);
            return productsList.Select(product => new ProductVM(product));
        }

        public async Task<ProductVM> GetProductByName(string name)
        {
            Product product = await productRepository.GetProductByName(name);
            return new ProductVM(product);
        }

        public async Task<String> AddProduct([FromForm] AddProductVM productVM)
        {
            var brandId = await brandRepository.GetBrandByName(productVM.BrandName);
            var categoryId = await categoryRepository.GetCategoryByName(productVM.CategoryName);
            Console.WriteLine(brandId);
            Console.WriteLine(categoryId);
            Product product = new Product(productVM, categoryId.Id, brandId.Id);
            return await productRepository.AddProduct(product);
        }

        public async Task<String> DeleteProduct(int id)
        {
            return await productRepository.DeleteProduct(id);
        }

        public async Task<IEnumerable<ProductVM>> GetAllProducts()
        {
            IEnumerable<Product> products = await productRepository.GetAllProducts();
            return products.Select(product => new ProductVM(product));
        }

        public async Task<IEnumerable<ProductVM>> GetCategoryProducts(string categoryName)
        {
            IEnumerable<Product> sportProducts=await productRepository.GetProductByCategoryName(categoryName);
            return sportProducts.Select(product => new ProductVM(product));
        }

    }
}
