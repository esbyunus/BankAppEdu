using BankAppApi.Entities;

namespace BankAppApi.Repos.Interfaces
{
    public interface ITransactionRepository
    {
        ICollection<TransactionMoney> GetAll();
        TransactionMoney GetbyId(int id);
        Account GetAccountById(int accountId);
        Account GetAccountByNumber(string accountNumber);

        bool AddTransaction(TransactionMoney transaction, int accountId);
        bool DeleteTransaction(TransactionMoney transaction);
        bool Save();
    }
}
