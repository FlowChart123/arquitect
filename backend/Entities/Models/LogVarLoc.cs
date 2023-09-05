using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class LogVarLoc
{
    public int? LocNu { get; set; }

    public int ValNu { get; set; }

    public string ValTx { get; set; } = null!;
}
