using BankAppApi.Data;
using BankAppApi.Entities;
using BankAppApi.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankAppApi.Repos
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankContext _context;
        public AccountRepository(BankContext context)
        {
            _context = context;
        }
        public bool AddAcount(Account account, string AppUserId)
        {
            var user = _context.Users.Find(AppUserId);
            if (user == null)
                return false;

            account.AppUserId = AppUserId;
            account.AppUser = user;

            _context.Accounts.Add(account);
            return Save();
        }

        public bool DeleteAccount(Account account)
        {
            _context.Accounts.Remove(account);
            return Save();
        }

        public Task<Account> GetAccountByNumberAsync(string accountNumber)
        {
            return _context.Accounts
                .Include(a => a.AppUser).FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
        }

        public ICollection<Account> GetAllAccounts()
        {
            return _context.Accounts.Include(a => a.AppUser).OrderBy(a => a.Id).ToList();
        }

        public ICollection<Account> GetAllAccountsByUserId(string userId)
        {
            return _context.Accounts.Include(a => a.AppUser).Where(a => a.AppUserId == userId).ToList();
        }

        public Task<Account> GetById(int id)
        {
            return _context.Accounts.Include(a => a.AppUser).FirstOrDefaultAsync(a => a.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAcount(Account account)
        {
            _context.Update(account);
            return Save();
        }
    }
}
