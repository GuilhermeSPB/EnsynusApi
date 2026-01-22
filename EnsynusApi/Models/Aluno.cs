using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnsynusApi.Models;

[Table("aluno")]
public partial class Aluno
{
    public int AluId { get; set; }

    public string AluNome { get; set; } = null!;

    public string AluEmail { get; set; } = null!;

    public string AluSenha { get; set; } = null!;

    public DateTime? AluDataNasc { get; set; } = DateTime.MinValue;

    public string? AluEmailResp { get; set; }

    public string? AluNomeResp { get; set; }

    public virtual ICollection<Ingresso> Ingressos { get; set; } = new List<Ingresso>();


    //Autentificação do e-mail

    public bool EmailConfirmado { get; set; }

    public string? EmailToken { get; set; }
    public DateTime? EmailTokenExpira { get; set; }
}
