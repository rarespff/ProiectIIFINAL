using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;
using ProiectII.EF.ViewModels;
using ProiectII.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var brand = await brandRepository.GetBrandByName(name);
            return (new BrandVM(brand));
        }

        public async Task<IEnumerable<Brand>> GetAllBrands()
        {
            IEnumerable<Brand> brands = await brandRepository.GetAllBrands();
            return brands;
        }

        public async Task<BrandVM> GetBrandById(int id)
        {
            var brand = await brandRepository.GetBrandById(id);
            return (new BrandVM(brand));
        }

        public async Task<String> AddBrand(BrandVM brandVM)
        {
            return await brandRepository.AddBrand(brandVM);
        }

        public async Task<String> DeleteBrand(int id)
        {
            return await brandRepository.DeleteBrand(id);
        }

        public async Task<String> EditBrand(Brand brand)
        {
            return await brandRepository.EditBrand(brand);
        }
    }
}
