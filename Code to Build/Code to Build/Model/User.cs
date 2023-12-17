using System.ComponentModel.DataAnnotations;

namespace Code_to_Build.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z]+(?:[' -][a-zA-Z]+)*$", ErrorMessage = "Invalid first name")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+(?:[' -][a-zA-Z]+)*$", ErrorMessage = "Invalid last name")]
        public string LastName { get; set; }

        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Mobile number must be a 10-digit number")]
        public string MobileNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessage = "Password must have at least 8 characters including one uppercase letter, one lowercase letter, one number, and one special character")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}