using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class PessoaEndereco
{
    public Guid Id { get; set; }

    public Guid PessoaId { get; set; }

    public Guid EnderecoId { get; set; }

    public int EnderecoTipoId { get; set; }

    public virtual Endereco Endereco { get; set; } = null!;

    public virtual EnderecoTipo EnderecoTipo { get; set; } = null!;

    public virtual Pessoa Pessoa { get; set; } = null!;
}
