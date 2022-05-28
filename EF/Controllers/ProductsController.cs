using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using ProiectII.Repositories.Implementations;
using DataAccess.Repositories.Interfaces;
using ProiectII.EF.ViewModels;
using ProiectII.Services.Implementations;
using ProiectII.Services.Interfaces;
using System.Text.RegularExpressions;

namespace ProiectII.EF.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        [ActionName("Available")]
        public async Task<ActionResult<IEnumerable<ProductVM>>> GetProducts()
        {
            return Ok(await productService.GetProducts());
        }

        [HttpGet]
        [ActionName("AllProducts")]
        public async Task<ActionResult<IEnumerable<ProductVM>>> GetAllProducts()
        {
            return Ok(await productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        [ActionName("ProductById")]
        public async Task<ActionResult<ProductVM>> GetProduct(int id)
        {
            return Ok(await productService.GetProductById(id));
        }

        [HttpGet("{name}")]
        [ActionName("ProductByCategoryName")]
        public async Task<ActionResult<IEnumerable<ProductVM>>> GetProductByCategoryName(string name)
        {
            return Ok(await productService.GetProductByCategoryName(name));
        }

        [HttpGet("{name}")]
        [ActionName("ProductByName")]
        public async Task<ActionResult<IEnumerable<ProductVM>>> GetProductByName(string name)
        {
            return Ok(await productService.GetProductByName(name));
        }

        [HttpPost]
        [ActionName("AddProduct")]
        public async Task<ActionResult<String>> AddProduct([FromForm] AddProductVM productVM)
        {
            bool checkString = this.CheckOnlyString(productVM.Name);
            if(!checkString)
            {
                return "IncorrectFormat";
            }
            return Ok(await productService.AddProduct(productVM));
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteProduct")]
        public async Task<ActionResult<String>> DeleteProduct(int id)
        {
            return Ok(await productService.DeleteProduct(id));
        }

        [HttpGet]
        [ActionName("SportProducts")]
        public async Task<ActionResult<IEnumerable<ProductWithStockVM>>> GetSportProducts()
        {
            string categoryName = "Sport";
            return Ok(await productService.GetCategoryProducts(categoryName));
        }

        [HttpGet]
        [ActionName("CasualProducts")]
        public async Task<ActionResult<IEnumerable<ProductWithStockVM>>> GetCasualProducts()
        {
            string categoryName = "Casual";
            return Ok(await productService.GetCategoryProducts(categoryName));
        }

        [HttpGet]
        [ActionName("ElegantProducts")]
        public async Task<ActionResult<IEnumerable<ProductWithStockVM>>> GetElegantProducts()
        {
            string categoryName = "Elegant";
            return Ok(await productService.GetCategoryProducts(categoryName));
        }

        [HttpGet]
        [ActionName("GetImage")]
        public async Task<IActionResult> GetImageToShow([FromHeader]string path)
        {
            Byte[] b = System.IO.File.ReadAllBytes(path);
            return File(b,"image/jpg");
        }

        [HttpPost]
        [ActionName("EditProduct")]
        public async Task<ActionResult<String>> EditProduct([FromForm]AddProductVM addProductVM)
        {
            bool checkString = this.CheckOnlyString(addProductVM.Name);
            if (!checkString)
            {
                return "IncorrectFormat";
            }
            return Ok(await productService.EditProduct(addProductVM));
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
