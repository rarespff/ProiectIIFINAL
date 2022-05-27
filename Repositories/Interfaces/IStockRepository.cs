using DataAccess.EF.Models;
using Microsoft.AspNetCore.Mvc;
using ProiectII.EF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IStockRepository
    {
      
        Task<Stock> GetStockByProductIdAndSize(StockVM stockVM);
        Task<List<Stock>> GetStockDetailsForProductById(int id);
        Task<String> AddStockToProduct(Stock stock);
        //Task<String> EditStock(Stock stock);
        Task<Stock> EditStock(Stock stock);
        Task<String> DeleteStock(int productId,int size);
        Task<Int32> GetSmallestPriceForProduct(int productId);
        Task<IEnumerable<Stock>> GetStocks();
    }
}
