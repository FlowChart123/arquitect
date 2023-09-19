using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Cep
{
    public string? Cep1 { get; set; }

    public string? Chave { get; set; }

    public string? Uf { get; set; }

    public string? TipoOficial { get; set; }

    public string? TipoAcento { get; set; }

    public string? NomeOficial { get; set; }

    public string? NomeAcento { get; set; }

    public string? Bairro1Oficial { get; set; }

    public string? Bairro1Acento { get; set; }

    public string? CidadeOficial { get; set; }

    public string? CidadeAcento { get; set; }

    public string? CodMun { get; set; }

    public double? Liminfpar { get; set; }

    public double? Liminfimpa { get; set; }

    public double? Limsuppar { get; set; }

    public double? Limsupimpa { get; set; }

    public double? Flags { get; set; }

    public double? Lados { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public string? LogComplemento { get; set; }

    public string? NomeCepEsp { get; set; }

    public string? Ddd { get; set; }

    public int? MunicipioId { get; set; }

    public int? BairroId { get; set; }
}
