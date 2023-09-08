using System;
using System.Collections.Generic;

namespace Entities.IdentityModels;

public partial class AppRouteStatus
{
    public int Id { get; set; }

    public string Descricao { get; set; } = null!;

    public bool Ativo { get; set; }

    public virtual ICollection<AppRouteUser> AppRouteUsers { get; } = new List<AppRouteUser>();
}
