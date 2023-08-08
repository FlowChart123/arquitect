using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Romaneio : BaseEntity
{
    public Guid Id { get; set; }

    public Guid TenantId { get; set; }

    public DateTime DataEmissao { get; set; }

    public DateTime DataCadastro { get; set; }

    public virtual RomaneioCarga? RomaneioCarga { get; set; }

    public virtual ICollection<RomaneioDocumento> RomaneioDocumentos { get; } = new List<RomaneioDocumento>();

    public virtual Tenant Tenant { get; set; } = null!;
}
