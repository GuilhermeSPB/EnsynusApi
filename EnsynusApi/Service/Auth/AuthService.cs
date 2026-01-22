using EnsynusApi.Dtos.Auth;
using EnsynusApi.Models;
using EnsynusApi.Repository.Aluno;
using EnsynusApi.Repository.Professor;
using EnsynusApi.Service.Email;
using EnsynusApi.Service.Token;

namespace EnsynusApi.Service.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;


        public AuthService(IAlunoRepository alunoRepository,
                           IProfessorRepository professorRepository,
                           ITokenService tokenService,
                           IEmailService emailService)
        {
            _alunoRepository = alunoRepository;
            _professorRepository = professorRepository;
            _tokenService = tokenService;
            _emailService = emailService;
        }


        public async Task<AuthResponseDto> LoginUserAsync(AuthLoginDto loginDto)
        {
            var role = loginDto.Role.ToString().ToLower();

            if (role == "aluno")
            {
                var aluno = await _alunoRepository.GetByEmailAsync(loginDto.Email);

                if (aluno == null || !BCrypt.Net.BCrypt.Verify(loginDto.Senha, aluno.AluSenha))
                {
                    throw new UnauthorizedAccessException("Checar e-mail ou senha");
                }

                if (!aluno.EmailConfirmado)
                    throw new Exception("Confirme seu email antes de entrar");

                var tokenAluno = _tokenService.GenerateToken(
                    aluno.AluId,
                    aluno.AluNome,
                    aluno.AluEmail,
                    "aluno"
                );

                return new AuthResponseDto
                {
                    Token = tokenAluno,
                    Nome = aluno.AluNome,
                    Email = aluno.AluEmail,
                    Role = UserRole.Aluno
                };
            }

            var professor = await _professorRepository.GetByEmailAsync(loginDto.Email);
            if (professor == null || !BCrypt.Net.BCrypt.Verify(loginDto.Senha, professor.ProSenha))
            {
                throw new UnauthorizedAccessException("Checar e-mail, senha ou tipo de perfil");
            }

            if (!professor.EmailConfirmado)
                throw new Exception("Confirme seu email antes de entrar");

            var tokenProfessor = _tokenService.GenerateToken(
                professor.ProId,
                professor.ProNome,
                professor.ProEmail,
                "professor"
            );

            return new AuthResponseDto
            {
                Token = tokenProfessor,
                Nome = professor.ProNome,
                Email = professor.ProEmail,
                Role = UserRole.Professor
            };
        }


        public async Task<AuthResponseDto> RegisterUserAsync(AuthRegisterDto registerDto)
        {
            var role = registerDto.Role.ToString().ToLower();

            if (role != "aluno" && role != "professor")
                throw new Exception("Role inválida. Deve ser 'aluno' ou 'professor'.");


            if (role == "aluno")
            {
                if (await _alunoRepository.GetByEmailAsync(registerDto.Email) != null)
                    throw new Exception("Email já cadastrado");
            }
            else
            {
                if (await _professorRepository.GetByEmailAsync(registerDto.Email) != null)
                    throw new Exception("Email já cadastrado");
            }

            var senhaHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Senha);


            if (role == "aluno")
            {
                var aluno = new Models.Aluno
                {
                    AluNome = registerDto.Nome,
                    AluEmail = registerDto.Email,
                    AluSenha = senhaHash,
                    AluDataNasc = registerDto.DataNasc,
                    AluNomeResp = registerDto.NomeResp,
                    AluEmailResp = registerDto.EmailResp,
                    EmailConfirmado = false,
                    EmailToken = Guid.NewGuid().ToString(),
                    EmailTokenExpira = DateTime.UtcNow.AddMinutes(30)
                };
                await _alunoRepository.CreateAsync(aluno);


                var link = $"http://localhost:5173/confirmar-email?token={aluno.EmailToken}";

                await _emailService.SendAsync(
                aluno.AluEmail,
                "Confirme seu e-mail",
                $"<p>Olá, {aluno.AluNome}.</p>" +
                $"<p>Clique no link abaixo para confirmar seu e-mail:</p>" +
                $"<a href='{link}'>Confirmar e-mail</a>"
            );

                var tokenAluno = _tokenService.GenerateToken(
                    aluno.AluId,
                    aluno.AluNome,
                    aluno.AluEmail,
                    "aluno"
                );


                return new AuthResponseDto
                {
                    Token = tokenAluno,
                    Nome = aluno.AluNome,
                    Email = aluno.AluEmail,
                    Role = UserRole.Aluno
                };
            }

            var professor = new Models.Professor
            {
                ProNome = registerDto.Nome,
                ProEmail = registerDto.Email,
                ProSenha = senhaHash,
                ProDataNasc = registerDto.DataNasc

            };
            await _professorRepository.CreateAsync(professor);


            var tokenProfessor = _tokenService.GenerateToken(
                professor.ProId,
                professor.ProNome,
                professor.ProEmail,
                "professor"
            );


            return new AuthResponseDto
            {
                Token = tokenProfessor,
                Nome = professor.ProNome,
                Email = professor.ProEmail,
                Role = UserRole.Professor
            };


        }

    }
}
