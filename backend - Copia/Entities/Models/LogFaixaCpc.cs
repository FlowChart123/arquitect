using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class LogFaixaCpc
{
    public int CpcNu { get; set; }

    public string CpcInicial { get; set; } = null!;

    public string CpcFinal { get; set; } = null!;
}
