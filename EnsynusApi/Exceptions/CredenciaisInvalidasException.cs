namespace EnsynusApi.Exceptions
{
    public class CredenciaisInvalidasException : Exception
    {
        public CredenciaisInvalidasException():base("Email ou senha incorretos"){}
    }
}
