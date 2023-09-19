using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class LogLogradouro
{
    public int LogNu { get; set; }

    public string UfeSg { get; set; } = null!;

    public int LocNu { get; set; }

    public int? BaiNuIni { get; set; }

    public int? BaiNuFim { get; set; }

    public string LogNo { get; set; } = null!;

    public string? LogComplemento { get; set; }

    public string Cep { get; set; } = null!;

    public string TloTx { get; set; } = null!;

    public string? LogStaTlo { get; set; }

    public string? LogNoAbrev { get; set; }
}
