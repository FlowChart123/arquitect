using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class LogVarBai
{
    public int BaiNu { get; set; }

    public int VdbNu { get; set; }

    public string VdbTx { get; set; } = null!;
}
