using BankAppApi.Entities;

namespace BankAppApi.Repos.Interfaces
{
    public interface IAccountApplicationRepository
    {
        ICollection<AccountApplication> GetAll();
        Task<AccountApplication> GetById(int id);
        ICollection<AccountApplication> GetAllAplicationByUserId(string userId);
        bool AddAccountApplication(AccountApplication accountApplication, string appUserId);
        bool UpdateAccountApplication(AccountApplication accountApplication);
        bool DeleteAccountApplication(AccountApplication accountApplication);
        bool Save();
    }
}
