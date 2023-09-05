using System;
using System.Collections.Generic;
using Entities.Models;

namespace Entities.Model2;

public partial class AppRouteUserVeiculo
{
    public Guid Id { get; set; }

    public Guid VeiculoId { get; set; }

    public virtual Veiculo Veiculo { get; set; } = null!;
}
