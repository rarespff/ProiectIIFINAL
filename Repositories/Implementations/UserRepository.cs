using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class UserRepository : IUserRepository
    {
        private readonly IIDatabaseDbContext context;

        public UserRepository(IIDatabaseDbContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

  

        public async Task<ActionResult<User>> GetUserByName(string name)
        {
            return await context.Users.Where(x => x.Username == name).FirstOrDefaultAsync();
        }

     
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            //return await context.Users.FirstOrDefault(x => x.Id == id);
            return await context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ActionResult<String>> AddUser(User user)
        {          
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return "User added";
        }

        public async Task<ActionResult<String>> DeleteUser(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                return "User not found";
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return "User deleted";

        }
    }
}
