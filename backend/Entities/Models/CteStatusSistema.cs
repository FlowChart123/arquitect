using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class CteStatusSistema
{
    public int Id { get; set; }

    public string Descricao { get; set; } = null!;

    public bool Ativo { get; set; }

    public virtual ICollection<DocumentoEletronico> DocumentoEletronicos { get; } = new List<DocumentoEletronico>();
}
