using EnsynusApi.Models;

namespace EnsynusApi.Dtos.Aluno
{
    public class UpdateAlunoDto
    {
        public string AluNome { get; set; } = null!;

        public string AluEmail { get; set; } = null!;

        public string AluSenha { get; set; } = null!;

        public DateTime AluDataNasc { get; set; } = DateTime.MinValue;

        public string? AluEmailResp { get; set; }

        public string? AluNomeResp { get; set; }

    }
}
