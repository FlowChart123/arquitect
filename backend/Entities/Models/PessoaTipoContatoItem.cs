using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class PessoaTipoContatoItem
{
    public Guid Id { get; set; }

    public Guid PessoaId { get; set; }

    public int PessoaTipoContatoId { get; set; }

    public string Valor { get; set; } = null!;

    public virtual PessoaTipoContato PessoaTipoContato { get; set; } = null!;
}
