using System;
using System.Collections.Generic;
using Entities.Model2;

namespace Entities.Models;

public partial class Veiculo
{
    public Guid Id { get; set; }

    public string Placa { get; set; } = null!;

    public Guid? ProprietarioId { get; set; }

    public int? VieculoTipoId { get; set; }

    public string? Renavan { get; set; }

    public int? Ano { get; set; }

    public string? Cor { get; set; }

    public string? NumeroCrv { get; set; }

    public string? Chassi { get; set; }

    public string? Combustivel { get; set; }

    public string? MarcaModelo { get; set; }

    public decimal? CapacidadePeso { get; set; }

    public decimal? CapacidadeM3 { get; set; }

    public int? Eixos { get; set; }

    public DateTime DataCadastro { get; set; }

    public virtual ICollection<AppRouteUserVeiculo> AppRouteUserVeiculos { get; } = new List<AppRouteUserVeiculo>();

    public virtual Pessoa? Proprietario { get; set; }

    public virtual ICollection<Veiculo1> Veiculo1s { get; } = new List<Veiculo1>();

    public virtual VeiculoTipo? VieculoTipo { get; set; }
}
