using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class AppRouteUserPessoa
{
    public Guid Id { get; set; }

    public Guid AppRouteUser { get; set; }

    public Guid PessoaId { get; set; }

    public int PessoaFuncaoId { get; set; }

    public virtual AppRouteUser AppRouteUserNavigation { get; set; } = null!;

    public virtual Pessoa Pessoa { get; set; } = null!;

    public virtual PessoaFuncao PessoaFuncao { get; set; } = null!;
}
