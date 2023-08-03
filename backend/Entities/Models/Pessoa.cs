using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Pessoa
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Fantasia { get; set; } = null!;

    public DateTime DataCadastro { get; set; }

    public virtual ICollection<Documento> DocumentoDestinatarios { get; } = new List<Documento>();

    public virtual ICollection<Documento> DocumentoEmitentes { get; } = new List<Documento>();

    public virtual ICollection<Documento> DocumentoRemetentes { get; } = new List<Documento>();

    public virtual ICollection<PessoaEndereco> PessoaEnderecos { get; } = new List<PessoaEndereco>();

    public virtual PessoaFisica? PessoaFisica { get; set; }

    public virtual PessoaJuridica? PessoaJuridica { get; set; }

    public virtual PessoaOutro? PessoaOutro { get; set; }

    public virtual ICollection<Produto> Produtos { get; } = new List<Produto>();

    public virtual Transportador? Transportador { get; set; }

    public virtual Transportador1? Transportador1 { get; set; }

    public virtual ICollection<Veiculo> Veiculos { get; } = new List<Veiculo>();
}
