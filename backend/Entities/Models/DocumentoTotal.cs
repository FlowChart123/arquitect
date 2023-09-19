using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class DocumentoTotal
{
    public Guid Id { get; set; }

    public decimal? ValorNota { get; set; }

    public decimal? PesoLiquido { get; set; }

    public decimal? PesoBruto { get; set; }

    public decimal? PesoCubado { get; set; }

    public decimal? Volumes { get; set; }

    public decimal? MetragemCubica { get; set; }

    public virtual Documento IdNavigation { get; set; } = null!;
}
