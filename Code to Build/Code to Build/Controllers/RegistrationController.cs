using Code_to_Build.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Code_to_Build.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : Controller
    {
        private readonly CodetoBuildDbContext _context;

        public RegistrationController(CodetoBuildDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User registration)
        {
            bool EmailExistis = _context.Users.Any(x =>  x.Email == registration.Email);
            if (EmailExistis)
            {
                return BadRequest("User already exist");
            }

            User user = new User();
            user.Type = registration.Type;
            user.FirstName = registration.FirstName;
            user.LastName = registration.LastName;
            user.MobileNumber = registration.MobileNumber;
            user.Email = registration.Email;
            user.Password = registration.Password;
            user.ConfirmPassword = registration.ConfirmPassword;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Json(Ok());
            
        }
    }
}    