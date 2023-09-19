using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class DocumentoEletronico
{
    public Guid Id { get; set; }

    public Guid DocumentoId { get; set; }

    public Guid? LoteEletronicoId { get; set; }

    public int? CteStatusSistemaId { get; set; }

    public int? CteStatusSefazId { get; set; }

    public DateTime? DataCadastro { get; set; }

    public virtual CteStatusSefaz? CteStatusSefaz { get; set; }

    public virtual CteStatusSistema? CteStatusSistema { get; set; }

    public virtual DocumentoCte Documento { get; set; } = null!;

    public virtual LoteEletronico? LoteEletronico { get; set; }
}
