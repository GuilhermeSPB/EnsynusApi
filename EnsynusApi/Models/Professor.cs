using System;
using System.Collections.Generic;

namespace EnsynusApi.Models;

public partial class Professor
{
    public int ProId { get; set; }

    public string ProNome { get; set; } = null!;

    public string ProEmail { get; set; } = null!;

    public string ProSenha { get; set; } = null!;

    public DateOnly ProDataNasc { get; set; }

    public virtual ICollection<Turma> Turmas { get; set; } = new List<Turma>();
}
