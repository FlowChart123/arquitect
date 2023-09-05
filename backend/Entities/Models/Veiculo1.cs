using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Veiculo1
{
    public Guid Id { get; set; }

    public Guid? TenantId { get; set; }

    public Guid? VeiculoId { get; set; }

    public Guid? MotoristaId { get; set; }

    public DateTime? DataCadastro { get; set; }

    public virtual Motoristum? Motorista { get; set; }

    public virtual ICollection<RomaneioCarga> RomaneioCargas { get; } = new List<RomaneioCarga>();

    public virtual Tenant? Tenant { get; set; }

    public virtual Veiculo? Veiculo { get; set; }
}
