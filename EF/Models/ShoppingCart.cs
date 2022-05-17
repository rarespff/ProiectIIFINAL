using System.Text.Json.Serialization;

namespace DataAccess.EF.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
        public bool IsOrdered { get; set; }

    }
}
