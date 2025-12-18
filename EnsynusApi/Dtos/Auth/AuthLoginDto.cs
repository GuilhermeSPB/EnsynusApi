namespace EnsynusApi.Dtos.Auth
{
    public class AuthLoginDto
    {
        public string Email { get; set; } = null!; 
        public string Senha { get; set; } = null!;

        public UserRole Role { get; set; }
    }
}
