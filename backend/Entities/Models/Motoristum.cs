using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Motoristum
{
    public Guid Id { get; set; }

    public Guid TenantId { get; set; }

    public Guid PessoaId { get; set; }

    public virtual Pessoa Pessoa { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual ICollection<Veiculo1> Veiculo1s { get; } = new List<Veiculo1>();
}
