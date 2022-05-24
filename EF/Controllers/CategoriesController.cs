using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using ProiectII.Services.Interfaces;

namespace ProiectII.EF.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IIDatabaseDbContext _context;
        private readonly ICategoryService categoryService;

        public CategoriesController(IIDatabaseDbContext context, ICategoryService categoryService)
        {
            _context = context;
            this.categoryService = categoryService;
        }

        [HttpGet]
        [ActionName("GetAllCategories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return Ok(await categoryService.GetAllCategories());
        }



    }
}
