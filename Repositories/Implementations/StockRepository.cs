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

        //public async Task<String> EditStock(Stock stock)
        //{
        //    StockVM stockVM = new StockVM(stock);
        //    //var stock2 = await context.Stocks.Where(stock1 => stock1.ProductId == stock.ProductId && stock1.Size == stock.Size).SingleOrDefaultAsync();
        //    var stock2 = await this.GetStockByProductIdAndSize(stockVM);
        //    if (stock2 == null)
        //    {
        //        return "Stock not found";
        //    }
        //    else
        //    {
        //        stock2.Quantity = stock.Quantity;
        //        stock2.Price = stock.Price;
        //        context.Stocks.Update(stock2);
        //        await context.SaveChangesAsync();
        //        return "Stock updated";
        //    }
        //}

        public async  Task<Stock> EditStock(Stock stock)
        {
            StockVM stockVM = new StockVM(stock);
            //var stock2 = await context.Stocks.Where(stock1 => stock1.ProductId == stock.ProductId && stock1.Size == stock.Size).SingleOrDefaultAsync();
            var stock2 = await this.GetStockByProductIdAndSize(stockVM);
            if (stock2 == null)
            {
                return null;
            }
            else
            {
                stock2.Quantity = stock.Quantity;
                stock2.Price = stock.Price;
                context.Stocks.Update(stock2);
                await context.SaveChangesAsync();
                return stock2;
            }
        }

        public async Task<String> DeleteStock(int productId, int size)
        {
            var stock = await context.Stocks.Where(stock1 => stock1.ProductId == productId && stock1.Size == size).SingleOrDefaultAsync();
            if (stock != null)
            {
                context.Stocks.Remove(stock);
                await context.SaveChangesAsync();
                return "Stock deleted";
            }
            else
            {
                return "Stock for this size of the product doesn't exist";
            }
        }

        public async Task<Int32> GetSmallestPriceForProduct(int productId)
        {
            var stockByProductId=await this.GetStockDetailsForProductById(productId);
            Int32 smallest=650000;
            foreach(Stock stock1 in stockByProductId)
            {
                if(stock1.Price<smallest)
                {
                    smallest=stock1.Price;
                }
            }
            return smallest;
        }

        public async Task<IEnumerable<Stock>> GetStocks()
        {
            return await context.Stocks.ToListAsync();
        }
    }
}
