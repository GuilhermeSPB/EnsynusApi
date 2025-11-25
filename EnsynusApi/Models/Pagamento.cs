using System;
using System.Collections.Generic;

namespace EnsynusApi.Models;

public partial class Pagamento
{
    public DateOnly PagData { get; set; }

    public decimal PagValorPago { get; set; }

    public string PagStatus { get; set; } = null!;

    public int FkIdAluno { get; set; }

    public int FkIdTurma { get; set; }

    public virtual Aluno FkIdAlunoNavigation { get; set; } = null!;

    public virtual Turma FkIdTurmaNavigation { get; set; } = null!;
}
