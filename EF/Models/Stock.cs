using ProiectII.EF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.EF.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Size { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public Stock() { }
        
        public Stock(StockEntryVM stockEntryVM)
        {
            this.Id = stockEntryVM.Id;
            this.Quantity = stockEntryVM.Quantity;
            this.Size = stockEntryVM.Size;
            this.Price = stockEntryVM.Price;
        }
    }
}