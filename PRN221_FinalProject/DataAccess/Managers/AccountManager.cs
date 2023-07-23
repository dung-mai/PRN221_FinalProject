using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Managers
{
    public class AccountManager
    {
        PRN221_ProjectContext _context;
        public AccountManager(PRN221_ProjectContext context)
        { 
            _context = context;
        }

        public Account? GetAccountByEmail(string email)
        {
            return _context.Accounts.Include(a => a.Role)
                                    .FirstOrDefault(a => a.Email == email);
        }
    }
}
