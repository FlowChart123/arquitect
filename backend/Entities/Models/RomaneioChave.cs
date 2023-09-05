using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class RomaneioChave
{
    public Guid Id { get; set; }

    public Guid RomaneioId { get; set; }

    public string Chave { get; set; } = null!;

    public DateTime? DataCadastro { get; set; }

    public virtual Romaneio Romaneio { get; set; } = null!;
}
