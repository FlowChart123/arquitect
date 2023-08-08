using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class CodigoBarra : BaseEntity
{
    public Guid Id { get; set; }

    public string CodigoBarras { get; set; } = null!;

    public decimal? Altura { get; set; }

    public decimal? Largura { get; set; }

    public decimal? Comprimento { get; set; }
}
