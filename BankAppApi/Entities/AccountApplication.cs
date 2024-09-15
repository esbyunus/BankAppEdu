namespace BankAppApi.Entities
{
    public class AccountApplication
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public decimal MonthlyIncome { get; set; }
        public bool IsVadeli { get; set; } 
        public bool Pending { get; set; }
        public bool IsApprovel { get; set; }

        // Relations
        public string AppUserId { get; set; } 
        public AppUser AppUser { get; set; } 
    }
}
