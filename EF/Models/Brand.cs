using ProiectII.EF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.EF.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Brand() { }

        public Brand(BrandVM brandVM)
        {
            this.Name=brandVM.Name;
        }
    }
}