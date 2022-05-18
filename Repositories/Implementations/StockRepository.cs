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

        public async Task<ActionResult<Stock>> GetStockByProductIdAndSize(StockVM stockVM)
        {
            return await context.Stocks.Where(stock => stock.ProductId == stockVM.ProductId && stock.Size == stockVM.Size).SingleOrDefaultAsync();
        }

        public async Task<ActionResult<IEnumerable<Stock>>> GetStockDetailsForProductById(int id)
        {
            return await context.Stocks.Where(stock=>stock.ProductId==id).ToListAsync();
        }
    }
}
