using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class TransportadorLastMile : BaseEntity
{
    public Guid Id { get; set; }

    public int TransportadorId { get; set; }

    public string? CepInicial { get; set; }

    public string? CepFinal { get; set; }

    public int? BairroId { get; set; }

    public int? MunicipioId { get; set; }

    public int? EstadoId { get; set; }

    public DateTime? DataCadastro { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual ICollection<TransportadorLastMileGrupoItem> TransportadorLastMileGrupoItems { get; } = new List<TransportadorLastMileGrupoItem>();
}
