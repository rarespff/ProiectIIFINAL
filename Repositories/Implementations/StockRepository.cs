using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectII.EF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class StockRepository:IStockRepository
    {
        private readonly IIDatabaseDbContext context;

        public StockRepository(IIDatabaseDbContext context)
        {
            this.context = context;
        }

        public async Task<Stock> GetStockByProductIdAndSize(StockVM stockVM)
        {
            return await context.Stocks.Where(stock => stock.ProductId == stockVM.ProductId && stock.Size == stockVM.Size).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Stock>> GetStockDetailsForProductById(int id)
        {
            return await context.Stocks.Where(stock=>stock.ProductId==id).ToListAsync();
        }

        public async Task<String> AddStockToProduct(Stock stock)
        {
            context.Stocks.Add(stock);
            await context.SaveChangesAsync();
            return "Stock added";
        }

        public async Task<String> EditStock(Stock stock)
        {
            StockVM stockVM = new StockVM(stock);
            var stock2 = await context.Stocks.Where(stock1 => stock1.ProductId == stock.ProductId && stock1.Size == stock.Size).SingleOrDefaultAsync();
            stock2.Quantity = stock.Quantity;
            stock2.Price = stock.Price;
            
            return "Stock modified";
        }
    }
}
