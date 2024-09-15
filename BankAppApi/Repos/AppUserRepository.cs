using BankAppApi.Data;
using BankAppApi.Entities;
using BankAppApi.Repos.Interfaces;

namespace BankAppApi.Repos
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly BankContext _context;
        public AppUserRepository(BankContext context)
        {
            _context = context;
        }
        public bool DeleteProfile(AppUser user)
        {
            _context.Users.Remove(user);
            return Save();
        }

        public ICollection<AppUser> GetAll()
        {
            return _context.Users.OrderBy(x => x.Id).ToList();
        }

        public AppUser GetById(string id)
        {
            return _context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
