using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectII.EF.ViewModels
{
    public class AddProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        [NotMapped]
        public IFormFile PhotoUrl { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
    }
}
