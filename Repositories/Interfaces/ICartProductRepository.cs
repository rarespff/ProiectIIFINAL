﻿using DataAccess.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface ICartProductRepository
    {
        Task<IEnumerable<CartProduct>> GetCartProductsByCartId(int id );
    }
}
