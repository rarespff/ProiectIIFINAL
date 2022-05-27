using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectII.EF.ViewModels;
using ProiectII.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IStockRepository stockRepository;

        public ProductService(IIDatabaseDbContext context, IProductRepository productRepository,
                                ICategoryRepository categoryRepository, IBrandRepository brandRepository,
                                IWebHostEnvironment webHostEnvironment, IStockRepository stockRepository)
        {
            this.context = context;
            this.productRepository = productRepository;
            this.brandRepository = brandRepository;
            this.categoryRepository = categoryRepository;
            this.webHostEnvironment= webHostEnvironment;
            this.stockRepository = stockRepository;
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
            Product product = new Product(productVM, categoryId.Id, brandId.Id);
            string filepath = this.UploadProductImage(productVM.PhotoUrl);
            //Console.WriteLine(filepath);
            product.PhotoUrl = filepath;
            return await productRepository.AddProduct(product);
        }

        public async Task<String> DeleteProduct(int id)
        {
            return await productRepository.DeleteProduct(id);
        }

        public async Task<IEnumerable<ProductVM>> GetAllProducts()
        {
            IEnumerable<Product> products = await productRepository.GetAllProducts();
            return products.Select(product => new ProductVM(product,categoryRepository.GetCategoryById(product.CategoryId).Result.Name,
                                                            brandRepository.GetBrandById(product.BrandId).Result.Name));
        }

        public async Task<IEnumerable<ProductWithStockVM>> GetCategoryProducts(string categoryName)
        {
            IEnumerable<Product> sportProducts=await productRepository.GetProductByCategoryName(categoryName);
            IEnumerable<ProductWithStockVM> productsWithStocks= new List<ProductWithStockVM>();
            return sportProducts.Select(product => new ProductWithStockVM(product,stockRepository.GetStockDetailsForProductById(product.Id).Result));
        }

        public async Task<String> EditProduct(AddProductVM productVM)
        {
            string photoUrl = this.UploadProductImage(productVM.PhotoUrl);
            return await productRepository.EditProduct(productVM, photoUrl);
        }


        public string UploadProductImage(IFormFile file)
        {
            var apiDirectory = webHostEnvironment.ContentRootPath;
            var frontendDirectory = Path.GetFullPath(Path.Combine(apiDirectory, @"..\ProiectIIFINAL\client\public"));

            if (file != null && file.Length > 0)
            {
                string filePath = Path.Combine(frontendDirectory, file.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return file.FileName;
            }
            return null;
        }

    }
}
