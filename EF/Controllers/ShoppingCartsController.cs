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
using System.Text.RegularExpressions;

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
        #region Validation methods
        public Boolean CheckOnlyString(String fieldText)
        {
            String trimmedText = fieldText.Trim();
            return Regex.IsMatch(trimmedText, @"^[a-zA-Z]+$");

        }
        public Boolean CheckUsername(String userName)
        {
            String trimmedName = userName.Trim();
            Char firstLetter = trimmedName[0];
            return (Regex.IsMatch(trimmedName, @"^[a-zA-Z0-9]+$")) && (Char.IsLetter(firstLetter));
        }
        private Boolean CheckEmail(String email)
        {
            String trimmedEmail = email.Trim();
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;

        }
        #endregion

    }
}
