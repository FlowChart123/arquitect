using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class FilialLastMileGrupoItem : BaseEntity
{
    public Guid Id { get; set; }

    public Guid FilialLastMileGrupoId { get; set; }

    public Guid FilialLastMileId { get; set; }

    public virtual FilialLastMile FilialLastMile { get; set; } = null!;

    public virtual FilialLastMileGrupo FilialLastMileGrupo { get; set; } = null!;
}
