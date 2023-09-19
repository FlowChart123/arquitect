using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class LogFaixaBairro
{
    public int BaiNu { get; set; }

    public string FcbCepIni { get; set; } = null!;

    public string FcbCepFim { get; set; } = null!;
}
