namespace BankAppApi.Dto
{
    public class TransferDto
    {
        public int FromAccountId { get; set; } 
        public string ToAccountNumber { get; set; }   
        public decimal Amount { get; set; }    
    }
}
