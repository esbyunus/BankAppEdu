using BankAppApi.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankAppApi.Data
{
    public class BankContext : IdentityDbContext<AppUser>
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<InterestRate> InterestRates { get; set; }
        public DbSet<AccountApplication> Applications { get; set; }

        public DbSet<TransactionMoney> Transactions { get; set; }
    }
}
