using BankAppApi.Data.Enum;

namespace BankAppApi.Dto
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public AccountType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastInterestAppliedDate { get; set; }
        public string AppUserId { get; set; }
    }
}
