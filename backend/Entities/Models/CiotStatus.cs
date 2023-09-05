using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class CiotStatus
{
    public int Id { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<Ciot> Ciots { get; } = new List<Ciot>();
}
