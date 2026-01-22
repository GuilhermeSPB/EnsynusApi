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
            var aluno = await _context.Alunos.FirstOrDefaultAsync(a => a.EmailToken == token);

            if (aluno == null)
                return BadRequest("Token inválido");

            if (aluno.EmailTokenExpira < DateTime.UtcNow)
                return BadRequest("Token expirado");


            aluno.EmailConfirmado = true;
            aluno.EmailToken = null;
            aluno.EmailTokenExpira = null;

            return Ok("Email confirmado com sucesso.");
            
        }
    }
}
