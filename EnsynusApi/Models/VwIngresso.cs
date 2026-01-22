using System.ComponentModel.DataAnnotations.Schema;

namespace EnsynusApi.Models
{
    public partial class VwIngresso
    {
        public int Cod { get; set; }
        public string AlunoNome { get; set; } = null!;
        public string TurmaNome { get; set; } = null!;
        public DateTime? DataEntrada { get; set; } = DateTime.MinValue;
        public DateTime? DataSaida { get; set; } = DateTime.MinValue;
        public string? Solicitacao { get; set; }
        public int AluId { get; set; }
        public int TurId { get; set; }
    }

}
