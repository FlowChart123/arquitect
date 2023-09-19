using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class DtStatus
{
    public int Id { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<Dt> Dts { get; } = new List<Dt>();
}
