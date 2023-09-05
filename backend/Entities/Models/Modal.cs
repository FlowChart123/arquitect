using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Modal
{
    public int Id { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<DocumentoCte> DocumentoCtes { get; } = new List<DocumentoCte>();

    public virtual ICollection<DtMdfe> DtMdves { get; } = new List<DtMdfe>();
}
