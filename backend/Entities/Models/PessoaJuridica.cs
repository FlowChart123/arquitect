using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class PessoaJuridica : BaseEntity
{
    public Guid Id { get; set; }

    public string Cnpj { get; set; } = null!;

    public string InscricaoEstadual { get; set; } = null!;

    public string? InscricaoMunicipal { get; set; }

    public virtual Pessoa IdNavigation { get; set; } = null!;
}
