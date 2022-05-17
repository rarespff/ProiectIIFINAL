using DataAccess.EF.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public interface IUserRepository
    {

         Task<ActionResult<IEnumerable<User>>> GetUsers();
         Task<ActionResult<User>> GetUserById(int id);
         Task<ActionResult<User>> GetUserByName(string name);
         Task<ActionResult<String>> AddUser(User user);
         Task<ActionResult<String>> DeleteUser(int id);
    }
}
