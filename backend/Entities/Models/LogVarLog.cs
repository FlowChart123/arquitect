using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class LogVarLog
{
    public int LogNu { get; set; }

    public int VloNu { get; set; }

    public string TloTx { get; set; } = null!;

    public string VloTx { get; set; } = null!;
}
