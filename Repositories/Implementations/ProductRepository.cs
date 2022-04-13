using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;

namespace ProiectII.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly IIDatabaseDbContext context;

        public Product GetProductById(int id)
        {
            return context.Products.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products.ToList();
        }
    }
}
