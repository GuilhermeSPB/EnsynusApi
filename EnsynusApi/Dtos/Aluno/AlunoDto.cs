using EnsynusApi.Models;

namespace EnsynusApi.Dtos.Aluno
{
    public class AlunoDto
    {
        public int AluId { get; set; }

        public string AluNome { get; set; } = null!;

        public string AluEmail { get; set; } = null!;

        public DateOnly AluDataNasc { get; set; }

        public string? AluEmailResp { get; set; }

        public string? AluNomeResp { get; set; }
    }
}
