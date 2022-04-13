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
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Adress> Adresses { get; set; }

    }
}
