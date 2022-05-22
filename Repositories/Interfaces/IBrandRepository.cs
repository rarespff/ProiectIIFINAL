using DataAccess.EF.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        Task<Brand> GetBrandByName(string name);
        Task<Brand> GetBrandById(int id);
        Task<IEnumerable<Brand>> GetAllBrands();
        Task<String> DeleteBrand(int id);
        Task<String> AddBrand(Brand brand);
    }
}
