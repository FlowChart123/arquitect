using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class RomaneioDocumento
{
    public Guid Id { get; set; }

    public Guid RomaneioId { get; set; }

    public Guid DocumentoId { get; set; }

    public virtual Documento1 IdNavigation { get; set; } = null!;

    public virtual Romaneio Romaneio { get; set; } = null!;
}
