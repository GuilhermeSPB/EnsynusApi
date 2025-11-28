namespace EnsynusApi.Dtos.Turma
{
    public class vwTurmaDto
    {
        public string Nome { get; set; } = null!;

        public string Area { get; set; } = null!;

        public string? Professor { get; set; }

        public string? Modalidade { get; set; }
    }
}
