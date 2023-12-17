using Code_to_Build.Model;
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
        public async Task<IActionResult> Index([FromBody] User registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(registration);
            await _context.SaveChangesAsync();

            return Ok("Registration Successfull");
        }
    }
}    