
using System.Text.Json.Serialization;

namespace DataAccess.EF.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int orderTotalPrice { get; set; }
        public string paymentStatus { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }


    }
}
