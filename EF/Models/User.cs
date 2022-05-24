using ProiectII.EF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EF.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Admin { get; set; }

        public User() { }

        public User(EditUserVM editUserVM)
        {
            this.Id = editUserVM.Id;
            this.FirstName = editUserVM.FirstName;
            this.LastName = editUserVM.LastName;
            this.Email=editUserVM.Email;
        }

        public User(AddUserVM addUserVM)
        {
            this.Username = addUserVM.Username;
            this.FirstName =addUserVM.FirstName;
            this.LastName=addUserVM.LastName;
            this.Password=addUserVM.Password;
            this.Email =addUserVM.Email;
        }

        public User(UserVM userVM)
        {
            this.Username=userVM.Username;
            this.Password=userVM.Password;
        }
    }
}
