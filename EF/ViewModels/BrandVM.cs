using DataAccess.EF.Models;

namespace ProiectII.EF.ViewModels
{
    public class BrandVM
    {
        public string Name { get; set; }

        public BrandVM() { }

        public BrandVM(Brand brand)
        {
            this.Name = brand.Name;
        }
    }
    


}
