using DataAccess.EF.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectII.EF.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        [NotMapped]
        public IFormFile PhotoUrl { get; set; }

        public ProductVM() { }

        public ProductVM (Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Price = product.Price;
            this.PhotoUrl = product.PhotoUrl;
        }
    }
}
