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
using ProiectII.Services.Interfaces;
using System.Text.RegularExpressions;

namespace ProiectII.EF.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IIDatabaseDbContext _context;
        private readonly IStockService stockService;

        public StocksController(IIDatabaseDbContext context, IStockService stockService)
        {
            _context = context;
            this.stockService = stockService;
        }


        [HttpPost]
        [ActionName("AddStockToProduct")]
        public async Task<ActionResult<String>> AddStockToProduct([FromBody]Stock stock)
        {
            return Ok(await stockService.AddStockToProduct(stock));
        }
        // PUT: api/Stocks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //[ActionName("EditStock")]
        //public async Task<ActionResult<String>> EditStock([FromBody] Stock stock)
        //{
        //    return Ok(await stockService.EditStock(stock));
        //}

        [HttpPost]
        [ActionName("EditStock")]
        public async Task<ActionResult<StockEntryVM>> EditStock([FromBody] Stock stock)
        {
            return Ok(await stockService.EditStock(stock));
        }


        // DELETE: api/Stocks/5
        [HttpDelete("{productName}/{size}")]
        public async Task<ActionResult<String>> DeleteStock(string productName, int size)
        {
            return Ok(await stockService.DeleteStock(productName, size));
        }


        [HttpGet("{productId}")]
        [ActionName("GetSmallestPrice")]
        public async Task<ActionResult<Int32>> GetSmallestPriceByProductId(int productId)
        {
            return Ok(await stockService.GetSmallestPriceByProductId(productId));
        }

        [HttpGet]
        [ActionName("GetAllStocks")]
        public async Task<ActionResult<IEnumerable<StockEntryVM>>> GetAllStocks()
        {
            return Ok(await stockService.GetStocks());
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
