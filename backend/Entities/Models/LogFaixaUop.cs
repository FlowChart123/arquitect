using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class LogFaixaUop
{
    public int UopNu { get; set; }

    public string FncInicial { get; set; } = null!;

    public string FncFinal { get; set; } = null!;
}
