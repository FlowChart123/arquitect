using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class LogNumSec
{
    public int LogNu { get; set; }

    public string SecNuIni { get; set; } = null!;

    public string SecNuFim { get; set; } = null!;

    public string SecInLado { get; set; } = null!;
}
