using System.Security.Claims;

namespace EnsynusApi.Service.Token
{
    public interface ITokenService
    {
        string GenerateToken(
            int userId,
            string nome,
            string email,
            string role);
    }
}
