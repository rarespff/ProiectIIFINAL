using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EF.AppDbContext;
using DataAccess.EF.Models;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Implementations
{
    public class AdressRepository : IAdressRepository
    {
        private readonly IIDatabaseDbContext context;

        public AdressRepository(IIDatabaseDbContext context)
        {
            this.context = context;
        }
        Adress IAdressRepository.GetAdressById(int id)
        {
            return context.Adresses.FirstOrDefault(x => x.Id == id);
        }

        IEnumerable<Adress> IAdressRepository.GetAdresses()
        {
            return context.Adresses.ToList();
        }
    }
}
