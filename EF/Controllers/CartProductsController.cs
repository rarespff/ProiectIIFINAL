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
using ProiectII.EF.ViewModels;

namespace ProiectII.EF.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartProductsController : ControllerBase
    {
        private readonly IIDatabaseDbContext _context;
        private readonly ICartProductRepository repository;

        public CartProductsController(IIDatabaseDbContext context, ICartProductRepository repository)
        {
            _context = context;
            this.repository = repository;
        }

        // GET: api/CartProducts
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CartProduct>>> GetCartProducts()
        //{
        //    return await _context.CartProducts.ToListAsync();
        //}

        // GET: api/CartProducts/5
        [HttpGet("{id}")]
        [ActionName("GetCartProductsByUserId")]
        public async Task<ActionResult<IEnumerable<CartProduct>>> GetCartProducts(int id)
        {
            return await repository.GetCartProductsByUserId(id);
        }

        // PUT: api/CartProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCartProduct(int id, CartProduct cartProduct)
        //{
        //    if (id != cartProduct.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(cartProduct).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CartProductExists(id))
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

        // POST: api/CartProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{userId}")]
        [ActionName(("AddProductToCart"))]
        public async Task<ActionResult<String>> PostCartProduct(int userId,[FromBody] CartProductVM cartProductVM )
        {
            return await repository.AddProductToCart(userId, cartProductVM);
        }

        [HttpGet("{id}")]
        [ActionName("GetCartSize")]
        public async Task<ActionResult<Int32>> GetCartProductsNumber(int id)
        {
            return await repository.GetCartProductsNumber(id);
        }

        // DELETE: api/CartProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<String>> DeleteCartProduct(int id)
        {
            return await repository.RemoveProductsFromCart(id);
        }

        private bool CartProductExists(int id)
        {
            return _context.CartProducts.Any(e => e.Id == id);
        }
    }
}
