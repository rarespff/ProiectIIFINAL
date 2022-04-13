using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EF.Models;

namespace DataAccess.Repositories.Interfaces
{
   public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
        Account GetAccountById(int id);
    }
}
