namespace EnsynusApi.Dtos.Auth
{
    public class AuthRegisterDto
    {
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public DateTime? DataNasc { get; set; }
        public UserRole Role { get; set; }


        //Campos Alunos
        public string NomeResp { get; set; }
        public string EmailResp { get; set; }


    }


    public enum UserRole
    {
        Aluno,
        Professor
    }
}
