using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class DocumentoCte
{
    public Guid Id { get; set; }

    public Guid DocumentoFreteId { get; set; }

    public Guid TomadorServicoId { get; set; }

    public Guid? ExpedidorId { get; set; }

    public Guid? RecebedorId { get; set; }

    public int? CteStatusSistemaId { get; set; }

    public int? CteStatusSefazId { get; set; }

    public int MunicipioInicioTransporteId { get; set; }

    public int MunicipioFinalTransporteId { get; set; }

    public int FilialOrigemId { get; set; }

    public int FilialDestinoId { get; set; }

    public int ModalId { get; set; }

    public int TipoCteId { get; set; }

    public int TipoServicoPrestadoId { get; set; }

    public string? IndicadorTipoCte { get; set; }

    public string? CaracteristicaTransporte { get; set; }

    public string? CaracteristicaServico { get; set; }

    public string? Recibo { get; set; }

    public virtual CteStatusSefaz? CteStatusSefaz { get; set; }

    public virtual CteStatusSistema? CteStatusSistema { get; set; }

    public virtual ICollection<DocumentoEletronico> DocumentoEletronicos { get; } = new List<DocumentoEletronico>();

    public virtual DocumentoFrete DocumentoFrete { get; set; } = null!;

    public virtual Pessoa? Expedidor { get; set; }

    public virtual Empresa FilialDestino { get; set; } = null!;

    public virtual Filial FilialOrigem { get; set; } = null!;

    public virtual Documento1 IdNavigation { get; set; } = null!;

    public virtual Modal Modal { get; set; } = null!;

    public virtual Municipio MunicipioFinalTransporte { get; set; } = null!;

    public virtual Municipio MunicipioInicioTransporte { get; set; } = null!;

    public virtual Pessoa? Recebedor { get; set; }

    public virtual TipoCte TipoCte { get; set; } = null!;

    public virtual TipoServicoPrestado TipoServicoPrestado { get; set; } = null!;

    public virtual Cliente TomadorServico { get; set; } = null!;
}
