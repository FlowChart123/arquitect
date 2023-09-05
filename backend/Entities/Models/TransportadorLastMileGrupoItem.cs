using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class TransportadorLastMileGrupoItem
{
    public Guid Id { get; set; }

    public Guid TransportadorLastMileGrupoId { get; set; }

    public Guid TransportadorLastMileId { get; set; }

    public virtual TransportadorLastMile TransportadorLastMile { get; set; } = null!;

    public virtual TransportadorLastMileGrupo TransportadorLastMileGrupo { get; set; } = null!;
}
