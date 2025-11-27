namespace EnsynusApi.Dtos.Professor
{
    public class UpdateProfessorDto
    {

        public string ProNome { get; set; } = null!;

        public string ProEmail { get; set; } = null!;

        public DateTime ProDataNasc { get; set; } = DateTime.MinValue;
    }
}
