using SmartBank.Data;
using SmartBank.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartBank.Repositories
{

    public class AccountRepository : IAccountRepository
    {
        private readonly SmartBankContext _context;

        public AccountRepository(SmartBankContext context)
        {
            _context = context;
        }

        public async Task<Account> CreateAsync(Account account)
        {
            _context.Account.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<List<Account>> GetAllAsync()
        {
            return await _context.Account.ToListAsync();
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            return await _context.Account.FindAsync(id);
        }

        public async Task UpdateAsync(Account account)
        {
            _context.Account.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}

