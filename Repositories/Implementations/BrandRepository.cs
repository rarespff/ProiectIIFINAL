using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class BrandRepository:IBrandRepository
    {
        private readonly IIDatabaseDbContext context;

        public BrandRepository(IIDatabaseDbContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<Brand>> GetBrandByName(string name)
        {
            return await context.Brands.Where(brand => brand.Name == name).SingleOrDefaultAsync();
        }

        public async Task<ActionResult<Brand>> GetBrandById(int id)
        {
            return await context.Brands.Where(brand => brand.Id== id).SingleOrDefaultAsync();
        }

        public async Task<ActionResult<IEnumerable<Brand>>> GetAllBrands()
        {
            return await context.Brands.ToListAsync();
        }

        public async Task<ActionResult<String>> AddBrand(Brand brand)
        {
            context.Brands.Add(brand);
            await context.SaveChangesAsync();
            return "Brand added";
        }

        public async Task<ActionResult<String>> DeleteBrand(int id)
        {
            var brand=await context.Brands.Where(brand => brand.Id == id).SingleOrDefaultAsync();
            if(brand==null)
            {
                return "Brand not found";
            }
            else
            {
                context.Brands.Remove(brand);
                await context.SaveChangesAsync();
                return "Brand deleted";
            }
        }
    }
}
