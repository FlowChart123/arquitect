using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class LogFaixaLocalidade
{
    public int LocNu { get; set; }

    public string LocCepIni { get; set; } = null!;

    public string LocCepFim { get; set; } = null!;

    public string LocTipoFaixa { get; set; } = null!;
}
