using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDetailsAPI.DTOs;
using MovieDetailsAPI.Interfaces;

namespace MovieDetailsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO userRegisterDTO)
        {
            var token = await _userService.RegisterUserAsync(userRegisterDTO);
            if (token == null)
                return BadRequest("User registration failed.");

            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            var token = await _userService.LoginUserAsync(userLoginDTO);
            if (token == null)
                return Unauthorized("Invalid credentials.");

            return Ok(new { Token = token });
        }
    }
}
