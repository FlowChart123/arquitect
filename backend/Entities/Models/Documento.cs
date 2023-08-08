using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Documento : BaseEntity
{
    public Guid Id { get; set; }

    public int TipoDocumentoId { get; set; }

    public string Chave { get; set; } = null!;

    public Guid EmitenteId { get; set; }

    public Guid RemetenteId { get; set; }

    public Guid DestinatarioId { get; set; }

    public int Numero { get; set; }

    public string Serie { get; set; } = null!;

    public string NumeroCliente { get; set; } = null!;

    public string? XPed { get; set; }

    public DateTime? DataEmissao { get; set; }

    public DateTime DataCadastro { get; set; }

    public virtual Pessoa Destinatario { get; set; } = null!;

    public virtual ICollection<Documento1> Documento1s { get; } = new List<Documento1>();

    public virtual DocumentoImposto? DocumentoImposto { get; set; }

    public virtual ICollection<DocumentoItem> DocumentoItems { get; } = new List<DocumentoItem>();

    public virtual DocumentoTotal? DocumentoTotal { get; set; }

    public virtual DocumentoTransportador? DocumentoTransportador { get; set; }

    public virtual Pessoa Emitente { get; set; } = null!;

    public virtual Pessoa Remetente { get; set; } = null!;

    public virtual TipoDocumento TipoDocumento { get; set; } = null!;
}
