using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Filial
{
    public int Id { get; set; }

    public int EmpresaId { get; set; }

    public Guid PessoaId { get; set; }

    public int? FilialPaiId { get; set; }

    public DateTime DataCadastro { get; set; }

    public bool Ativo { get; set; }

    public virtual ICollection<Ciot> Ciots { get; } = new List<Ciot>();

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual ICollection<DocumentoCte> DocumentoCtes { get; } = new List<DocumentoCte>();

    public virtual ICollection<Dt> Dts { get; } = new List<Dt>();

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual ICollection<FilialLastMile> FilialLastMiles { get; } = new List<FilialLastMile>();

    public virtual Filial? FilialPai { get; set; }

    public virtual ICollection<Filial> InverseFilialPai { get; } = new List<Filial>();

    public virtual ICollection<LoteEletronico> LoteEletronicos { get; } = new List<LoteEletronico>();
}
