using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;
using ProiectII.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProiectII.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await categoryRepository.GetAllCategories();
        }
    }
}
