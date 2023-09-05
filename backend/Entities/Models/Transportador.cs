using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Transportador
{
    public Guid Id { get; set; }

    public int TipoRntrcId { get; set; }

    public string? Rntrc { get; set; }

    public DateTime? RntrcValidade { get; set; }

    public DateTime? DataVerificacao { get; set; }

    public DateTime? DataCadastro { get; set; }

    public virtual Pessoa IdNavigation { get; set; } = null!;

    public virtual TipoRntrc TipoRntrc { get; set; } = null!;

    public virtual ICollection<Transportador1> Transportador1s { get; } = new List<Transportador1>();
}
