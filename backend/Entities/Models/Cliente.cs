using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Cliente
{
    public Guid Id { get; set; }

    public int? CondicaoFaturamentoId { get; set; }

    public int? FaturamentoFilialId { get; set; }

    public int? CfopCteId { get; set; }

    public int? CanalId { get; set; }

    public int? ClienteCodigoId { get; set; }

    public int? PrazoPagamento { get; set; }

    public string? InicioContagemPrazo { get; set; }

    public string? DiaPagamentoSemana { get; set; }

    public string? DiaPagamentoMes { get; set; }

    public virtual Canal? Canal { get; set; }

    public virtual CfopCte? CfopCte { get; set; }

    public virtual ClienteCodigo? ClienteCodigo { get; set; }

    public virtual CondicaoFaturamento? CondicaoFaturamento { get; set; }

    public virtual ICollection<DocumentoCte> DocumentoCtes { get; } = new List<DocumentoCte>();

    public virtual Filial? FaturamentoFilial { get; set; }

    public virtual Pessoa IdNavigation { get; set; } = null!;
}
