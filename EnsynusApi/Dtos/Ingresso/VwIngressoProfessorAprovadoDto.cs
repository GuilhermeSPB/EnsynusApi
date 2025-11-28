namespace EnsynusApi.Dtos.Ingresso
{
    public class VwIngressoProfessorAprovadoDto
    {
        public string AlunoNome { get; set; } = null!;
        public DateTime? DataEntrada { get; set; } = DateTime.MinValue;
    }
}
