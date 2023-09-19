using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Estado
{
    public int Id { get; set; }

    public int IdPais { get; set; }

    public string Nome { get; set; } = null!;

    public string? Uf { get; set; }

    public string? CepInicial { get; set; }

    public string? CepFinal { get; set; }

    public virtual ICollection<FilialLastMile> FilialLastMiles { get; } = new List<FilialLastMile>();

    public virtual Pai IdPaisNavigation { get; set; } = null!;

    public virtual ICollection<TransportadorLastMile> TransportadorLastMiles { get; } = new List<TransportadorLastMile>();
}
