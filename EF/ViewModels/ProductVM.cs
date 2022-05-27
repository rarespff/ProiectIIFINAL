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
        public string PhotoUrl { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }

        public ProductVM() { }

        public ProductVM (Product product,string category,string brand)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.PhotoUrl = product.PhotoUrl;
            this.Category= category;
            this.Brand= brand;
        }

        public ProductVM(Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.PhotoUrl = product.PhotoUrl;
        }

    }
}
