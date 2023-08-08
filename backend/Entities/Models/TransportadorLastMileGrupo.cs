using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class TransportadorLastMileGrupo : BaseEntity
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Codigo { get; set; }

    public int? Ordem { get; set; }

    public bool? Ativo { get; set; }

    public virtual ICollection<TransportadorLastMileGrupoItem> TransportadorLastMileGrupoItems { get; } = new List<TransportadorLastMileGrupoItem>();
}
