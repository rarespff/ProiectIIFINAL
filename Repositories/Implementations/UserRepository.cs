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

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

  

        public async Task<User> GetUserByName(string name)
        {
            return await context.Users.Where(x => x.Username == name).SingleOrDefaultAsync();
        }

     
        public async Task<User> GetUserById(int id)
        {
            return await context.Users.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<String> RegisterUser(User user)
        {          
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return "User added";
        }

        public async Task<String> DeleteUser(int id)
        {
            var user = await context.Users.Where(user => user.Id == id).SingleOrDefaultAsync();
            if (user == null)
            {
                return "User not found";
            }
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return "User deleted";

        }

        public async Task<String> EditUser(User user)
        {
            var userFind=await this.GetUserById(user.Id);
            if (userFind == null)
            {
                return "User not found";
            }
            else
            {
                userFind.Email=user.Email;
                userFind.FirstName=user.FirstName;
                userFind.LastName=user.LastName;
                context.Users.Update(userFind);
                await context.SaveChangesAsync();
                return "User updated";
            }
        }

        public async Task<User> LoginUser(User user)
        {
            var userFind = await context.Users.Where(user1 => user1.Password == user.Password &&
                                                      user1.Username == user.Username).SingleOrDefaultAsync();
            if(userFind == null)
            {
                return null;
            }
            else
            {
                return userFind;
            }
        }
    }
}
