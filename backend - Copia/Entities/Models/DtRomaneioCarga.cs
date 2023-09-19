using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class DtRomaneioCarga
{
    public Guid Id { get; set; }

    public Guid DtId { get; set; }

    public Guid RomaneioCargaId { get; set; }

    public virtual Dt Dt { get; set; } = null!;

    public virtual ICollection<DtMdfeDtRomaneio> DtMdfeDtRomaneios { get; } = new List<DtMdfeDtRomaneio>();

    public virtual RomaneioCarga RomaneioCarga { get; set; } = null!;
}
