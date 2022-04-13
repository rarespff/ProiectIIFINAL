using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.EF.Models
{
   public class ShoppingCart
    {
        public int Id { get; set; }
        public int ItemsCount { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public int ProductId { get; set; }
      
    }
}
