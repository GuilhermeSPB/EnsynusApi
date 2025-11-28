namespace EnsynusApi.Dtos.Ingresso
{
    public class VwIngressoAlunoSaiuDto
    {
        public string TurmaNome { get; set; } = null!;
        public DateTime? DataEntrada { get; set; } = DateTime.MinValue;
        public DateTime? DataSaida { get; set; } = DateTime.MinValue;
        public string? Solicitacao { get; set; }
    }
}
