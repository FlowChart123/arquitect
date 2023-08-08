using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class DocumentoFilialGrupo : BaseEntity
{
    public Guid Id { get; set; }

    public Guid EnderecoServicoId { get; set; }

    public int FilialId { get; set; }

    public int? FilialAtualId { get; set; }

    public int? FilialDestinoId { get; set; }

    public Guid? FilialLastMileGrupoItemId { get; set; }

    public Guid? TransportadorLastMileGrupoItemId { get; set; }

    public virtual Endereco EnderecoServico { get; set; } = null!;

    public virtual Documento1 IdNavigation { get; set; } = null!;
}
