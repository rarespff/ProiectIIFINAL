using DataAccess.EF.Models;
using ProiectII.EF.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProiectII.Services.Interfaces
{
    public interface IBrandService
    {
        Task<BrandVM> GetBrand(string name);
        Task<IEnumerable<BrandVM>> GetAllBrands();
        Task<BrandVM> GetBrandById(int id);
        Task<String> AddBrand(BrandVM brandVM);
        Task<String> DeleteBrand(int id);
    }
}
