using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Municipio
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int? CodigoIbge { get; set; }

    public string? Cep { get; set; }

    public string? Uf { get; set; }

    public int? MunicipioPaiId { get; set; }

    public virtual ICollection<Bairro> Bairros { get; } = new List<Bairro>();

    public virtual ICollection<FilialLastMile> FilialLastMiles { get; } = new List<FilialLastMile>();

    public virtual ICollection<Municipio> InverseMunicipioPai { get; } = new List<Municipio>();

    public virtual Municipio? MunicipioPai { get; set; }
}
