using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Transportador1
{
    public Guid Id { get; set; }

    public Guid TenantId { get; set; }

    public Guid TransportadorId { get; set; }

    public int? TipoContaId { get; set; }

    public string? ChavePix { get; set; }

    public string? Banco { get; set; }

    public string? Agencia { get; set; }

    public string? AgencidaDigito { get; set; }

    public string? Conta { get; set; }

    public string? ContaDigito { get; set; }

    public string? CnpjCpfFavorecido { get; set; }

    public string? NomeFavorecido { get; set; }

    public virtual Pessoa IdNavigation { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual TipoContum? TipoConta { get; set; }

    public virtual Transportador Transportador { get; set; } = null!;
}
