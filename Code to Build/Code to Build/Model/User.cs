using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_to_Build.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Type { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+(?:[' -][a-zA-Z]+)*$", ErrorMessage = "Invalid first name")]
        public string? FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+(?:[' -][a-zA-Z]+)*$", ErrorMessage = "Invalid last name")]
        public string? LastName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Mobile number must be a 10-digit number")]
        public string? MobileNumber { get; set; }

            
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessage = "Password must have at least 8 characters including one uppercase letter, one lowercase letter, one number, and one special character")]
        public string? Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string? ConfirmPassword { get; set; }

    }
}