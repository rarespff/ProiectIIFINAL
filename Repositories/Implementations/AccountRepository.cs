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
    public class AccountRepository : IAccountRepository
    {
        private readonly IIDatabaseDbContext context;

        public AccountRepository(IIDatabaseDbContext context)
        {
            this.context = context;
        }
        public Account GetAccountById(int id)
        {
            return context.Accounts.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Account> GetAccounts()
        {
            return context.Accounts.ToList();
        }
    }
}
