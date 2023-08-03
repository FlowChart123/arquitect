using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class PessoaFisica
{
    public Guid Id { get; set; }

    public string Cpf { get; set; } = null!;

    public string? Rg { get; set; }

    public virtual Pessoa IdNavigation { get; set; } = null!;
}
