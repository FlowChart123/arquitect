using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Filial : BaseEntity
{
    public int Id { get; set; }

    public int EmpresaId { get; set; }

    public Guid PessoaId { get; set; }

    public int? FilialPaiId { get; set; }

    public DateTime DataCadastro { get; set; }

    public bool? Ativo { get; set; }

    public virtual Empresa Empresa { get; set; } = null!;

    public virtual ICollection<FilialLastMile> FilialLastMiles { get; } = new List<FilialLastMile>();

    public virtual Filial? FilialPai { get; set; }

    public virtual ICollection<Filial> InverseFilialPai { get; } = new List<Filial>();
}
