using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class FilialLastMile : BaseEntity
{
    public Guid Id { get; set; }

    public int FilialId { get; set; }

    public string? CepInicial { get; set; }

    public string? CepFinal { get; set; }

    public int? BairroId { get; set; }

    public int? MunicipioId { get; set; }

    public int? EstadoId { get; set; }

    public DateTime? DataCadastro { get; set; }

    public virtual Bairro? Bairro { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual Filial Filial { get; set; } = null!;

    public virtual ICollection<FilialLastMileGrupoItem> FilialLastMileGrupoItems { get; } = new List<FilialLastMileGrupoItem>();

    public virtual Municipio? Municipio { get; set; }
}
