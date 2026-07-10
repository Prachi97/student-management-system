using Microsoft.AspNetCore.Mvc;
using StudentManagement.Authentication;

namespace StudentManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;

    public AuthController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        if (request.Username != "admin" ||
            request.Password != "password")
        {
            return Unauthorized();
        }

        var token = _jwtService.GenerateToken(request.Username);

        return Ok(new LoginResponse
        {
            Token = token
        });
    }
}