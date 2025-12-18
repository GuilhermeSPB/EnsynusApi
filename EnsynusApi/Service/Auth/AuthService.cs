using System;
using EnsynusApi.Dtos.Auth;
using EnsynusApi.Repository.Aluno;
using EnsynusApi.Repository.Professor;
using System.Runtime.CompilerServices;
using EnsynusApi.Service.Token;
using BCrypt.Net;
using System.Data;

namespace EnsynusApi.Service.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IAlunoRepository alunoRepository,
                           IProfessorRepository professorRepository,
                           ITokenService tokenService)
        {
            _alunoRepository = alunoRepository;
            _professorRepository = professorRepository;
            _tokenService = tokenService;
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
                    AluEmailResp = registerDto.EmailResp
                };
                await _alunoRepository.CreateAsync(aluno);


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
