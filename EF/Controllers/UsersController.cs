using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;
using ProiectII.EF.ViewModels;

namespace ProiectII.EF.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IIDatabaseDbContext _context;
        private readonly IUserRepository repository;

        public UsersController(IIDatabaseDbContext context, IUserRepository repository)
        {
            _context = context;
            this.repository = repository;
        }

        // GET: api/Users
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        //{
        //    return await repository.GetUsers();
        //}

        // GET: api/Users/5
        //[HttpGet("{id}")]
        //[ActionName("GetUserById")]
        //public async Task<ActionResult<User>> GetUser(int id)
        //{
        //    var user = await repository.GetUserById(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return user;
        //}

        [HttpPost]
        [ActionName("Login")]
        public async Task<ActionResult<User>> AddUser([FromBody]UserVM userVM)
        {
            var user = await repository.GetUserByName(userVM.Username);
            if(user==null)
            {
                return null;
            }
            else
            {
                if (user.Value.Password == userVM.Password)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpPost]
        [ActionName("Register")]
        public async Task<ActionResult<String>> PostUser(User user)
        {

            var message = await repository.AddUser(user);

            return message;
        }

        // DELETE: api/Users/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<String>> DeleteUser(int id)
        //{
        //    return await repository.DeleteUser(id);
        //}

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(int id, User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754


        //    private bool UserExists(int id)
        //    {
        //        return _context.Users.Any(e => e.Id == id);
        //    }
    }
}
