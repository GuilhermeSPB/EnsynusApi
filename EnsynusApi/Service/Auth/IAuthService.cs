using EnsynusApi.Dtos.Auth;

namespace EnsynusApi.Service.Auth
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> LoginUserAsync(AuthLoginDto loginDto);
        Task<AuthResponseDto> RegisterUserAsync(AuthRegisterDto registerDto);
        Task<bool> ConfirmarEmail(string token);
    }
}
