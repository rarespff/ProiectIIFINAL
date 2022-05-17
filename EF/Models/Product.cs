using System.Text.Json.Serialization;

namespace DataAccess.EF.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string PhotoUrl { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
    }
}