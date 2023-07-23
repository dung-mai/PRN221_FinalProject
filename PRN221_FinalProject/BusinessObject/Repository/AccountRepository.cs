using AutoMapper;
using Business.IRepository;
using Bussiness.DTO;
using DataAccess.Managers;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class AccountRepository : IAccountRepository
    {
        PRN221_ProjectContext _context;
        IMapper _mapper;

        public AccountRepository(PRN221_ProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AccountDTO? GetAccountByEmail(string email)
        {
            AccountManager manager = new AccountManager(_context);
            Account? account = manager.GetAccountByEmail(email);
            return account is null ? null : _mapper.Map<AccountDTO>(account);
        }
    }
}
