using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Tenant : BaseEntity
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime DataCadastro { get; set; }

    public bool? Ativo { get; set; }

    public virtual ICollection<Documento1> Documento1s { get; } = new List<Documento1>();

    public virtual ICollection<Empresa> Empresas { get; } = new List<Empresa>();

    public virtual ICollection<Romaneio> Romaneios { get; } = new List<Romaneio>();

    public virtual ICollection<Transportador1> Transportador1s { get; } = new List<Transportador1>();

    public virtual ICollection<Veiculo1> Veiculo1s { get; } = new List<Veiculo1>();
}
