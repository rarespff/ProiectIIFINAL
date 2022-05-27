using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Implementations;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectII.EF.ViewModels;

namespace ProiectII.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly IIDatabaseDbContext context;
        private readonly IStockRepository stockRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IBrandRepository brandRepository;


        public ProductRepository(IIDatabaseDbContext context, IStockRepository stockRepository, 
                                    ICategoryRepository categoryRepository, IBrandRepository brandRepository)
        {
            this.context = context;
            this.stockRepository = stockRepository;
            this.categoryRepository = categoryRepository;
            this.brandRepository = brandRepository;
        }

        public async  Task<Product> GetProductById(int id)
        {
            return await context.Products.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<String> AddProduct(Product product)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return "Product added";
        }


        public async Task<IEnumerable<Product>> GetAvailableProducts()
        {
            var stocks = await context.Stocks.Where(stock => stock.Quantity > 0).ToListAsync();
            var availableProducts =  new List<Product>();
            bool ok = false;
            foreach (Stock stock in stocks)
            {
                ok = false;
                int productId = stock.ProductId;
                foreach(Product product in availableProducts)
                {
                    if(product.Id == productId)
                    {
                        ok = true;
                        break;
                    }
                }
                if(ok==false)
                {
                    availableProducts.Add(await this.GetProductById(stock.ProductId));
                }
            }
            return availableProducts;
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryName(string name)
        {
            IEnumerable<Product> availableProducts =await  this.GetAvailableProducts();
            var productsFromCategory = new List<Product>();
            foreach (Product product in availableProducts)
            {
                Category category=await categoryRepository.GetCategoryById(product.CategoryId);
                if (category.Name==name)
                {
                    productsFromCategory.Add(product);
                }
            }
            return productsFromCategory;
            //return await context.Products.Where(product => product.Category.Name == name).ToListAsync();
        }

       
        public async Task<Product> GetProductByName(string name)
        {
            return await context.Products.Where(product => product.Name == name).SingleOrDefaultAsync();
        }

        public async Task<String> DeleteProduct(int id)
        {
            var product = await context.Products.Where(product=>product.Id == id).SingleOrDefaultAsync();
            if(product == null)
            {
                return "Product not founded";
            }
            else
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
                return "Product deleted";
            }
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<String> EditProduct(AddProductVM product,string photoUrl)
        {
            Product productFind = await this.GetProductById(product.Id);
            if(productFind == null)
            {
                return "Product not found";
            }
            else
            {
                if(product.Name!=null)
                {
                    productFind.Name = product.Name;
                }
                if(product.CategoryName!=null)
                {
                    productFind.CategoryId=categoryRepository.GetCategoryByName(product.CategoryName).Result.Id;
                }
                if(product.BrandName!=null)
                {
                    productFind.BrandId=brandRepository.GetBrandByName(product.BrandName).Result.Id;
                }
                if(product.PhotoUrl!=null)
                {
                    productFind.PhotoUrl = photoUrl;
                }
                context.Products.Update(productFind);
                await context.SaveChangesAsync();
                return ("Product updated");
                
            }

        }
    }
}
