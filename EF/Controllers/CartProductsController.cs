﻿using System;
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
using ProiectII.Services.Interfaces;
using System.Text.RegularExpressions;

namespace ProiectII.EF.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartProductsController : ControllerBase
    {
        private readonly IIDatabaseDbContext _context;
        private readonly ICartProductService cartProductService;

        public CartProductsController(IIDatabaseDbContext context, ICartProductService cartProductService)
        {
            _context = context;
            this.cartProductService = cartProductService;
        }


        [HttpGet("{id}")]
        [ActionName("GetCartProductsByUserId")]
        public async Task<ActionResult<IEnumerable<CartProductsToShowVM>>> GetCartProductsByUserId(int id)
        {
            return Ok(await cartProductService.GetCartProductsByUserId(id));
        }


        [HttpPost("{userId}")]
        [ActionName(("AddProductToCart"))]
        public async Task<ActionResult<String>> PostCartProduct(int userId,[FromBody] CartProductVM cartProductVM )
        {
            return Ok(await cartProductService.AddCartProduct(userId, cartProductVM));
        }

        [HttpGet("{id}")]
        [ActionName("GetCartSize")]
        public async Task<ActionResult<Int32>> GetCartProductsNumber(int id)
        {
            return Ok(await cartProductService.GetCartProductsNumber(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<String>> DeleteCartProduct(int id)
        {
            return Ok(await cartProductService.DeleteCartProduct(id));
        }

        [HttpPost("{id}")]
        [ActionName("OrderProducts")]
        public async Task<ActionResult<String>> OrderProducts(int userId)
        {
            return Ok(await cartProductService.OrderProducts(userId));  
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
