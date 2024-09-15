namespace BankAppApi.Dto
{
    public class AccountApplicationDto
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public decimal MonthlyIncome { get; set; }
        public bool IsVadeli { get; set; } 
        public bool Pending { get; set; }
        public bool IsApprovel { get; set; }

        public string AppUserId { get; set; } 
    }
}
