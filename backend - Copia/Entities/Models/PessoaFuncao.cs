using System;
using System.Collections.Generic;
using Entities.IdentityModels;

namespace Entities.Models;

public partial class PessoaFuncao
{
    public int Id { get; set; }

    public string Descricao { get; set; } = null!;

    public bool? Ativo { get; set; }

    public virtual ICollection<AppRouteUserPessoa> AppRouteUserPessoas { get; } = new List<AppRouteUserPessoa>();
}
