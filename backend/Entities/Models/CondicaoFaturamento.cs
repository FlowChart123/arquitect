using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class CondicaoFaturamento
{
    public int Id { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();
}
