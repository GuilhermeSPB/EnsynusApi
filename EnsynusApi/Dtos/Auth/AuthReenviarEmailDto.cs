namespace EnsynusApi.Dtos.Auth
{
    public class AuthReenviarEmailDto
    {
        public string Email { get; set; } = null!;
        public String Nome { get; set; } = null!;
        public UserRole Role { get; set; }

        public bool EmailConfirmado { get; set; }

        public string? EmailToken { get; set; }
        public DateTime? EmailTokenExpira { get; set; }

    }
}
