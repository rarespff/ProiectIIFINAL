using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;
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

        public async Task<Brand> GetBrandByName(string name)
        {
            return await context.Brands.Where(brand => brand.Name == name).SingleOrDefaultAsync();
        }
    }
}
