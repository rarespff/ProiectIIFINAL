using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;
using DataAccess.Repositories.Implementations;
using ProiectII.Services.Interfaces;

namespace ProiectII.EF.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly IIDatabaseDbContext _context;
        private readonly IShoppingCartService shoppingService;

        public ShoppingCartsController(IIDatabaseDbContext context, IShoppingCartService shoppingService)
        {
            _context = context;
            this.shoppingService = shoppingService;
        }

        [HttpGet("{id}")]
        [ActionName("GetCartByUserId")]
        public async Task<ActionResult<ShoppingCart>> GetShoppingCartByUserId(int id)
        {
            return Ok(await shoppingService.GetShoppingCartByUserId(id));
        }

    }
}
