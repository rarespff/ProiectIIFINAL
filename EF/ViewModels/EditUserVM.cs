using DataAccess.EF.Models;

namespace ProiectII.EF.ViewModels
{
    public class EditUserVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public EditUserVM() { }

        public EditUserVM(User user)
        {
            this.Id = user.Id;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Email = user.Email;
        }
    }
}
