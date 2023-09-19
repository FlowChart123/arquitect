using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class DtMdfeDtRomaneio
{
    public Guid Id { get; set; }

    public Guid DtMdfeId { get; set; }

    public Guid DtRomaneioId { get; set; }

    public virtual DtMdfe DtMdfe { get; set; } = null!;

    public virtual DtRomaneioCarga DtRomaneio { get; set; } = null!;
}
