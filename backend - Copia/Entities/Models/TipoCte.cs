using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class TipoCte
{
    public int Id { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<DocumentoCte> DocumentoCtes { get; } = new List<DocumentoCte>();
}
