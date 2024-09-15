using BankAppApi.Data.Enum;

namespace BankAppApi.Dto
{
    public class TransactionMoneyDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; } 
        public DateTime TransactionDate { get; set; }
        public TransactionType Type { get; set; } 

        public int AccountId { get; set; } 
    }
}
