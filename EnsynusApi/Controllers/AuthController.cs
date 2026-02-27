using Microsoft.AspNetCore.Mvc;
using EnsynusApi.Dtos.Auth;
using EnsynusApi.Service.Auth;
using EnsynusApi.Data;
using Microsoft.EntityFrameworkCore;


namespace EnsynusApi.Controllers
{
    [Route("ensynus/api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly EnsynusContext _context;

        public AuthController(IAuthService authService,
                              EnsynusContext context)
        {
            _authService = authService;
            _context = context;
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

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string token)
        {

            var confirm = await _authService.ConfirmarEmail(token);

            if (confirm)
                return Ok("Email confirmado");


            return BadRequest("Erro ao confirmar email");

            
            
        }
    }
}
