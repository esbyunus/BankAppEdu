using System.ComponentModel.DataAnnotations;

namespace BankAppApi.Entities
{
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifre Eşleşmiyor")]
        public string ConfirmPassword { get; set; }
        public string IdNumber { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Address { get; set; } 
    }
}
