using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public partial class PessoaJuridica
{
    public Guid Id { get; set; }

    public string Cnpj { get; set; } = null!;

    public string? Fantasia { get; set; }

    public string InscricaoEstadual { get; set; } = null!;

    public string? InscricaoMunicipal { get; set; }

    [NotMapped]
    public virtual Pessoa? IdNavigation { get; set; } = null!;

    public virtual PessoaJuridicaComplemento? PessoaJuridicaComplemento { get; set; }
}
