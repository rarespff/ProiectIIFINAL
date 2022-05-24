using DataAccess.EF.Models;

namespace ProiectII.EF.ViewModels
{
    public class AddUserVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public AddUserVM() { }

        public AddUserVM(User user)
        {
            this.Username = user.Username;
            this.Password = user.Password;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Email = user.Email;
        }
    }
}
