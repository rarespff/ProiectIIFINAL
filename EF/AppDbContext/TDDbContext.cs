using DataAccess.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EF.AppDbContext
{
    public class IIDatabaseDbContext: DbContext
    {
        public IIDatabaseDbContext(DbContextOptions<IIDatabaseDbContext> options) : base(options)
        {

        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Stock> Stocks { get; set; }

    }
}
