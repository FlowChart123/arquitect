using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Empresa
{
    public int Id { get; set; }

    public Guid TenantId { get; set; }

    public string Nome { get; set; } = null!;

    public bool Ativo { get; set; }

    public virtual ICollection<DocumentoCte> DocumentoCtes { get; } = new List<DocumentoCte>();

    public virtual ICollection<Filial> Filials { get; } = new List<Filial>();

    public virtual Tenant Tenant { get; set; } = null!;
}
