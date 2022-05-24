using DataAccess.EF.Models;

namespace ProiectII.EF.ViewModels
{
    public class StockEntryVM
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Size { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }

        public StockEntryVM() { }

        public StockEntryVM(Stock stock,string productName)
        {
            this.Price = stock.Price;
            this.Quantity = stock.Quantity;
            this.Size= stock.Size;
            this.Id = stock.Id;
            this.ProductName = productName;
            this.ProductId = stock.ProductId;
        }
    }
}
