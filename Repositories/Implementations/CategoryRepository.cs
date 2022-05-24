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
    public class CategoryRepository:ICategoryRepository
    {
        private readonly IIDatabaseDbContext context;

        public CategoryRepository(IIDatabaseDbContext context)
        {
            this.context = context;
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            return await context.Categories.Where(category => category.Name == name).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await context.Categories.ToListAsync();
        }


    }
}
