using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class CteStatusSefaz
{
    public int Id { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<DocumentoEletronico> DocumentoEletronicos { get; } = new List<DocumentoEletronico>();

    public virtual ICollection<LoteEletronico> LoteEletronicos { get; } = new List<LoteEletronico>();
}
