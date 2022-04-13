using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///
///
///interfaces/implementare for each one
/// controlers
/// get pt toate/ get by id la fiecare
/// </summary>
namespace DataAccess.Repositories.Implementations
{
    public class UserRepository:IUserRepository
    {
        private readonly IIDatabaseDbContext context;

        public UserRepository(IIDatabaseDbContext context)
        {
            this.context = context;
        }

        public User GetUserById(int id)
        {
            return context.Users.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }
    }
}
