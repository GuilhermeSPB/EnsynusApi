using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnsynusApi.Models;

[Table("ingresso")]
public partial class Ingresso
{
    public int IngId { get; set; }

    public DateTime? IngDataEntrada { get; set; } = DateTime.MinValue;

    public DateTime? IngDataSaida { get; set; } = DateTime.MinValue;

    public string? IngSolicitacao { get; set; }

    public int FkAluId { get; set; }

    public int FkTurId { get; set; }

    public virtual Aluno FkAlu { get; set; } = null!;

    public virtual Turma FkTur { get; set; } = null!;
}
