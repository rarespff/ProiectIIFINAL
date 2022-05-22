using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;
using ProiectII.EF.ViewModels;
using ProiectII.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProiectII.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IIDatabaseDbContext context;
        private readonly IBrandRepository brandRepository;

        public BrandService(IIDatabaseDbContext context, IBrandRepository brandRepository)
        {
            this.context=context;
            this.brandRepository=brandRepository;
        }
        public async Task<BrandVM> GetBrand(string name)
        {
            
        }

        public async Task<IEnumerable<BrandVM>> GetAllBrands()
        {

        }

        public async Task<Brand> GetBrandById(int id)
        {

        }

        public async Task<String> AddBrand(BrandVM brandVM)
        {

        }

        public async Task<String> DeleteBrand(int id)
        {

        }
    }
}
