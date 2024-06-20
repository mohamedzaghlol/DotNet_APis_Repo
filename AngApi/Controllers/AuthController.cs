using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Linq;
using System.Security.Claims;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;
    // repository for user data 
    // private readonly UserRepository _userRepository;

    public AuthController(JwtService jwtService /*,UserRepository userRepository*/)
    {
        _jwtService = jwtService;
        //_userRepository = userRepository;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        // logic to perform user registration, validate input, create user

        string userId = "";
        // Generate JWT token
        string token = _jwtService.GenerateToken(userId);

        return Ok(new { Token = token });
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        // Perform user login logic, validate credentials, authenticate user
        string userId = "";

        // Generate JWT token
        string token = _jwtService.GenerateToken(userId);

        return Ok(new { Token = token });
    }

}