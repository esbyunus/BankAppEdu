using BankAppApi.Entities;

namespace BankAppApi.Repos.Interfaces
{
    public interface IAppUserRepository
    {
        ICollection<AppUser> GetAll();
        AppUser GetById(string id);
        bool DeleteProfile(AppUser user);
        bool Save();
    }
}
