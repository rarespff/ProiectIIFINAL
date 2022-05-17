using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Implementations;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ProiectII.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly IIDatabaseDbContext context;
        private readonly StockRepository stockRepository;
        private readonly CategoryRepository categoryRepository;

        public ProductRepository(IIDatabaseDbContext context, StockRepository repository, CategoryRepository categoryRepository)
        {
            this.context = context;
            this.stockRepository = repository;
            this.categoryRepository = categoryRepository;
        }

        public async  Task<Product> GetProductById(int id)
        {
            return await context.Products.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetAvailableProducts()
        {
            var stocks = await context.Stocks.Where(stock => stock.Quantity > 0).ToListAsync();
            var availableProducts = new List<Product>();
            foreach(Stock stock in stocks)
            {
                availableProducts.Add(await this.GetProductById(stock.ProductId));
            }
            return availableProducts;
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryName(string name)
        {
            return await context.Products.Where(product => product.Category.Name == name).ToListAsync();
        }

       
        public async Task<Product> GetProductByName(string name)
        {
            return await context.Products.Where(product => product.Name == name).SingleOrDefaultAsync();
        }
    }
}
