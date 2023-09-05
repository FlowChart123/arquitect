using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class EctPai
{
    public string PaiSg { get; set; } = null!;

    public string? PaiSgAlternativa { get; set; }

    public string PaiNoPortugues { get; set; } = null!;

    public string? PaiNoIngles { get; set; }

    public string? PaiNoFrances { get; set; }

    public string? PaiAbreviatura { get; set; }
}
