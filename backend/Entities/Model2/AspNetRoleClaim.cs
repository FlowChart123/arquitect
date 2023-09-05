using System;
using System.Collections.Generic;
using Entities.Models;

namespace Entities.Model2;

public partial class AspNetRoleClaim
{
    public int Id { get; set; }

    public string RoleId { get; set; } = null!;

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public virtual ICollection<MenuItem> MenuItems { get; } = new List<MenuItem>();

    public virtual AspNetRole Role { get; set; } = null!;
}
