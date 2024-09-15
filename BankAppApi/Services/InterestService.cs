using BankAppApi.Data.Enum;
using BankAppApi.Entities;
using BankAppApi.Repos.Interfaces;

namespace BankAppApi.Services
{
    public class InterestService
    {
        private readonly IInterestRateRepository _interestRateRepository;
        private readonly IAccountRepository _accountRepository;

        public InterestService(IInterestRateRepository interestRateRepository, IAccountRepository accountRepository)
        {
            _interestRateRepository = interestRateRepository;
            _accountRepository = accountRepository;
        }

        public async Task ApplyInterestAsync()
        {
            var accounts = _accountRepository.GetAllAccounts();

            foreach (var account in accounts)
            {
                if (account.Type == AccountType.vadeli) 
                {
                    var rate = await GetApplicableInterestRateAsync(account.CreatedAt);
                    if (rate != null)
                    {
                        var interest = CalculateInterest(account.Balance, rate.Rate);
                        account.Balance += interest;
                        account.LastInterestAppliedDate = DateTime.Now;

                        _accountRepository.UpdateAcount(account);
                    }
                }
            }
        }

        private async Task<InterestRate> GetApplicableInterestRateAsync(DateTime accountCreatedAt)
        {
            var rates = await _interestRateRepository.GetAllRatesAsync();
            foreach (var rate in rates)
            {
                if (rate.EffectiveFrom <= DateTime.Now &&
                    (rate.EffectiveTo == null || rate.EffectiveTo >= DateTime.Now))
                {
                    return rate;
                }
            }
            return null;
        }

        private decimal CalculateInterest(decimal balance, decimal rate)
        {
            var annualInterest = balance * (rate / 100);
            return annualInterest; 
        }
    }
}
