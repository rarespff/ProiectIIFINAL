using System;
using System.Threading.Tasks;
using DataAccess.EF.Models;

namespace ProiectII.Services.Interfaces
{
    public interface IStockService
    {
        Task<String> AddStockToProduct(Stock stock);
    }
}
