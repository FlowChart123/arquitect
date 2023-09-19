using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class CiotDt
{
    public Guid Id { get; set; }

    public Guid CiotId { get; set; }

    public Guid DtId { get; set; }

    public virtual Ciot Ciot { get; set; } = null!;

    public virtual Dt Dt { get; set; } = null!;
}
