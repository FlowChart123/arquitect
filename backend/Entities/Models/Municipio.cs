using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Municipio
{
    public int Id { get; set; }

    public int? MunicipioPaiId { get; set; }

    public string? Uf { get; set; }

    public string? Chave { get; set; }

    public string? CepMin { get; set; }

    public string? CepMax { get; set; }

    public string? Nome { get; set; }

    public string? CidadeAcento { get; set; }

    public string? TipoCidade { get; set; }

    public string? Ddd { get; set; }

    public string? CodigoIbge { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public virtual ICollection<DocumentoCte> DocumentoCteMunicipioFinalTransportes { get; } = new List<DocumentoCte>();

    public virtual ICollection<DocumentoCte> DocumentoCteMunicipioInicioTransportes { get; } = new List<DocumentoCte>();

    public virtual ICollection<Municipio> InverseMunicipioPai { get; } = new List<Municipio>();

    public virtual Municipio? MunicipioPai { get; set; }
}
