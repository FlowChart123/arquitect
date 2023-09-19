using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class EnderecoTipo
{
    public int Id { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<PessoaEndereco> PessoaEnderecos { get; } = new List<PessoaEndereco>();
}
