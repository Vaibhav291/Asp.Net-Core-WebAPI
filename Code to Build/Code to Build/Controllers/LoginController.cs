using Code_to_Build.Model;
using Microsoft.AspNetCore.Cors;
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

        [HttpGet("login")]
        public async Task<ActionResult> Index([FromBody] User user)
        {
            bool existis = _context.Users.Any(_user => _user.Email == user.Email && _user.Password==user.Password);
            if (existis)
            {
                ISession session = HttpContext.Session;
                session.SetInt32("UserId", _context.Users.Single(x => x.Email == user.Email).Id);
                return RedirectToAction("GetAllBlogs","Blog");
            }

            return NoContent();
        }
    }
}
