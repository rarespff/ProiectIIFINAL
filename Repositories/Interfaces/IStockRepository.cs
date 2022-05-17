using DataAccess.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IStockRepository
    {
      
        Task<Stock> GetStockByProductIdAndSize(int id, int size);
        Task<IEnumerable<Stock>> GetStockDetailsForProductById(int id);
    }
}
