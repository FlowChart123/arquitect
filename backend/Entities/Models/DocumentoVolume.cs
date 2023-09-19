using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class DocumentoVolume
{
    public Guid Id { get; set; }

    public Guid DocumentoId { get; set; }

    public string VolumeChave { get; set; } = null!;

    public virtual Documento Documento { get; set; } = null!;
}
