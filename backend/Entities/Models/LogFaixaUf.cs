using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class LogFaixaUf
{
    public string UfeSg { get; set; } = null!;

    public string UfeCepIni { get; set; } = null!;

    public string UfeCepFim { get; set; } = null!;
}
