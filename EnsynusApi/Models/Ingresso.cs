using System;
using System.Collections.Generic;

namespace EnsynusApi.Models;

public partial class Ingresso
{
    public int IngId { get; set; }

    public DateOnly IngDataEntrada { get; set; }

    public DateOnly? IngDataSaida { get; set; }

    public string? IngSolicitacao { get; set; }

    public int FkAluId { get; set; }

    public int FkTurId { get; set; }

    public virtual Aluno FkAlu { get; set; } = null!;

    public virtual Turma FkTur { get; set; } = null!;
}
