using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class AppRouteUserImagem
{
    public Guid Id { get; set; }

    public Guid IdAppRouteUser { get; set; }

    public string TipoImagem { get; set; } = null!;

    public string NomeArquivo { get; set; } = null!;

    public string? Placa { get; set; }

    public virtual AppRouteUser IdAppRouteUserNavigation { get; set; } = null!;
}
