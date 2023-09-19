using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class TipoServicoPrestado
{
    public int Id { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<DocumentoCte> DocumentoCtes { get; } = new List<DocumentoCte>();
}
