using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class PessoaFisica
{
    public Guid Id { get; set; }

    public string Cpf { get; set; } = null!;

    public virtual Pessoa IdNavigation { get; set; } = null!;

    public virtual PessoaFisicaComplemento? PessoaFisicaComplemento { get; set; }
}
