using System;
using System.Collections.Generic;
using Entities.Model2;

namespace Entities.Models;

public partial class MenuItem
{
    public Guid Id { get; set; }

    public Guid? MenuItemParentId { get; set; }

    public int? AspNetRoleClaimsId { get; set; }

    public string MenuText { get; set; } = null!;

    public string? CssClass { get; set; }

    public string? Url { get; set; }

    public bool CheckPermission { get; set; }

    public bool Authenticated { get; set; }

    public string? GroupName { get; set; }

    public int? MenuOrder { get; set; }

    public bool Enabled { get; set; }

    public string FullPath { get; set; } = null!;

    public virtual AspNetRoleClaim? AspNetRoleClaims { get; set; }

    public virtual ICollection<MenuItem> InverseMenuItemParent { get; } = new List<MenuItem>();

    public virtual MenuItem? MenuItemParent { get; set; }
}
