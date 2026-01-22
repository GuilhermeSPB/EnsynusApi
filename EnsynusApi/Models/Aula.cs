using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnsynusApi.Models;

[Table("aula")]
public partial class Aula
{
    public int AulId { get; set; }

    public string? AulDescricao { get; set; }

    public DateOnly AulData { get; set; }

    public string AulNome { get; set; } = null!;

    public int FkIdTurma { get; set; }

    public virtual ICollection<Conteudo> Conteudos { get; set; } = new List<Conteudo>();

    public virtual Turma FkIdTurmaNavigation { get; set; } = null!;
}
