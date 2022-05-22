using DataAccess.EF.Models;

namespace ProiectII.EF.ViewModels
{
    public class BrandVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BrandVM() { }

        public BrandVM(Brand brand)
        {
            this.Id = brand.Id; 
            this.Name = brand.Name;
        }
    }
    


}
