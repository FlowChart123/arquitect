using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class RomaneioCarga
{
    public Guid Id { get; set; }

    public Guid? VeiculoId { get; set; }

    public int? VeiculoTipoId { get; set; }

    public decimal? PesoBruto { get; set; }

    public decimal? MetragemCubica { get; set; }

    public int? Paradas { get; set; }

    public decimal? DitanciaKm { get; set; }

    public virtual Romaneio IdNavigation { get; set; } = null!;

    public virtual Veiculo1? Veiculo { get; set; }

    public virtual VeiculoTipo? VeiculoTipo { get; set; }
}
