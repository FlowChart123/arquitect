using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class LogGrandeUsuario
{
    public int GruNu { get; set; }

    public string UfeSg { get; set; } = null!;

    public int LocNu { get; set; }

    public int BaiNu { get; set; }

    public int? LogNu { get; set; }

    public string GruNo { get; set; } = null!;

    public string GruEndereco { get; set; } = null!;

    public string Cep { get; set; } = null!;

    public string? GruNoAbrev { get; set; }
}
