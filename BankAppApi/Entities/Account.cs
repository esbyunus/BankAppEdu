using BankAppApi.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace BankAppApi.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; } 
        public decimal Balance { get; set; } 
        public AccountType Type { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public DateTime? LastInterestAppliedDate { get; set; }


        public string AppUserId { get; set; } 
        public AppUser AppUser { get; set; } 
    }
}
