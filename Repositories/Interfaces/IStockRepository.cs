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
      
        Task<ActionResult<Stock>> GetStockByProductIdAndSize(StockVM stockVM);
        Task<ActionResult<IEnumerable<Stock>>> GetStockDetailsForProductById(int id);
    }
}
