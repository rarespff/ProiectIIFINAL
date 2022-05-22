using Microsoft.AspNetCore.Http;
using ProiectII.EF.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataAccess.EF.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        [NotMapped]
        public IFormFile PhotoUrl { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Brand Brand { get; set; }
        public int BrandId { get; set; }

        public Product() { }

        public Product(ProductVM productVM)
        {
            this.Id = productVM.Id;
            this.Name = productVM.Name;
            this.Price = productVM.Price;
            this.PhotoUrl = productVM.PhotoUrl;
        }

        public Product(AddProductVM productVM,int categoryId, int brandId)
        {
            this.Id = productVM.Id;
            this.Name = productVM.Name;
            this.Price = productVM.Price;
            this.PhotoUrl = productVM.PhotoUrl;
            this.CategoryId=categoryId;
            this.BrandId=brandId;
        }
    }
}