using System;
using System.Collections.Generic;

namespace EnsynusApi.Models;

public partial class VwTurmaxprofessor
{
    public int Cód { get; set; }
    public string Nome { get; set; } = null!;

    public string Área { get; set; } = null!;

    public string? Professor { get; set; }

    public string? Modalidade { get; set; }
}
