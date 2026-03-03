namespace EnsynusApi.Exceptions
{
    public class EmailNaoConfirmadoException : Exception
    {
        public EmailNaoConfirmadoException() 
            : base("Confirme seu email antes de entrar"){ }
    }
}
