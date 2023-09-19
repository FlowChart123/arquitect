using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class ClienteCodigo
{
    public int Id { get; set; }

    public Guid TenantId { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual Tenant Tenant { get; set; } = null!;
}
