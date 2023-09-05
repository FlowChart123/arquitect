using System;
using System.Collections.Generic;

namespace Entities.Model2;

public partial class AppRouteUser
{
    public Guid Id { get; set; }

    public int AppRouteStatusId { get; set; }

    public string Cpf { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public string? CelularCodigoConfirmacao { get; set; }

    public string? Senha { get; set; }

    public string? CodigoFirebase { get; set; }

    public DateTime? DataCadastro { get; set; }

    public DateTime? UltimoAcesso { get; set; }

    public virtual AppRouteStatus AppRouteStatus { get; set; } = null!;

    public virtual ICollection<AppRouteUserImagem> AppRouteUserImagems { get; } = new List<AppRouteUserImagem>();

    public virtual ICollection<AppRouteUserPessoa> AppRouteUserPessoas { get; } = new List<AppRouteUserPessoa>();
}
