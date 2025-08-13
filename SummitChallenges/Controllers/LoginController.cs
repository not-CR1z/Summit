using Microsoft.AspNetCore.Mvc;
using SummitChallenges.Models;
using SummitChallenges.Services;
using System;
using System.Text.Json;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly string _secretKey;
    public LoginController(IConfiguration config)
    {
        _secretKey = config.GetSection("settings").GetSection("secretKey").ToString()!;
    }

    [HttpPost(Name = "login")]
    public IActionResult Login(User user)
    {
        if (user != null)
        {
            LoginService loginService = new LoginService();
            var retrieveUser = loginService.Login(user.UserLogOn, user.Password);

            if (retrieveUser != null)
            {
                // Genera el JWT
                var token = JwtUtilities.GenerateToken(_secretKey, retrieveUser.UserLogOn, retrieveUser.Role);
                return Ok(new { user = JsonSerializer.Serialize(retrieveUser), token });
            }
        }
        return BadRequest(new { message = "Nombre de usuario o contraseña incorrectos" });
    }
}
