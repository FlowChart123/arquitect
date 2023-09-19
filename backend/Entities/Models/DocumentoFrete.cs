using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class DocumentoFrete
{
    public Guid Id { get; set; }

    public Guid DocumentoId { get; set; }

    public decimal? FretePeso { get; set; }

    public decimal? FreteValor { get; set; }

    public virtual Documento1 Documento { get; set; } = null!;

    public virtual ICollection<DocumentoCte> DocumentoCtes { get; } = new List<DocumentoCte>();
}
