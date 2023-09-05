using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class TipoRntrc
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public virtual ICollection<Transportador> Transportadors { get; } = new List<Transportador>();
}
