using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Implementations;
using DataAccess.Repositories.Interfaces;
using ProiectII.EF.ViewModels;
using ProiectII.Services.Interfaces;

namespace ProiectII.EF.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IIDatabaseDbContext _context;
        private readonly IBrandService brandService;

        public BrandsController(IIDatabaseDbContext context, IBrandService brandService)
        {
            _context = context;
            this.brandService = brandService;
        }

        // GET: api/Brands
        [HttpGet("{name}")]
        [ActionName("ByName")]
        public async Task<ActionResult<BrandVM>> GetBrand(string name)
        {
            return Ok(await brandService.GetBrand(name));
        }

        [HttpGet]
        [ActionName("GetAllBrands")]
        public async Task<ActionResult<IEnumerable<BrandVM>>> GetAllBrands()
        {
            return Ok(await brandService.GetAllBrands());
        }

        [HttpGet("{id}")]
        [ActionName("GetBrandById")]
        public async Task<ActionResult<BrandVM>> GetBrandById(int id)
        {
            return Ok(await brandService.GetBrandById(id));
        }


        [HttpPost]
        [ActionName("AddBrand")]
        public async Task<ActionResult<String>> AddBrand(BrandVM brandVM)
        {
            return Ok(await brandService.AddBrand(brandVM));
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteBrand")]
        public async Task<ActionResult<String>> DeleteBrand(int id)
        {
            return Ok(await brandService.DeleteBrand(id));
        }

    }
}
