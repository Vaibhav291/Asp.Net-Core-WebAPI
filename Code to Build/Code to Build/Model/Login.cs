using System.ComponentModel.DataAnnotations;

namespace Code_to_Build.Model
{
    public class Login
    {
        [Required]
        public string? Type { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required]
       // [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
       //     ErrorMessage = "Password must have at least 8 characters including one uppercase letter, one lowercase letter, one number, and one special character")]
        public string? Password { get; set; }
    }
}
