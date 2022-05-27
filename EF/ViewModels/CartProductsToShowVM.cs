using DataAccess.EF.Models;

namespace ProiectII.EF.ViewModels
{
    public class CartProductsToShowVM
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Size { get; set; }
        public string PhotoUrl { get; set; }
        public int Id { get; set; }
        public CartProductsToShowVM() { }

        public CartProductsToShowVM(CartProduct cartProduct,string photoUrl,string productName)
        {
            this.PhotoUrl = photoUrl;
            this.Quantity = cartProduct.Quantity;
            this.Size = cartProduct.Size;
            this.Name = productName;
            this.Id = cartProduct.Id;
    }

    }
}
