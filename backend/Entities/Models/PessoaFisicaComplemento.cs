using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public partial class PessoaFisicaComplemento
{
    public Guid Id { get; set; }

    public string? Rg { get; set; }

    public DateTime? RgEmissaoData { get; set; }

    public string? RgEmissaoUf { get; set; }

    public string? RgEmissaoMunicipio { get; set; }

    public DateTime? NascimentoData { get; set; }

    public string? NascimentoUf { get; set; }

    public string? NascimentoMunicipio { get; set; }

    public string? NomePai { get; set; }

    public string? NomeMae { get; set; }

    public string? Cnh { get; set; }

    public DateTime? CnhEmissao { get; set; }

    public DateTime? CnhValidade { get; set; }

    public string? CnhCategoria { get; set; }

    public DateTime? CnhPrimeiraHabilitacao { get; set; }

    public string? Nacionalidade { get; set; }
    
    public virtual PessoaFisica? IdNavigation { get; set; } = null!;
}
