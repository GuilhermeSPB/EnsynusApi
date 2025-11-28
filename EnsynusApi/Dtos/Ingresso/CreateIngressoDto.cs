namespace EnsynusApi.Dtos.Ingresso
{
    public class CreateIngressoDto
    {
        public int FkAluId { get; set; }

        public int FkTurId { get; set; }

        public DateTime? IngDataEntrada { get; set; } = DateTime.MinValue;

        public DateTime? IngDataSaida { get; set; } = DateTime.MinValue;

        public string? IngSolicitacao { get; set; }
    }
}
