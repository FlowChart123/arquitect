using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Pais
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Sigla { get; set; }

    public virtual ICollection<Estado> Estados { get; } = new List<Estado>();
}
