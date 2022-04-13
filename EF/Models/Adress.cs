using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EF.Models
{
    public class Adress
    {
        public int Id { get; set; }
        public string City{ get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string PhoneNumber { get; set; }
    }
}
