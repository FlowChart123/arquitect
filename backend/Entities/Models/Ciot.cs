using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Ciot
{
    public Guid Id { get; set; }

    public Guid TenantId { get; set; }

    public int FilialId { get; set; }

    public int CiotStatusId { get; set; }

    public string? Numero { get; set; }

    public DateTime? DataEmissao { get; set; }

    public DateTime? DataFechamento { get; set; }

    public DateTime? DataCancelamento { get; set; }

    public DateTime? DataRetificacao { get; set; }

    public DateTime DataCadastro { get; set; }

    public bool Ativo { get; set; }

    public virtual ICollection<CiotDt> CiotDts { get; } = new List<CiotDt>();

    public virtual CiotStatus CiotStatus { get; set; } = null!;

    public virtual Filial Filial { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;
}
