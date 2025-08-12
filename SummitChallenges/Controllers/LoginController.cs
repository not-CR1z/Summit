using Microsoft.AspNetCore.Mvc;
using SummitChallenges.Models;
using SummitChallenges.Services;

namespace SummitChallenges.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private static readonly String[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "login")]
        public async Task<IActionResult> Login(User user)
        {
            if (user != null)
            {
                LoginService loginService = new LoginService();
                var validationState = loginService.Login(user.UserLogOn, user.Password);
                if (validationState)
                {
                    return Ok(new { message = "Validación exitosa" });
                }
            }
            return this.BadRequest(new { message = "Nombre de usuario o contaseña incorrectos" });
        }
    }
}
