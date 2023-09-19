using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class ChaveValor
{
    public Guid Id { get; set; }

    public Guid TenantId { get; set; }

    public string Chave { get; set; } = null!;

    public string Valor { get; set; } = null!;

    public DateTime DataCadastro { get; set; }

    public virtual Tenant Tenant { get; set; } = null!;
}
