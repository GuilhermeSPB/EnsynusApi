using EnsynusApi.Data;
using EnsynusApi.Dtos.Auth;
using EnsynusApi.Exceptions;
using EnsynusApi.Models;
using EnsynusApi.Service.Auth;
using Microsoft.AspNetCore.Mvc;
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



        [HttpGet("reenviar-email")]
        public async Task<IActionResult> ReenviarEmail(string email, int role)
        {
            var user = new AuthReenviarEmailDto { };


            if (role == 0)
            {
                var aluno = await _context.Alunos.FirstOrDefaultAsync(a => a.AluEmail == email);

                user = new AuthReenviarEmailDto
                {
                    Email = aluno.AluEmail,
                    Nome = aluno.AluNome,
                    EmailConfirmado = aluno.EmailConfirmado,
                    EmailToken = aluno.EmailToken,
                    EmailTokenExpira = aluno.EmailTokenExpira,
                    Role = UserRole.Aluno

                };
            }
            else
            {

                var professor = await _context.Professors.FirstOrDefaultAsync(p => p.ProEmail == email);

                user = new AuthReenviarEmailDto
                {
                    Email = professor.ProEmail,
                    Nome = professor.ProNome,
                    EmailConfirmado = professor.EmailConfirmado,
                    EmailToken = professor.EmailToken,
                    EmailTokenExpira = professor.EmailTokenExpira,
                    Role = UserRole.Professor
                };
            }

            try
            {
                await _authService.ReenviarEmail(user);
                return Ok("Email reenviado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao reenviar email {ex}");

            }
        }
    }
}
