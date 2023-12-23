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

        [HttpPost("login")]
        public async Task<ActionResult> Index([FromBody] Login login)
        {
            bool existis = _context.Users.Any(_user => _user.Email == login.Email && _user.Password == login.Password && _user.Type == login.Type);
            var logs = _context.Users.Any(_user => _user.Email == login.Email && _user.Password == login.Password);
            if (existis)
            {
                if(login.Type == "admin")
                {
                    return Ok(new { status = 200, isSuccess = true, message = "Login Successfully as admin" });
                }
                return Ok(new { status = 200, isSuccess = true, message= "Login Successfully as user"});
            }

            return Ok(new { status = 401, isSuccess = false, message = "Invalid User"});
        }
    }
}
