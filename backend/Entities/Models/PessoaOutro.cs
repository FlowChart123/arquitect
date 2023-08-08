using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class PessoaOutro : BaseEntity
{
    public Guid Id { get; set; }

    public string Codigo { get; set; } = null!;

    public virtual Pessoa IdNavigation { get; set; } = null!;
}
