using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class LoteEletronico
{
    public Guid Id { get; set; }

    public Guid TenantId { get; set; }

    public int FilialId { get; set; }

    public int? CteStatusSefazId { get; set; }

    public string? Recibo { get; set; }

    public int? EnvioNumero { get; set; }

    public DateTime? EnvioData { get; set; }

    public DateTime? DataCadastro { get; set; }

    public virtual CteStatusSefaz? CteStatusSefaz { get; set; }

    public virtual ICollection<DocumentoEletronico> DocumentoEletronicos { get; } = new List<DocumentoEletronico>();

    public virtual Filial Filial { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;
}
