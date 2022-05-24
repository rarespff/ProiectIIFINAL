using DataAccess.EF.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserByName(string name);
        Task<User> GetUserById(int id);
        Task<String> RegisterUser(User user);
        Task<String> DeleteUser(int id);
        Task<String> EditUser(User user);
        Task<User> LoginUser(User user);
    }
}
