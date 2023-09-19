using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class LogCpc
{
    public int CpcNu { get; set; }

    public string UfeSg { get; set; } = null!;

    public int LocNu { get; set; }

    public string CpcNo { get; set; } = null!;

    public string CpcEndereco { get; set; } = null!;

    public string Cep { get; set; } = null!;
}
