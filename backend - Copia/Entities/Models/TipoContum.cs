using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class TipoContum
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Transportador1> Transportador1s { get; } = new List<Transportador1>();
}
