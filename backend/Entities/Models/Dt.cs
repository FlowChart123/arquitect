using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Dt
{
    public Guid Id { get; set; }

    public Guid TenantId { get; set; }

    public int FilialId { get; set; }

    public int DtStatusId { get; set; }

    public int Numero { get; set; }

    public DateTime DataEmissao { get; set; }

    public Guid MotoristaId { get; set; }

    public Guid TransportadorId { get; set; }

    public int VeiculoTracaoId { get; set; }

    public int? VeiculoReboqueId { get; set; }

    public int? VeiculoReboqueSemiId { get; set; }

    public DateTime DataCadastro { get; set; }

    public bool Ativo { get; set; }

    public virtual ICollection<CiotDt> CiotDts { get; } = new List<CiotDt>();

    public virtual ICollection<DtMdfe> DtMdves { get; } = new List<DtMdfe>();

    public virtual ICollection<DtRomaneioCarga> DtRomaneioCargas { get; } = new List<DtRomaneioCarga>();

    public virtual DtStatus DtStatus { get; set; } = null!;

    public virtual Filial Filial { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;
}
