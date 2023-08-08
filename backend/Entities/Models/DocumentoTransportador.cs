using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class DocumentoTransportador : BaseEntity
{
    public Guid Id { get; set; }

    public string? Cnpj { get; set; }

    public string? Nome { get; set; }

    public string? InscricaoEstadual { get; set; }

    public string? Municipio { get; set; }

    public string? Uf { get; set; }

    public virtual Documento IdNavigation { get; set; } = null!;
}
