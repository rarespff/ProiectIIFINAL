using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Stock> GetStockByProductIdAndSize(int id, int size)
        {
            return await context.Stocks.Where(stock => stock.ProductId == id && stock.Size == size).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Stock>> GetStockDetailsForProductById(int id)
        {
            return await context.Stocks.Where(stock=>stock.ProductId==id).ToListAsync();
        }
    }
}
