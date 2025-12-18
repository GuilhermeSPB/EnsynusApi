using Microsoft.AspNetCore.Mvc;
using EnsynusApi.Dtos.Auth;
using EnsynusApi.Service.Auth;

namespace EnsynusApi.Controllers
{
    [Route("ensynus/api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthLoginDto loginDto)
        {
            var response = await _authService.LoginUserAsync(loginDto);
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthRegisterDto registerDto)
        {
            var response = await _authService.RegisterUserAsync(registerDto);
            return Ok(response);
        }
    }
}
