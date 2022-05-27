using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.EF.Models;

namespace ProiectII.EF.ViewModels
{
    public class StockVM
    {
        public int ProductId { get; set; }
        public int Size { get; set; }

        public StockVM() { }

        public StockVM(Stock stock)
        {
            this.ProductId = stock.ProductId;
            this.Size = stock.Size;
        }

        public StockVM(int productId,int size)
        {
            this.ProductId = productId;
            this.Size = size;
        }

    }
}
