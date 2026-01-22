using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnsynusApi.Models;

[Table("turma")]
public partial class Turma
{
    public int TurId { get; set; }

    public string TurAreaConhecimento { get; set; } = null!;

    public string? TurDescricao { get; set; }

    public string TurNome { get; set; } = null!;

    public string? TurDuracao { get; set; }

    public string? TurModalidade { get; set; }

    public int FkIdProfessor { get; set; }

    public virtual ICollection<Aula> Aulas { get; set; } = new List<Aula>();

    public virtual Professor FkIdProfessorNavigation { get; set; } = null!;

    public virtual ICollection<Ingresso> Ingressos { get; set; } = new List<Ingresso>();
}
