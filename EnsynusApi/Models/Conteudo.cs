using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnsynusApi.Models;

[Table("conteudo")]
public partial class Conteudo
{
    public int ConId { get; set; }

    public string? ConDescricao { get; set; }

    public string ConNome { get; set; } = null!;

    public string ConTipoArquivo { get; set; } = null!;

    public DateOnly ConDataAnexo { get; set; }

    public int FkIdAula { get; set; }

    public virtual Aula FkIdAulaNavigation { get; set; } = null!;
}
