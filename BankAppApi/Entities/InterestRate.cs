namespace BankAppApi.Entities
{
    public class InterestRate
    {
        public int Id { get; set; }
        public decimal Rate { get; set; } 

        public DateTime EffectiveFrom { get; set; } 
        public DateTime? EffectiveTo { get; set; } 
    }
}
