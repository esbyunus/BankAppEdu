using BankAppApi.Data;
using BankAppApi.Data.Enum;
using BankAppApi.Entities;
using BankAppApi.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankAppApi.Repos
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BankContext _context;
        public TransactionRepository(BankContext context)
        {
            _context = context;
        }

        public bool AddTransaction(TransactionMoney transaction, int accountId)
        {
            var account = _context.Accounts.Find(accountId);
            if (account == null)
            {
                return false;
            }

            transaction.AccountId = accountId;
            transaction.Account = account;

            if (transaction.Type == TransactionType.Deposit)
            {
                account.Balance += transaction.Amount;
            }

            else if (transaction.Type == TransactionType.Withdraw)
            {
                if (account.Balance < transaction.Amount)
                {
                    return false;
                }
                account.Balance -= transaction.Amount;
            }
            else
            {
                return false;
            }

            _context.Transactions.Add(transaction);
            _context.Accounts.Update(account);
            return Save();
        }

        public bool DeleteTransaction(TransactionMoney transaction)
        {
            _context.Transactions.Remove(transaction);
            return Save();
        }

        public Account GetAccountById(int accountId)
        {
            return _context.Accounts.Find(accountId);
        }

        public Account GetAccountByNumber(string accountNumber)
        {
            return _context.Accounts.Include(a => a.AppUser).FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public ICollection<TransactionMoney> GetAll()
        {
            return _context.Transactions.OrderBy(a => a.Id).ToList();
        }

        public TransactionMoney GetbyId(int id)
        {
            return _context.Transactions.Include(t => t.Account).FirstOrDefault(t => t.Id == id);
        }



        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
