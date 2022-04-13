using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;
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
        public IEnumerable<Category> GetCategories()
        {
            return context.Categories.ToList();
           
        }
        public Category GetCategoryById(int id)
        {
            return context.Categories.FirstOrDefault(x => x.Id == id);
        }
    }
}
