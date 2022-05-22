using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ProiectII.EF.ViewModels;

namespace DataAccess.EF.Models
{
    public class CartProduct
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Size { get; set; }
        [JsonIgnore]
        public ShoppingCart ShoppingCart { get; set; }
        public int ShoppingCartId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public CartProduct() { }

        public CartProduct(CartProductVM cartProductVM,int ShoppingCartId)
        {
            this.ProductId = cartProductVM.ProductId;
            this.Quantity = cartProductVM.Quantity;
            this.Size = cartProductVM.Size;
            this.ShoppingCartId = ShoppingCartId;
        }
    }
}