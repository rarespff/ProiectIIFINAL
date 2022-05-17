﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataAccess.Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<ActionResult<ShoppingCart>> GetCartByUserId(int id);
        
    }
}
