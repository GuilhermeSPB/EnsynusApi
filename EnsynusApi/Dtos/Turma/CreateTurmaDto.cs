using EnsynusApi.Models;

namespace EnsynusApi.Dtos.Turma
{
    public class CreateTurmaDto
    {
        public string TurNome { get; set; } = null!;
        public string TurAreaConhecimento { get; set; } = null!;
        public string? TurDescricao { get; set; }   
        public string? TurDuracao { get; set; }
        public string? TurModalidade { get; set; }
        public int FkIdProfessor { get; set; }

    }
}
