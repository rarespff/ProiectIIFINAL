using DataAccess.EF.Models;
using ProiectII.EF.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProiectII.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Login([FromBody] UserVM userVM);
        Task<String> RegiserUser([FromBody]AddUserVM addUserVM);
        Task<IEnumerable<User>> GetUsers();
        Task<String> DeleteUser(int id);
        Task<String> EditUser(EditUserVM editUserVM);
    }
}
