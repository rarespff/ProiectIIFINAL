using DataAccess.EF.Models;

namespace ProiectII.EF.ViewModels
{
    public class StockEditVM
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Size { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public StockEditVM() { }

        public StockEditVM(Stock stock,string productName)
        {
            this.Id= stock.Id;
            this.ProductId = stock.ProductId;
            this.Price = stock.Price;
            this.Quantity = stock.Quantity;
            this.Size = stock.Size;
            this.ProductName = productName;
        }
    }
}
