using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class LogUnidOper
{
    public int UopNu { get; set; }

    public string UfeSg { get; set; } = null!;

    public int LocNu { get; set; }

    public int BaiNu { get; set; }

    public int? LogNu { get; set; }

    public string UopNo { get; set; } = null!;

    public string UopEndereco { get; set; } = null!;

    public string Cep { get; set; } = null!;

    public string UopInCp { get; set; } = null!;

    public string? UopNoAbrev { get; set; }
}
