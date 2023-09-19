using System;
using System.Collections.Generic;
using Entities.IdentityModels;

namespace Entities.Models;

public partial class Pessoa
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime DataCadastro { get; set; }

    public virtual ICollection<AppRouteUserPessoa> AppRouteUserPessoas { get; } = new List<AppRouteUserPessoa>();

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<DocumentoCte> DocumentoCteExpedidors { get; } = new List<DocumentoCte>();

    public virtual ICollection<DocumentoCte> DocumentoCteRecebedors { get; } = new List<DocumentoCte>();

    public virtual ICollection<Documento> DocumentoDestinatarios { get; } = new List<Documento>();

    public virtual ICollection<Documento> DocumentoEmitentes { get; } = new List<Documento>();

    public virtual ICollection<Documento> DocumentoRemetentes { get; } = new List<Documento>();

    public virtual ICollection<Motoristum> Motorista { get; } = new List<Motoristum>();

    public virtual ICollection<PessoaEndereco> PessoaEnderecos { get; } = new List<PessoaEndereco>();

    public virtual PessoaFisica? PessoaFisica { get; set; }

    public virtual PessoaJuridica? PessoaJuridica { get; set; }

    public virtual PessoaOutro? PessoaOutro { get; set; }

    public virtual ICollection<Produto> Produtos { get; } = new List<Produto>();

    public virtual Transportador? Transportador { get; set; }

    public virtual Transportador1? Transportador1 { get; set; }

    public virtual ICollection<Veiculo> Veiculos { get; } = new List<Veiculo>();
}
