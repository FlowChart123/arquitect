using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class TipoDocumento
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Documento> Documentos { get; } = new List<Documento>();
}
