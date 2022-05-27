using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.EF.Models;
using ProiectII.EF.ViewModels;

namespace ProiectII.Services.Interfaces
{
    public interface IStockService
    {
        Task<String> AddStockToProduct(Stock stock);
        //Task<String> EditStock(Stock stock);
        Task<StockEntryVM> EditStock(Stock stock);
        Task<String> DeleteStock(string productName, int size);
        Task<Int32> GetSmallestPriceByProductId(int productId);
        Task<IEnumerable<StockEntryVM>> GetStocks();
        Task<String> AlterStock(int productId, int size, int quantity);
        Task<String> RemoveStock(int productId, int size, int quantity);
        Task<String> AddStock(int productId, int size, int quantity);
    }
}
