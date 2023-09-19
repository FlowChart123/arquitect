using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class PessoaJuridicaComplemento
{
    public Guid Id { get; set; }

    public virtual PessoaJuridica IdNavigation { get; set; } = null!;
}
