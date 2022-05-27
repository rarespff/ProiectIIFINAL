using DataAccess.EF.Models;
using System.Collections.Generic;

namespace ProiectII.EF.ViewModels
{
    public class ProductWithStockVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public List<Stock> Stocks { get; set; }

        public ProductWithStockVM() { }

        public ProductWithStockVM(Product product, List<Stock> stocklist)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.PhotoUrl = product.PhotoUrl;
            this.Stocks = stocklist;
        }
    }
}
