using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;
using ProiectII.EF.ViewModels;
using ProiectII.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProiectII.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IIDatabaseDbContext context;
        private readonly IUserRepository userRepository;

        public UserService(IIDatabaseDbContext context, IUserRepository userRepository)
        {
            this.context = context;
            this.userRepository = userRepository;
        }

        public async Task<User> Login([FromBody] UserVM userVM)
        {
            User user = new User(userVM);
            return await userRepository.LoginUser(user);
        }

        public async Task<String> RegiserUser([FromBody] AddUserVM addUserVM)
        {
            User user=new User(addUserVM);
            return await userRepository.RegisterUser(user);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await userRepository.GetUsers();
        }

        public async Task<String> DeleteUser(int id)
        {
            return await userRepository.DeleteUser(id);
        }

        public async Task<String> EditUser(EditUserVM editUserVM)
        {
            User user = new User(editUserVM);
            return await userRepository.EditUser(user);
        }

    }
}
