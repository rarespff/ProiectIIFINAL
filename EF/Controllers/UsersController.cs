using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using ProiectII.EF.ViewModels;
using ProiectII.Services.Interfaces;

namespace ProiectII.EF.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IIDatabaseDbContext _context;
        private readonly IUserService userService;

        public UsersController(IIDatabaseDbContext context, IUserService userService)
        {
            _context = context;
            this.userService = userService;
        }

        [HttpPost]
        [ActionName("Login")]
        public async Task<ActionResult<User>> Login([FromBody]UserVM userVM)
        {
            //UserVM userReturnVM = new UserVM(await userService.Login(userVM));
            return Ok(await userService.Login(userVM));
        }

        [HttpPost]
        [ActionName("Register")]
        public async Task<ActionResult<String>> RegiserUser([FromBody]AddUserVM addUserVM)
        {
            return Ok(await userService.RegiserUser(addUserVM));
        }

        [HttpGet]
        [ActionName("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await userService.GetUsers());
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteUser")]
        public async Task<ActionResult<String>> DeleteUser(int id)
        {
            return Ok(await userService.DeleteUser(id));
        }

        [HttpPost]
        [ActionName("EditUser")]
        public async Task<ActionResult<String>> EditUser([FromBody] EditUserVM editUserVM)
        {
            return Ok(await userService.EditUser(editUserVM));
        }



        
    }
}
