using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class CteStatusSefaz
{
    public int Id { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<DocumentoCte> DocumentoCtes { get; } = new List<DocumentoCte>();

    public virtual ICollection<LoteEletronico> LoteEletronicos { get; } = new List<LoteEletronico>();
}
