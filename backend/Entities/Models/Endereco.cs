using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Endereco
{
    public Guid Id { get; set; }

    public string Tipo { get; set; } = null!;

    public string Logradouro { get; set; } = null!;

    public string? Numero { get; set; }

    public string? Complemento { get; set; }

    public string? Cep { get; set; }

    public string? Uf { get; set; }

    public int? MunicipioId { get; set; }

    public string? CodigoIbge { get; set; }

    public string? NomeMunicipio { get; set; }

    public int? BairroId { get; set; }

    public string? NomeBairro { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public DateTime? DataCadastro { get; set; }

    public virtual ICollection<DocumentoFilialGrupo> DocumentoFilialGrupos { get; } = new List<DocumentoFilialGrupo>();

    public virtual ICollection<PessoaEndereco> PessoaEnderecos { get; } = new List<PessoaEndereco>();
}
