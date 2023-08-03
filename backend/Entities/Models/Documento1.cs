using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Documento1
{
    public Guid Id { get; set; }

    public Guid DocumentoId { get; set; }

    public Guid TenantId { get; set; }

    public DateTime DataEntrada { get; set; }

    public bool? Ativo { get; set; }

    public virtual Documento Documento { get; set; } = null!;

    public virtual DocumentoFilialGrupo? DocumentoFilialGrupo { get; set; }

    public virtual RomaneioDocumento? RomaneioDocumento { get; set; }

    public virtual Tenant Tenant { get; set; } = null!;
}
