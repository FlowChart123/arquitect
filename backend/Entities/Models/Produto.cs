using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Produto
{
    public Guid Id { get; set; }

    public Guid PessoaId { get; set; }

    public string Codigo { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public virtual ICollection<DocumentoItem> DocumentoItems { get; } = new List<DocumentoItem>();

    public virtual Pessoa Pessoa { get; set; } = null!;
}
