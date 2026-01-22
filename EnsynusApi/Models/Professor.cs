using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnsynusApi.Models;

[Table("professor")]
public partial class Professor
{
    public int ProId { get; set; }

    public string ProNome { get; set; } = null!;

    public string ProEmail { get; set; } = null!;

    public string ProSenha { get; set; } = null!;

    public DateTime? ProDataNasc { get; set; } = DateTime.MinValue;

    public virtual ICollection<Turma> Turmas { get; set; } = new List<Turma>();



    //Autentificação do e-mail

    public bool EmailConfirmado { get; set; }

    public string? EmailToken { get; set; }

    public DateTime? EmailTokenExpira { get; set; }
}
