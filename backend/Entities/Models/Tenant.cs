using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Tenant
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Decricao { get; set; }

    public DateTime DataCadastro { get; set; }

    public bool Ativo { get; set; }

    public virtual ICollection<Ciot> Ciots { get; } = new List<Ciot>();

    public virtual ICollection<ClienteCodigo> ClienteCodigos { get; } = new List<ClienteCodigo>();

    public virtual ICollection<Documento1> Documento1s { get; } = new List<Documento1>();

    public virtual ICollection<Dt> Dts { get; } = new List<Dt>();

    public virtual ICollection<Empresa> Empresas { get; } = new List<Empresa>();

    public virtual ICollection<LoteEletronico> LoteEletronicos { get; } = new List<LoteEletronico>();

    public virtual ICollection<Motoristum> Motorista { get; } = new List<Motoristum>();

    public virtual ICollection<Romaneio> Romaneios { get; } = new List<Romaneio>();

    public virtual ICollection<Transportador1> Transportador1s { get; } = new List<Transportador1>();

    public virtual ICollection<Veiculo1> Veiculo1s { get; } = new List<Veiculo1>();
}
