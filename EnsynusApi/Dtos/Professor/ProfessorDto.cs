using EnsynusApi.Models;

namespace EnsynusApi.Dtos.Professor
{
    public class ProfessorDto
    {
        public int ProId { get; set; }

        public string ProNome { get; set; } = null!;

        public string ProEmail { get; set; } = null!;

        public string ProSenha { get; set; } = null!;

        public DateTime? ProDataNasc { get; set; }

    }
}
