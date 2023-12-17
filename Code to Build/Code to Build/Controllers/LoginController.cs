using Microsoft.AspNetCore.Mvc;

namespace Code_to_Build.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly CodetoBuildDbContext _context;

        public LoginController(CodetoBuildDbContext context)
        {
            _context = context;
        }

        [HttpGet("login/{id}")]
        public async Task<ActionResult> Index(int id)
        {
            var user = _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok("Login Successfull");
        }
    }
}
