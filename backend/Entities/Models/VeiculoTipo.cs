using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class VeiculoTipo
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<RomaneioCarga> RomaneioCargas { get; } = new List<RomaneioCarga>();

    public virtual ICollection<Veiculo> Veiculos { get; } = new List<Veiculo>();
}
