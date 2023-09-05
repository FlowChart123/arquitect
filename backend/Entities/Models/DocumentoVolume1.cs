using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class DocumentoVolume1
{
    public Guid Id { get; set; }

    public Guid DocumentoId { get; set; }

    public string VolumeChave { get; set; } = null!;

    public virtual Documento1 Documento { get; set; } = null!;
}
