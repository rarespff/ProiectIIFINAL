using DataAccess.EF.Models;

namespace ProiectII.EF.ViewModels
{
    public class CartProductVM
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int Size { get; set; }
        public CartProductVM() { }
        public CartProductVM(CartProduct cartProduct)
        {
            this.ProductId = cartProduct.ProductId;
            this.Quantity = cartProduct.Quantity;
            this.Size = cartProduct.Size;
        }
    }
}
