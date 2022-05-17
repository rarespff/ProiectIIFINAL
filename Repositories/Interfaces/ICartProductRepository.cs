using DataAccess.EF.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface ICartProductRepository
    {
        Task<ActionResult<IEnumerable<CartProduct>>> GetCartProductsByCartId(int id );
    }
}
