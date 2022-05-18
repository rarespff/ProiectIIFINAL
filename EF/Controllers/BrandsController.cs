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

namespace ProiectII.EF.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IIDatabaseDbContext _context;
        private readonly IBrandRepository repository;

        public BrandsController(IIDatabaseDbContext context, IBrandRepository repository)
        {
            _context = context;
            this.repository = repository;
        }

        // GET: api/Brands
        [HttpGet("{name}")]
        [ActionName("ByName")]
        public async Task<ActionResult<Brand>> GetBrand(string name)
        {
            return await repository.GetBrandByName(name);
        }

        [HttpGet]
        [ActionName("GetAllBrands")]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAllBrands()
        {
            return await repository.GetAllBrands();
        }

        [HttpGet("{id}")]
        [ActionName("GetBrandById")]
        public async Task<ActionResult<Brand>> GetBrandById(int id)
        {
            return await repository.GetBrandById(id);
        }



        //[HttpGet("{id}")]
        //[ActionName("ById")]
        //public async Task<ActionResult<Brand>> GetBrand(int id)
        //{
        //    var brand = await _context.Brands.FindAsync(id);

        //    if (brand == null)
        //    {
        //        return NotFound();
        //    }

        //    return brand;
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBrand(int id, Brand brand)
        //{
        //    if (id != brand.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(brand).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BrandExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        [HttpPost]
        [ActionName("AddBrand")]
        public async Task<ActionResult<String>> AddBrand(Brand brand)
        {
            return await repository.AddBrand(brand);
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteBrand")]
        public async Task<ActionResult<String>> DeleteBrand(int id)
        {
            return await repository.DeleteBrand(id);
        }

        //private bool BrandExists(int id)
        //{
        //    return _context.Brands.Any(e => e.Id == id);
        //}
    }
}
