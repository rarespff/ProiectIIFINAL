using DataAccess.EF.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProiectII.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
    }
}
