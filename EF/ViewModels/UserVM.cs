using DataAccess.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectII.EF.ViewModels
{
    public class UserVM
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserVM() { }

        public UserVM(User user)
        {
            this.Username = user.Username;
            this.Password = user.Password;
        }
    }
}
