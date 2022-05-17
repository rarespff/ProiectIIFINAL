using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
    }
}