using BankAppApi.Data.Enum;

namespace BankAppApi.Entities
{
    public class TransactionMoney
    {
        public int Id { get; set; }
        public decimal Amount { get; set; } 
        public DateTime TransactionDate { get; set; } 
        public TransactionType Type { get; set; } 

        // Relations
        public int AccountId { get; set; } 
        public Account Account { get; set; }
    }
}
